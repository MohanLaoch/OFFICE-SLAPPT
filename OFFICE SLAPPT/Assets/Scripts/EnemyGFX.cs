using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-0.11f, 0.11f, 0.11f);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
        }
    }
}
