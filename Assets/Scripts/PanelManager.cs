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
    public Text currentScoresUI;

    List<Transform> HealthPoints = new List<Transform>();

    void Start()
    {
        for (int i = 0; i < healthPointsParent.transform.childCount; i++)
        {
            HealthPoints.Add(healthPointsParent.transform.GetChild(i));
        }
    }

    public void OnUpdateHealthPanel()
    {
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
        currentScoresUI.text = "points: " + PlayerManager.currentScores;
    }
}
