using UnityEngine.UI;
using UnityEngine;

public class CurrentScoresUI : MonoBehaviour
{
    Text pointText;

    void Start()
    {
        pointText = GetComponent<Text>();
    }

    public void OnUpdateCurrentScore()
    {
        pointText.text = "points: " + PlayerManager.currentScores;
    }
}
