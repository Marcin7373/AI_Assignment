using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour {

    public Path path;
    public float minDist = 100;
    Vector3 nextWaypoint;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, nextWaypoint);
        }
    }

    public void Start()
    {
        
    }

    public override Vector3 Calculate()
    {
        nextWaypoint = path.NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < minDist)
        {
            Manager.Instance.Flags[3] = true;
            StartCoroutine(Manager.Instance.CameraCooldown(3, 1f));
            path.AdvanceToNext();
            if (path.next == 6)
            {
                Manager.Instance.Flags[5] = true;
                StartCoroutine(Manager.Instance.CameraCooldown(5, 2f));
            }
            
        }

        if (!path.looped && path.IsLast())
        {
            return boid.ArriveForce(nextWaypoint, 20);
        }
        else
        {
            return boid.SeekForce(nextWaypoint);
        }
    }
}
