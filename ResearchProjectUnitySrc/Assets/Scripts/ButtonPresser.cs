using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresser : MonoBehaviour
{
    TrackingUI ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("TrackingCanvas").GetComponent<TrackingUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ui.expandUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("TrackingButton"))
        {
            ui.collapseUI();
        }
    }
}
