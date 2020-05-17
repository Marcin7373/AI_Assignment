using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] cameraTarget;
    public float smoothing = 2.0f;
    private int curTarget = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("1"))
        {
            curTarget = 1;
        }else if (Input.GetKeyDown("2"))
        {
            curTarget = 2;
        }

        transform.position = Vector3.Lerp(transform.position, cameraTarget[curTarget].position, Time.deltaTime * smoothing);
        transform.LookAt(cameraTarget[curTarget]);
    }
}
