using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    AudioSource audioSource;
    AudioClip clip;

    private void Start()
    {
        offset = player.transform.position - transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Camera follow to player
    void Update()
    {
        transform.position = player.transform.position - offset;
    }

    //Установить вид камеры сверху на финише
    void ViewFromAbove()
    {

    }
}
