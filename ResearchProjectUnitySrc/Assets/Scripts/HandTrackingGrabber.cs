using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandTrackingGrabber : OVRGrabber
{
    private OVRHand.Hand hand;
    public float pinchThresh = 0.7f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand.Hand>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        float pinchStrength = GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Index);
        
        if (!m_grabbedObj && pinchStrength >= pinchThresh && m_grabCandidates.Count > 0)
        {
            GrabBegin();
        } 
        // else if (!m_grabbedObj && pinchStrength >= pinchThresh)
        // {
        //     //Detect shake?
        // }
        else if (m_grabbedObj && pinchStrength < pinchThresh)
        {
            GrabEnd();
        }
    }

    public bool isHoldingItem()
    {
        return m_grabCandidates.Count > 0 && m_grabbedObj; 
    }

    public GameObject getHoldingItem()
    {
        if (m_grabbedObj != null)
        {
            return m_grabbedObj.gameObject;
        }
        else
        {
            return null;
        }
    }
}
