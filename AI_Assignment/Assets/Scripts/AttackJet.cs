﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FollowState : State
{
    public override void Enter()
    {
        owner.GetComponent<OffsetPursue>().enabled = true;
        owner.GetComponent<Pursue>().enabled = false;
    }

    public override void Think()
    {
        if (owner.tag == "Leader")
        {
            owner.GetComponent<StateMachine>().ChangeState(new PursueState());
        }      
    }

    public override void Exit()
    {
        owner.GetComponent<OffsetPursue>().enabled = false;
    }
}

class PursueState : State
{
    int rockets = 1;
    float timer = 0;

    public override void Enter()
    {
        owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {   //only fires when within 20 degree angle and over distance 300
        if (rockets > 0 && Vector3.Angle(owner.GetComponent<Pursue>().target.transform.position - owner.transform.position, 
            owner.transform.forward) < 20 && Vector3.Distance(owner.transform.position, Manager.Instance.swordFish.transform.position) > 300)
        {
            Manager.Instance.CreateRocket(owner.transform.GetChild(0).position, owner.transform.GetChild(0).rotation);
            rockets--;
        }
    
        if (Vector3.Angle(owner.GetComponent<Pursue>().target.transform.position - owner.transform.position, owner.transform.forward) < 20 && timer > 0.06f)
        {
            Manager.Instance.CreateBullet(owner.transform.GetChild(0).position, owner.transform.GetChild(0).rotation);
            timer = 0;
        }
        timer += Time.deltaTime;

        if (owner.GetComponent<AttackJet>().dead)
        {
            owner.GetComponent<StateMachine>().ChangeState(new DyingState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Pursue>().enabled = false;
        owner.GetComponent<ObstacleAvoidance>().enabled = false;
    }
}

class DyingState : State
{
    public override void Enter()
    {
        owner.GetComponent<Rigidbody>().useGravity = true;
        owner.GetComponent<Boid>().enabled = true;
    }

    public override void Think()
    {
        if (owner.GetComponent<AttackJet>().crash)
        {
            owner.gameObject.SetActive(false);
        }       
    }
}

public class AttackJet : MonoBehaviour
{
    public bool lead = false, dead = false, crash = false;

    void Start()
    {
        if (lead)
        {
            GetComponent<StateMachine>().ChangeState(new PursueState());
        }
        else
        {
            GetComponent<StateMachine>().ChangeState(new FollowState());
        }
    }

    void Update()
    {
        if (lead)
        {
            gameObject.tag = "Leader";
        }
        else
        {
            gameObject.tag = "Untagged";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.tag == "Ground")
        {
            crash = true;
            dead = true;
            Manager.Instance.explosion[0].gameObject.transform.position = gameObject.transform.position;
            Manager.Instance.explosion[0].Play();
            Manager.Instance.explosion[1].gameObject.transform.position = gameObject.transform.position;
            Manager.Instance.explosion[1].Play();
            Manager.Instance.explosion[2].gameObject.transform.position = gameObject.transform.position;
            Manager.Instance.explosion[2].Play();
        }
        else if (collision.gameObject.tag == "SwordAttack") //swordfish attack = hits anything but ground
        {
            Manager.Instance.Flags[2] = true;
            dead = true;
            Manager.Instance.explosion[0].gameObject.transform.position = gameObject.transform.position;
            Manager.Instance.explosion[0].Play();
            Manager.Instance.explosion[1].gameObject.transform.position = gameObject.transform.position;
            Manager.Instance.explosion[1].Play();
            Manager.Instance.explosion[2].gameObject.transform.position = gameObject.transform.position;
            Manager.Instance.explosion[2].Play();
        }

        if (collision.gameObject.tag == "FlashBang")
        {
            GetComponent<ObstacleAvoidance>().enabled = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "FlashBang")
        {
            GetComponent<ObstacleAvoidance>().enabled = true;
        }
    }
}
