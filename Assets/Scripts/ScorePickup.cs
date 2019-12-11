using UnityEngine;
using UnityEngine.UI;

public class ScorePickup : MonoBehaviour
{
    public Text checkedScores;

    GameObject player;
    PlayerManager instance;

    void Start()
    {
        instance = PlayerManager.instance;
        player = instance.player;
    }

    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == player.tag)
        {
            PickUp();
        }
    }

    void PickUp()
    {
        bool wasPickedUp = instance.AddCurrentScore();

        checkedScores.text = "scores: " + PlayerManager.currentScores; //отобразить очки на панели сверху TODO: вынести в скрипт элемента панели

        if (wasPickedUp == true)
            Destroy(transform.gameObject); //уничтожить поинт
    }


}
