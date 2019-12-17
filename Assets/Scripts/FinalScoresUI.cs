using UnityEngine;
using UnityEngine.UI;

public class FinalScoresUI : MonoBehaviour
{
    Text pointsText;

    // Отобразить на GameOver panel число конечных поинтов
    void Start()
    {
        pointsText = GetComponent<Text>();
        pointsText.text = "POINTS: " + PlayerManager.finalScores;
        Debug.Log(pointsText.text);
    }
}
