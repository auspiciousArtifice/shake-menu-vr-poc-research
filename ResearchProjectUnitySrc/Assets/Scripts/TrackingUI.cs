using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingUI : MonoBehaviour
{
    const int scalingInterval = 20;
    Camera playerView;
    bool expand;
    bool collapse;
    bool enlarged;
    int scalingCount;
    Vector3 expandedScale;
    Vector3 collapsedScale;
    Vector3 scalingVector;
    // Start is called before the first frame update
    void Start()
    {
        playerView = Camera.main;
        expand = false;
        collapse = true;
        enlarged = false;
        scalingCount = 0;
        expandedScale = transform.localScale;
        collapsedScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
        scalingVector = new Vector3(expandedScale.x - collapsedScale.x, expandedScale.y - collapsedScale.y, expandedScale.z - collapsedScale.z) / scalingInterval;
        transform.localScale = collapsedScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (expand && !enlarged && scalingCount < scalingInterval)
        {
            Vector3 newScale = transform.localScale + scalingVector;
            transform.localScale = newScale;
            scalingCount++;
        }
        else if (expand && !enlarged && scalingCount >= scalingInterval)
        {
            expand = false;
            scalingCount = 0;
            enlarged = true;
        }
        else if (collapse && enlarged && scalingCount < scalingInterval)
        {
            Vector3 newScale = transform.localScale - scalingVector;
            transform.localScale = newScale;
            scalingCount++;
        }
        else if (collapse && enlarged && scalingCount >= scalingInterval)
        {
            collapse = false;
            scalingCount = 0;
            enlarged = false;
        }
    }

    void LateUpdate()
    {
        transform.LookAt(playerView.transform);
    }

    public void expandCollapse()
    {
        if (enlarged)
        {
            collapseUI();
        }
        else
        {
            expandUI();
        }
    }

    public void expandUI()
    {
        expand = true;
        collapse = false;
    }

    public void collapseUI()
    {
        collapse = true;
        expand = false;
    }
}
