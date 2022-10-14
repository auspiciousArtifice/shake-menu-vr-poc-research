using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingSphere : MonoBehaviour
{
    public GameObject switcher;
    public GameObject switchee;
    private void OnTriggerEnter(Collider other)
    {
        if (switcher != null && switchee != null && other.CompareTag("Right Hand"))
        {
            switcher.SetActive(!switcher.activeSelf);
            switchee.SetActive(!switchee.activeSelf);
        }
    }
}
