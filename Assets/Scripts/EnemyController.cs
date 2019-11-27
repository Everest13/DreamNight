using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : AbstractEnemyController
{
    Transform target;
    NavMeshAgent agent;
    PlayerManager instance;

    private void Start()
    {
        instance = PlayerManager.instance;
        agent = GetComponent<NavMeshAgent>();
        target = instance.player.transform;

    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < radius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
            OnAttack();
        }
        else
        {
            agent.isStopped = true;
        }
        
    }

    void OnAttack()
    {
        // take scores from player
        instance.TakeCurrentScore();
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
