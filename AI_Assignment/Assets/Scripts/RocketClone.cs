using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketClone : MonoBehaviour
{
    public GameObject rocket, target;

    void Start()
    {
        target = gameObject.GetComponent<Seek>().targetGameObject;
        StartCoroutine(Clone());
    }

    IEnumerator Clone()
    {
        yield return new WaitForSeconds(0.4f);
        GameObject temp = rocket;
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
    }
}
