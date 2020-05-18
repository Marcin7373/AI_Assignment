using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * force);
    }
}
