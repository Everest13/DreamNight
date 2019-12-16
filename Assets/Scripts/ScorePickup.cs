using UnityEngine;
using UnityEngine.UI;

public class ScorePickup : MonoBehaviour
{
    GameObject player;
    PlayerManager instance;
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponentInParent<AudioSource>();
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
            audioData.Play();
            Destroy(transform.gameObject); //уничтожить поинт
    }
}
