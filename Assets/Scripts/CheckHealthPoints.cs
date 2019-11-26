using UnityEngine;
using System.Collections.Generic;

public class CheckHealthPoints : MonoBehaviour
{
    List<Transform> HealthPoints = new List<Transform>();

    void Start()
    {
        GetComponentsInChildren<Transform>(true, HealthPoints);
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
}
