using UnityEngine;
using System.Collections.Generic;

public class CheckHealthPoints : MonoBehaviour
{
    List<GameObject> HealthPoints = new List<GameObject>();

    void Start()
    {
        GetComponentsInChildren<GameObject>(true, HealthPoints);
    }

    public void OnUpdateHealthPanel()
    {
        if (HealthPoints != null)
        {
            foreach (GameObject healthPoint in HealthPoints)
            {
                if (HealthPoints.IndexOf(healthPoint) < PlayerManager.healthPoints)
                {
                    healthPoint.SetActive(true);
                }
                else
                {
                    healthPoint.SetActive(false);
                }
            }
        }

    }
}
