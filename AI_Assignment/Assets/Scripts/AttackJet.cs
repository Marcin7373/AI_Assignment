using System.Collections;
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
    public override void Enter()
    {
        
        owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        //firing

        if (owner.GetComponent<AttackJet>().dead)
        {
            owner.GetComponent<StateMachine>().ChangeState(new DyingState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Pursue>().enabled = false;
        owner.GetComponent<Boid>().enabled = false;
    }
}

class DyingState : State
{
    public override void Enter()
    {
        owner.GetComponent<Rigidbody>().useGravity = true;
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

    private void Start()
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
        }else if (collision.gameObject.tag == "SwordAttack")
        {
            dead = true;
        }
    }
}
