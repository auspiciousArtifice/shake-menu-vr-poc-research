using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSphere : MonoBehaviour
{
    public GameObject menu;

    private void OnTriggerEnter(Collider other)
    {
        if (menu != null && (other.CompareTag("Left Hand") || other.CompareTag("Right Hand")))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
