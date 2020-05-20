using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] cameras, camTargets;
    public AttackJet[] attackJets;
    public int curCamTarget = 4, leader = 0;
    public float timer = 0f, delay = 0f;
    public GameObject bullet, rocket, swordFish, tempB, tempR;

    public static Manager Instance { get; private set; }
                                         // firing bullets, rocket, dying, waypoint reached, cantSwitch, flash
    public bool[] Flags { get; set; } = new bool[] { false, false,  false, false,            false,     false};

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
        //StartCoroutine(CheckJetStatus());
        Flags[4] = true;
        timer = 0;
        delay = 5f;
        //StartCoroutine(CameraCooldown(4, 5f));
    }

    void Update()
    {
        if (leader < attackJets.Length) {
            if (attackJets[leader].dead == true)
            {
                attackJets[leader].lead = false;
                leader++;
            }
            else
            {
                attackJets[leader].lead = true;
            }
        }

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            Flags[4] = false;
        }

        if (Flags[2] && leader < attackJets.Length) //dying
        {
            if (cameras[4].GetComponent<CameraFollow>().cameraTarget != camTargets[0+leader].transform)
            {
                cameras[4].transform.position = camTargets[0+leader].transform.position;
                cameras[4].transform.rotation = camTargets[0+leader].transform.rotation;
                cameras[4].GetComponent<CameraFollow>().cameraTarget = camTargets[0+leader].transform;
            }

            if (curCamTarget != 4) {
                cameras[curCamTarget].SetActive(false);
                curCamTarget = 4;
                cameras[curCamTarget].SetActive(true);
            }
            Debug.Log("dying " + Flags[2]);
            Flags[4] = true;
            Flags[2] = false;
            //StartCoroutine(CameraCooldown(4, 3f));
            timer = 0;
            delay = 2f;
            
        }
        else if (Flags[1] && curCamTarget != 4) //firing rocket
        {
            if (cameras[4].GetComponent<CameraFollow>().cameraTarget != cameras[2].transform)
            {
                cameras[4].transform.position = cameras[2].transform.position;
                cameras[4].transform.rotation = cameras[2].transform.rotation;
                cameras[4].GetComponent<CameraFollow>().cameraTarget = tempR.transform;
            }

            if (curCamTarget != 4)
            {
                cameras[curCamTarget].SetActive(false);
                curCamTarget = 4;
                cameras[curCamTarget].SetActive(true);
            }
            Debug.Log("rocket " + Flags[4]);
            Flags[4] = true;
            //StartCoroutine(CameraCooldown(4, 5f));
            timer = 0;
            delay = 5f;
        }
        else if (Flags[5] && curCamTarget != 1 && !Flags[4]) //flashbang
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 1;
            cameras[curCamTarget].SetActive(true);
            Debug.Log("flash " + Flags[4]);
            Flags[4] = true;
            //StartCoroutine(CameraCooldown(4, 4f));
            timer = 0;
            delay = 4f;
        }
        else if (Flags[0] && leader < attackJets.Length && !Flags[4]) //firing bullets
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 2+leader;
            cameras[curCamTarget].SetActive(true);
            Debug.Log("bullets " + Flags[2]);
            Flags[4] = true;
            //StartCoroutine(CameraCooldown(4, 4f));
            timer = 0;
            delay = 4f;
        }
        else if (Flags[3] && curCamTarget != 0 && !Flags[4]) //turning
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 0;
            cameras[curCamTarget].SetActive(true);
            Debug.Log("turning " + Flags[2]);
            Flags[4] = true;
            //StartCoroutine(CameraCooldown(4, 3f));
            Flags[3] = false;
            timer = 0;
            delay = 3f;
        }
        else if(leader < attackJets.Length && !Flags[4]) //default
        {
            if (cameras[4].GetComponent<CameraFollow>().cameraTarget != camTargets[0 + leader].transform)
            {
                cameras[4].transform.position = camTargets[0 + leader].transform.position;
                cameras[4].transform.rotation = camTargets[0 + leader].transform.rotation;
                cameras[4].GetComponent<CameraFollow>().cameraTarget = camTargets[0 + leader].transform;
            }

            if (curCamTarget != 4)
            {
                cameras[curCamTarget].SetActive(false);
                curCamTarget = 4;
                cameras[curCamTarget].SetActive(true);
            }
            Debug.Log("default " + Flags[4]);
            Flags[4] = true;
            //StartCoroutine(CameraCooldown(4, 2f));
            timer = 0;
            delay = 1f;
        }

        if (Flags[2]||Flags[3]) {
            //Debug.Log(Flags[2] + " " + Flags[3] + " " + Flags[4]);
        }

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
        tempR = Instantiate(rocket, pos, rot);
        tempR.transform.LookAt(swordFish.transform);
        rocket.GetComponent<Seek>().targetGameObject = swordFish;
        Flags[1] = true;
        StartCoroutine(CameraCooldown(1, 4f));
    }

    public void CreateBullet(Vector3 pos, Quaternion rot)
    {
        tempB = Instantiate(bullet, pos, rot);
        tempB.transform.LookAt(swordFish.transform);
        Flags[0] = true;
        StartCoroutine(CameraCooldown(0, 5f));
    }

    IEnumerator CheckJetStatus()
    {
        while (true)
        {
            
            
            {
                
            }
            //yield return new WaitForSeconds(checkInterval);
        }
    }

    public IEnumerator CameraCooldown(int i, float cooldown)
    {
        if (Flags[i] == true) {
            yield return new WaitForSeconds(cooldown);
            Flags[i] = false;
        }
    }
}
