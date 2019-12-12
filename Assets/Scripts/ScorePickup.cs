using UnityEngine;
using UnityEngine.UI;

public class ScorePickup : MonoBehaviour
{
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

        if (wasPickedUp == true)
            Destroy(transform.gameObject); //уничтожить поинт
    }


}
