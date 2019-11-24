using UnityEngine;

public class PassiveEnemyController : Interactable
{
    public override float radius { get => 3; set => radius = value; }

    PlayerManager instance;

    void Start()
    {
        instance = PlayerManager.instance;
    }

    public override void Interacte()
    {
        base.Interacte();

        PassiveAttack();

        //Уничтожить passive enemy
        Destroy(transform.gameObject);
    }

    void PassiveAttack()
    {
        instance.TakePlayerHealthPoint();
    }
}
