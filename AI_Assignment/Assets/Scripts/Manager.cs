using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] cameras;
    public AttackJet[] attackJets;
    public int curCamTarget = 0, leader = 0;
    public float checkInterval = 1f;
    public GameObject bullet, rocket, swordFish;

    public static Manager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        attackJets[leader].lead = true;
        StartCoroutine(CheckJetStatus());
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 1;
            cameras[curCamTarget].SetActive(true);
        }
        else if (Input.GetKeyDown("2"))
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 2;
            cameras[curCamTarget].SetActive(true);
        }
        else if (Input.GetKeyDown("3"))
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 3;
            cameras[curCamTarget].SetActive(true);
        }
    }

    public void CreateRocket(Vector3 pos, Quaternion rot)
    {
        rocket = Instantiate(rocket, pos, rot);
        rocket.GetComponent<Seek>().targetGameObject = swordFish;
        cameras[curCamTarget].SetActive(false);
        curCamTarget = 4;
        cameras[curCamTarget].SetActive(true);
        cameras[curCamTarget].GetComponent<CameraFollow>().cameraTarget = rocket.transform;
    }

    public void CreateBullet(Vector3 pos, Quaternion rot)
    {
        GameObject temp = bullet;
        temp = Instantiate(bullet, pos, rot);
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
