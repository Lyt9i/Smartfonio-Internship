using UnityEngine;

public class EnemyConect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject gameManagerObj = GameObject.Find("GameManager");
            if (gameManagerObj != null)
            {
                GameManager gameManager = gameManagerObj.GetComponent<GameManager>();
                if (gameManager != null)
                {
                    // Уменьшаем здоровье игрока на 1
                    gameManager.TakeDamage(1);
                    Debug.Log("Игрок столкнулся с врагом! Здоровье уменьшено на 1.");
                }
                else
                {
                    Debug.LogError("Компонент GameManager не найден на объекте GameManager!");
                }
            }
            else
            {
                Debug.LogError("Объект GameManager не найден в сцене!");
            }
        }
    }
}
