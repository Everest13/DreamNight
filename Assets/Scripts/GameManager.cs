using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject progressPanel;

    private void Start()
    {
    }

    public void GameOver()
    {
        //game over sound
        //call gameover window with restart level button (try again)
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
