using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeButton : MonoBehaviour
{
    public Material changeTo;
    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (target != null && changeTo != null && other.CompareTag("Left Hand"))
        {
            target.GetComponent<MeshRenderer>().material = changeTo;
        }
    }
}
