using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject progressPanel;
    public GameObject rulesPanel;

    public float offset = 160f;

    public void GameOver()
    {
        gameOverPanel.GetComponent<AudioSource>().Play();
        gameOverPanel.gameObject.SetActive(true);
        progressPanel.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowRules()
    {
        rulesPanel.SetActive(true);
    }

    public void HideRules()
    {
        rulesPanel.SetActive(false);
    }
}
