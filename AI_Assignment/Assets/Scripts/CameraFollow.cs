using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public float smoothing = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, Time.deltaTime * smoothing);
        transform.LookAt(cameraTarget);
    }
}
