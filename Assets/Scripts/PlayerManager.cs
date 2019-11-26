using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singletone

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    GameManager gameManager;
    PanelManager panelManager;

    public static int currentScores = 0;
    public static int finalScores = 0;
    //очки здоровья
    public static int healthPoints = 5;

    void Start()
    {
        panelManager = GetComponent<PanelManager>();
        gameManager = GetComponent<GameManager>();

        currentScores = 0;
        healthPoints = 5;
    }

    void Update()
    {
        Debug.Log(healthPoints);

        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        finalScores += currentScores;
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
