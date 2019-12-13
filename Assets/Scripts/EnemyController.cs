using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : AbstractEnemyController
{
    Transform player;
    NavMeshAgent agent;
    PlayerManager instance;
    Animator animator;

    private void Start()
    {
        instance = PlayerManager.instance;
        player = instance.player.transform;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        float moveRadius = radius / distance;

        animator.SetFloat("checkState", moveRadius);

        if (distance < radius)
        {
            agent.speed = moveSpeed;
            agent.SetDestination(player.position);
            FaceTarget();

            if (distance < attackRadius)
                OnAttack();
        }
    }

    void OnAttack()
    {
        // take scores from player
        instance.TakeCurrentScore();
    }


    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
