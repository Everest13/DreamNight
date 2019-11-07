using UnityEngine;

public class PassiveEnemyControl : MonoBehaviour
{
    public GameObject player;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == player.tag)
        {
            //Уничтожить passive enemy
            Destroy(transform.gameObject);
            //Игрок теряет очко здоровья
            PlayerControl.healthPoints -= 1;

            if (PlayerControl.healthPoints == 0)
            {
                gameManager.GameOver();
            }
        }
    }
}
