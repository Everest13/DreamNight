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
    CheckHealthPoints healhPointsPanel;
    CurrentScoresUI currentScoresPanel;

    public static int currentScores = 0;
    public static int finalScores = 0;
    //очки здоровья
    public static int healthPoints = 5;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        healhPointsPanel = GetComponent<CheckHealthPoints>();
        currentScoresPanel = GetComponent<CurrentScoresUI>();

        currentScores = 0;
        healthPoints = 5;
    }

    void Update()
    {
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
            healhPointsPanel.OnUpdateHealthPanel();
            return true;
        }
        return false;
    }

    public bool AddPlayerHealthPoint()
    {
        healthPoints++;
        healhPointsPanel.OnUpdateHealthPanel();
        return true;
    }

    public bool TakeCurrentScore()
    {
        if (currentScores > 0)
        {
            currentScores--;
            currentScoresPanel.OnUpdateCurrentScore();
            return true;
        }
            
        return false;
    }

    public bool AddCurrentScore()
    {
        currentScores++;
        currentScoresPanel.OnUpdateCurrentScore();
        return true;
    }
}
