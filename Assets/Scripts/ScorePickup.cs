using UnityEngine;
using UnityEngine.UI;

public class ScorePickup : Interactable
{
    public Text checkedScores;

    public override float radius { get => 3; set => radius = value; }

    PlayerManager instance;

    void Start()
    {
        instance = PlayerManager.instance;
    }

    public override void Interacte()
    {
        base.Interacte();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up score");
        bool wasPickedUp = instance.AddCurrentScore();

        checkedScores.text = "scores: " + PlayerManager.currentScores; //отобразить очки на панели сверху TODO: вынести в скрипт элемента панели

        if (wasPickedUp == true)
            Destroy(transform.gameObject); //уничтожить поинт
    }

}
