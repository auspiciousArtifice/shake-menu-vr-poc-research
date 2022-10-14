using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform targetTransform;
    public Transform respawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null)
        {
            if (Vector3.Distance(transform.position, targetTransform.position) > 2)
            {
                RespawnObject();
            }
        }
    }

    public void RespawnObject()
    {
        transform.position = respawnPoint.position;
    }
}
