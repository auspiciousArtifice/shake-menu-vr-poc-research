using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    Camera playerView;
    // Start is called before the first frame update
    void Start()
    {
        playerView = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(playerView.transform);
    }
}
