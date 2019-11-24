using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    PlayerManager instance;

    public float speed = 1f;

    public float radius = 15f;

    private void Start()
    {
        instance = PlayerManager.instance;
        target = instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
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
