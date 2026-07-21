using Unity.VisualScripting;
using UnityEngine;

public class CheeseContact : MonoBehaviour
{
    // Проверка
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("OnCheeseCollected", SendMessageOptions.DontRequireReceiver);
            Debug.Log("Cheese collected!");
            Debug.Log(" Сообщение отправлено в CubeMovement: OnCheeseCollected");
            Destroy(gameObject); 
            
            GameObject gameManagerObj = GameObject.Find("GameManager");
            if (gameManagerObj != null)
            {
                GameManager gameManager = gameManagerObj.GetComponent<GameManager>();
                if (gameManager != null)
                {
                    // Уменьшаем здоровье игрока на 1
                    gameManager.CollectCheese();
                    Debug.Log("Игрок собрал сыр! Сыр собран.");
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
