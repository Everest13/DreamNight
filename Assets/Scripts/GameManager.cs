using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject progressPanel;

    public float offset = 160f;

    private void Start()
    {
    }

    public void GameOver()
    {
        Debug.Log("Game over");

        gameOverPanel.gameObject.SetActive(true);
        progressPanel.gameObject.SetActive(false);

        //game over sound
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
