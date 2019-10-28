using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private void Start()
    {
        offset = player.transform.position - transform.position;
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
