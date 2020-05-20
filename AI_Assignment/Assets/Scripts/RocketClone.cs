using System.Collections;
using UnityEngine;

public class RocketClone : MonoBehaviour
{
    public GameObject rocket, target, temp;

    void Start()
    {
        target = gameObject.GetComponent<Seek>().targetGameObject;
        StartCoroutine(Clone());
    }

    IEnumerator Clone()
    {   //extra split off rockets
        yield return new WaitForSeconds(0.1f);
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
        yield return new WaitForSeconds(0.1f);
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
        yield return new WaitForSeconds(0.2f);
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
        yield return new WaitForSeconds(0.1f);
        temp = Instantiate(rocket, transform.position, transform.rotation);
        temp.GetComponent<Seek>().targetGameObject = target;
    }
}
