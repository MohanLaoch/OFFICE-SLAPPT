using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D enemyRigidBody;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        enemyRigidBody = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(enemyRigidBody.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(enemyRigidBody.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - enemyRigidBody.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        enemyRigidBody.AddForce(force);

        float distance = Vector2.Distance(enemyRigidBody.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (enemyRigidBody.velocity.x >= 0.01f && force.x > 0f)
        {
            enemyGFX.localScale = new Vector3(-0.11f, 0.11f, 0.11f);
        }
        else if (enemyRigidBody.velocity.x <= -0.01 && force.x < 0f)
        {
            enemyGFX.localScale = new Vector3(0.11f, 0.11f, 0.11f);
        }
    }
}
