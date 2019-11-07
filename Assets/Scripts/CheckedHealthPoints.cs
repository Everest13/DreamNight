using UnityEngine;

public class CheckedHealthPoints : MonoBehaviour
{
    private int fullHealthPoints = 5;

    private void Update()
    {
        int healthPoints = PlayerControl.healthPoints;

        //Проверяет число очков здоровья, отображает число сердц на шкале здоровья
        for (int i = 0; i < 5; i++) //TODO: change to fullHealthPoints
        {
            Transform heartHealth = transform.GetChild(i);
            if (i < healthPoints)
            {
                heartHealth.gameObject.SetActive(true);
                continue;
            }
            heartHealth.gameObject.SetActive(false);
        }
    }
}
