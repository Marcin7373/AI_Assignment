using System.Collections;
using UnityEngine;

public class ProjectileKill : MonoBehaviour
{
    public float delay = 2f, life = 20f;
    
    void Start()
    {
        StartCoroutine(Kill(life));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine(Kill(delay));
        }
        else if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Kill(0));
        }
    }

    IEnumerator Kill(float delay)
    {     
        yield return new WaitForSeconds(delay);
        Manager.Instance.explosion[0].gameObject.transform.position = gameObject.transform.position;
        Manager.Instance.explosion[0].Play();
        Destroy(gameObject);
    }
}
