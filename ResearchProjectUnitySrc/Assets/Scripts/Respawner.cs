using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Respawn respawnObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left Hand"))
        {
            respawnObject.RespawnObject();
        }
    }
}
