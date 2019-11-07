using UnityEngine.UI;
using UnityEngine;

public class IndicateCurrentPoints : MonoBehaviour
{
    void Update()
    {
        Text pointText = transform.gameObject.GetComponentInChildren<Text>();
        pointText.text = "points: " + GameManager.currentScores;
    }
}
