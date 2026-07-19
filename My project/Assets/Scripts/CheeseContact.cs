using Unity.VisualScripting;
using UnityEngine;

public class CheeseContact : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("OnCheeseCollected", SendMessageOptions.DontRequireReceiver);
            Debug.Log("Cheese collected!");
            Debug.Log(" Сообщение отправлено в CubeMovement: OnCheeseCollected");
            Destroy(gameObject); 
        }
    }
}
