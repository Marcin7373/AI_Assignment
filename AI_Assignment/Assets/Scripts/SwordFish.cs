using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour
{
    public int lives = 3;

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "JetAttack")
        {
            lives--;
        }
    }
}
