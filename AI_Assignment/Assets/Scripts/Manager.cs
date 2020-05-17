using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] cameras;
    public AttackJet[] attackJets;
    private int curTarget = 0, leader = 0;
    public float checkInterval = 1f;

    void Start()
    {
        attackJets[leader].lead = true;
        StartCoroutine(CheckJetStatus());
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            cameras[curTarget].SetActive(false);
            curTarget = 1;
            cameras[curTarget].SetActive(true);
        }
        else if (Input.GetKeyDown("2"))
        {
            cameras[curTarget].SetActive(false);
            curTarget = 2;
            cameras[curTarget].SetActive(true);
        }
        else if (Input.GetKeyDown("3"))
        {
            cameras[curTarget].SetActive(false);
            curTarget = 3;
            cameras[curTarget].SetActive(true);
        }
    }

    IEnumerator CheckJetStatus()
    {
        while (true)
        {
            if (attackJets[leader].dead == true)
            {
                attackJets[leader].lead = false;
                leader++;
            }
            else
            {
                attackJets[leader].lead = true;
            }
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
