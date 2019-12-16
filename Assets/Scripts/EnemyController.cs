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
    AudioSource audioData;

    private float attackRadius = 2f;
    private Vector3 offset = new Vector3(4f, 4f, 4f);

    private void Start()
    {
        instance = PlayerManager.instance;
        player = instance.player.transform;
        audioData = GetComponent<AudioSource>();
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
            if (!audioData.isPlaying)
                PlayAudioData(moveRadius);

            agent.speed = moveSpeed;
            agent.SetDestination(player.position);
            FaceTarget();

            if (distance < attackRadius)
                OnAttack();
        }
        else
        {
            if (audioData.isPlaying)
                audioData.Stop();
        }
    }

    void OnAttack()
    {
        // take scores from player
        instance.TakeCurrentScore();
        agent.SetDestination(player.position - offset);
    }

    private void PlayAudioData(float moveRadius)
    {
        audioData.pitch = Random.Range(0.6f, 1f);
        audioData.volume = moveRadius * .1f;
        audioData.Play();
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
