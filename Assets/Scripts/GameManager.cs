using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int currentScores = 0;
    public static int finalScores = 0;

    public GameObject gameOverPanel;
    public GameObject progressPanel;

    private void Start()
    {
        currentScores = 0;
    }

    public void GameOver()
    {
        //game over sound
        //call gameover window with restart level button (try again)
        finalScores += currentScores;
        gameOverPanel.gameObject.SetActive(true);
        progressPanel.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
