﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    private float distToGround;

    public float forwardForce = 150f;
    public float sidewaysForce = 15f;
    public float maxSpeed = 8f; //TODO: алгоритм скорости в зависиости от уровня
    public float startSpeed = 2f;

    Rigidbody playerRb;
    Animator animator;
    Collider playerGPX;
    PlayerManager instance;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        playerGPX = GetComponentInChildren<Collider>();
        instance = PlayerManager.instance;

        distToGround = playerGPX.bounds.extents.y;

        playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, startSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.isDying)
            this.enabled = false;

        // Придать ускорение
        if (playerRb.velocity.z < maxSpeed)
            playerRb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.W) && isUpForce())
        {
            animator.SetTrigger("Jump");
        } else
        {
            animator.SetTrigger("Move");
        }

        // вижение вправо, влево
        if (Input.GetKey(KeyCode.D)) //If the player is pressing "d" key
        {
            playerRb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A)) //If the player is pressing "a" key
        {
            playerRb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    //проверяет расстояние до платформы
    //для допуска прыжка, чтобы не было doube jumps
    private bool isUpForce()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + .1f);
    }
}
