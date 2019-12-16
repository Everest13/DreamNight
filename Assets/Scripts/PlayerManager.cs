using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour //TODO: по хорошему вынести логику работы с аниматором(AnimatorController?) и rigitbody
{
    #region Singletone

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public bool isDying = false;

    GameManager gameManager;
    PanelManager panelManager;
    Animator animator;
    Rigidbody playerRb;

    public static int currentScores = 0;
    public static int finalScores = 0;
    //очки здоровья
    public static int healthPoints = 5;

    void Start()
    {
        panelManager = GetComponent<PanelManager>();
        gameManager = GetComponent<GameManager>();
        animator = player.GetComponentInChildren<Animator>();
        playerRb = player.GetComponent<Rigidbody>();
        isDying = false;

        currentScores = 0;
        healthPoints = 5;
    }

    void Update()
    {
        if (healthPoints <= 0 && !isDying)
        {
            Die();
        }
    }

    public void Die()
    {
        finalScores += currentScores;
        animator.SetTrigger("Die");
        playerRb.velocity = Vector3.zero;
        isDying = true;
        player.GetComponent<AudioSource>().Stop();

        gameManager.GameOver();
    }


    //TODO: что-то придумать с логикой обработки понтов
    public bool TakePlayerHealthPoint()
    {
        if (healthPoints > 0)
        {
            healthPoints--;
            panelManager.OnUpdateHealthPanel();
            return true;
        }
        return false;
    }

    public bool AddPlayerHealthPoint()
    {
        healthPoints++;
        panelManager.OnUpdateHealthPanel();
        return true;
    }

    public bool TakeCurrentScore()
    {
        if (currentScores > 0)
        {
            currentScores--;
            panelManager.OnUpdateCurrentScore();
            return true;
        }
            
        return false;
    }

    public bool AddCurrentScore()
    {
        currentScores++;
        panelManager.OnUpdateCurrentScore();
        return true;
    }
}
