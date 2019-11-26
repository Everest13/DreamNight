using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject progressPanel;

    public float offset = 160f;

    Transform player;

    private void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    public void GameOver()
    {
        Debug.Log("Game over");

        gameOverPanel.transform.position = new Vector3(gameOverPanel.transform.position.x, gameOverPanel.transform.position.y, player.position.z + offset);
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
