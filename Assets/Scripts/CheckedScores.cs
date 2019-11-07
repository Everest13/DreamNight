using UnityEngine;
using UnityEngine.UI;

public class CheckedScores : MonoBehaviour
{
    public GameObject player;
    public Text checkedScores; 

    //Добавляет поинт в текущий счет игрока, уничтожает Poins
    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == player.tag)
        {
            GameManager.currentScores += 1;
            Debug.Log(GameManager.currentScores);
            checkedScores.text = "scores: " + GameManager.currentScores; //отобразить очки на панели сверху
            Destroy(transform.gameObject); //уничтожить поинт
        }
    }

}
