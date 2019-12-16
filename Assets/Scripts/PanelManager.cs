using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    #region Singletone

    public static PanelManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject healthPointsParent;
    public GameObject scoresPanel;

    Text currentScoresUI;

    List<Transform> HealthPoints = new List<Transform>();

    AudioSource audioTakeHealth;
    AudioSource audioTakeScore;

    void Start()
    {
        currentScoresUI = scoresPanel.GetComponentInChildren<Text>();
        audioTakeScore = scoresPanel.GetComponent<AudioSource>();
        audioTakeHealth = healthPointsParent.GetComponent<AudioSource>();

        for (int i = 0; i < healthPointsParent.transform.childCount; i++)
        {
            HealthPoints.Add(healthPointsParent.transform.GetChild(i));
        }
    }

    public void OnUpdateHealthPanel()
    {
        audioTakeHealth.Play();

        if (HealthPoints != null)
        {
            foreach (Transform healthPoint in HealthPoints)
            {
                if (HealthPoints.IndexOf(healthPoint) < PlayerManager.healthPoints)
                {
                    healthPoint.gameObject.SetActive(true);
                }
                else
                {
                    healthPoint.gameObject.SetActive(false);
                }
            }
        }
    }

    public void OnUpdateCurrentScore()
    {
        audioTakeScore.Play();
        currentScoresUI.text = "points: " + PlayerManager.currentScores;
    }
}
