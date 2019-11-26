using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject healthPointsParent;
    public Text showCurrentScores;

    List<Transform> HealthPoints = new List<Transform>();

    void Start()
    {
        // healthPointsParent?.GetComponentsInChildren<Transform>(true, HealthPoints); get 16 transform

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
        showCurrentScores.text = "points: " + PlayerManager.currentScores;
    }
}
