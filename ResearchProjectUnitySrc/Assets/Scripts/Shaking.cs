using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    private const int bufferSize = 5;
    private Vector3 lastvel = Vector3.zero;
    private Vector3 last_position;
    public HandTrackingGrabber grab;
    private List<bool> shakeBuffer;
    
    float accelerometerUpdateInterval = 1.0f / 60.0f;
// The greater the value of LowPassKernelWidthInSeconds, the slower the
// filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 1.0f;
// This next parameter is initialized to 2.0 per Apple's recommendation,
// or at least according to Brady! ;)
    float shakeDetectionThreshold = 2.0f;

    float lowPassFilterFactor;
    Vector3 lowPassValue;
    // Start is called before the first frame update
    void Start()
    {
        last_position = transform.position;
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Vector3.zero;
        shakeBuffer = new List<bool>(bufferSize);
    }

    // Update is called once per frame
    void Update()
    {
        // > .2f == Continuous, erratic shaking, too difficult
        // .2f == Strong flick, tiring
        // .185f == Goldilocks flick, not too tiring, won't sense long movment unless dragging across entire hand tracking area
        // .17f == Medium flick, still sensitive on long movements
        // < .17f == Light flick, picks up every small movement
        var dt = 0.185f;
        var position = transform.position;
        var velocity = 2 * ((position - last_position) / dt);
        var acceleration = (velocity - lastvel) / dt;
        last_position = position;
        lastvel = velocity;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        if (deltaAcceleration.sqrMagnitude > shakeDetectionThreshold && grab != null && grab.isHoldingItem())
        {
            shakeBuffer.Add(true);
        }
        else
        {
            shakeBuffer.Add(false);
        }

        if (shakeBuffer.All(x => x))
        {
            // Perform your "shaking actions" here. If necessary, add suitable
            // guards in the if check above to avoid redundant handling during
            // the same shake (e.g. a minimum refractory period).
            Debug.Log("Shake event detected at time " + Time.time);
            //Debug.Log("Item Held: " + grab.getHoldingItem().name);
            GameObject heldItem = grab.getHoldingItem();
            TrackingUI ui = heldItem.transform.Find("TrackingCanvas").gameObject.GetComponent<TrackingUI>();
            if (ui != null && ui.isActiveAndEnabled)
            {
                ui.expandCollapse();
            }
        }

        shakeBuffer.RemoveAt(0);
    }
}
