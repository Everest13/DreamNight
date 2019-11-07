using UnityEngine;
using UnityEngine.UI;

public class FinalScoresUI : MonoBehaviour
{
    public Text pointsText;

    // Отобразить на GameOver panel число конечных поинтов
    void Start()
    {
        pointsText.text = "POINTS: " + GameManager.finalScores;
    }
}
