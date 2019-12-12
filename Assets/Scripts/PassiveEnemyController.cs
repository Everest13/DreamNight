using UnityEngine;

public class PassiveEnemyController : MonoBehaviour
{
    public float radius = 1f;
    bool hasInteracted = false;

    PlayerManager instance;
    Transform player;
    Transform enemy;

    void Start()
    {
        instance = PlayerManager.instance;
        player = PlayerManager.instance.player.transform;
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, enemy.position);

        if (distance <= radius && !hasInteracted)
        {
            PassiveAttack();
            hasInteracted = true;
        }
    }

    void PassiveAttack()
    {
        instance.TakePlayerHealthPoint();
        Destroy(transform.gameObject);
    }


}
