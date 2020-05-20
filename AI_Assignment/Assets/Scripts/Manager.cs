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
    private Transform lastSeenTarget;
    public ParticleSystem[] explosion;

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
        swordFish.GetComponent<SwordFish>().attacker = attackJets[leader].transform;
        lastSeenTarget = camTargets[leader].transform;
        Flags[4] = true;
        timer = 0;
        delay = 5f; //following 2nd attacker jet at intro
    }

    void Update()
    {
        if (leader < attackJets.Length) { // leader switching if dead
            if (attackJets[leader].dead == true)
            {
                attackJets[leader].lead = false;
                lastSeenTarget = camTargets[leader].transform; // for watching explosion after dead
                leader++;
                swordFish.GetComponent<SwordFish>().attacker = attackJets[leader].transform;
            }
            else
            {
                attackJets[leader].lead = true;
            }
        }

        timer += Time.deltaTime; //delay in camera switching
        if (timer >= delay)
        {
            Flags[4] = false;
        }

        if (Flags[2]) //dying
        {
            cameras[4].transform.position = camTargets[2].transform.position;
            cameras[4].transform.LookAt(lastSeenTarget.position);
            cameras[4].GetComponent<CameraFollow>().cameraTarget = camTargets[2].transform; //switch to follow static camera

            if (curCamTarget != 4) {
                cameras[curCamTarget].SetActive(false);
                curCamTarget = 4;
                cameras[curCamTarget].SetActive(true);
            }
            Debug.Log("dying " + Flags[2]);
            Flags[4] = true;
            Flags[2] = false;
            timer = 0;
            delay = 2f;    
        }
        else if (Flags[1] && tempR != null) //firing rocket - mobile camera follows rocket
        {
            if (cameras[4].GetComponent<CameraFollow>().cameraTarget != cameras[2].transform)
            {
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
            timer = 0;
            delay = 3f;
        }
        else if (Flags[5] && curCamTarget != 1 && !Flags[4]) //flashbang
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 1;
            cameras[curCamTarget].SetActive(true);//camera at back of swordfish
            Debug.Log("flash " + Flags[4]);
            Flags[4] = true;
            timer = 0;
            delay = 4f;
        }
        else if (Flags[0] && leader < attackJets.Length && !Flags[4]) //firing bullets
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 2+leader;
            cameras[curCamTarget].SetActive(true); //camera below jet
            Debug.Log("bullets " + Flags[2]);
            Flags[4] = true;
            timer = 0;
            delay = 4f;
        }
        else if (Flags[3] && curCamTarget != 0 && !Flags[4]) //Swordfish turning at waypoint
        {
            cameras[curCamTarget].SetActive(false);
            curCamTarget = 0;
            cameras[curCamTarget].SetActive(true); //camera inside cockpit
            Debug.Log("turning " + Flags[2]);
            Flags[4] = true;
            Flags[3] = false;
            timer = 0;
            delay = 3f;
        }
        else if(leader < attackJets.Length && !Flags[4]) //default - follow leader using mobile camera
        {
            if (cameras[4].GetComponent<CameraFollow>().cameraTarget != camTargets[leader].transform)
            {
                //cameras[4].transform.position = camTargets[leader].transform.position;
                //cameras[4].transform.rotation = camTargets[leader].transform.rotation;
                cameras[4].GetComponent<CameraFollow>().cameraTarget = camTargets[leader].transform;
            }

            if (curCamTarget != 4)
            {
                cameras[curCamTarget].SetActive(false);
                curCamTarget = 4;
                cameras[curCamTarget].SetActive(true);
            }
            Debug.Log("default " + Flags[4]);
            Flags[4] = true;
            timer = 0;
            delay = 1f;
        }
    }

    public void CreateRocket(Vector3 pos, Quaternion rot)
    {
        tempR = Instantiate(rocket, pos, rot);
        tempR.transform.LookAt(swordFish.transform);
        tempR.GetComponent<Seek>().targetGameObject = swordFish;
        Flags[1] = true;
        StartCoroutine(CameraCooldown(1, 3f));
    }

    public void CreateBullet(Vector3 pos, Quaternion rot)
    {
        tempB = Instantiate(bullet, pos, rot);
        tempB.transform.LookAt(swordFish.transform);
        Flags[0] = true;
        StartCoroutine(CameraCooldown(0, 5f));
    }
    // for resetting flags for the camera
    public IEnumerator CameraCooldown(int i, float cooldown)
    {
        if (Flags[i] == true) {
            yield return new WaitForSeconds(cooldown);
            Flags[i] = false;
        }
    }
}
