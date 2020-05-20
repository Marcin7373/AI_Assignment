using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour
{
    public ParticleSystem flash1, flash2;
    public Transform attacker;
    public GameObject flashBang, temp;
    public int lives = 3;

    void Update()
    {
        //flashbang when under pipe and agains the wall
        if ((GetComponent<FollowPath>().path.next == 10 || GetComponent<FollowPath>().path.next == 6) && temp == null)
        {          
            temp = Instantiate(flashBang, Vector3.MoveTowards(transform.position, attacker.position, 30), transform.rotation);
            flash1.gameObject.transform.LookAt(attacker);
            flash1.Play();
            flash2.gameObject.transform.LookAt(attacker);
            flash2.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        lives--;
    }
}
