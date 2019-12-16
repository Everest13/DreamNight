using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject progressPanel;

    public float offset = 160f;

    public void GameOver()
    {
        Debug.Log("Game over");

        gameOverPanel.GetComponent<AudioSource>().Play();
        gameOverPanel.gameObject.SetActive(true);
        progressPanel.gameObject.SetActive(false);
    }

    public void StartGame()
    {

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
