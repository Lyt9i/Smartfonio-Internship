using UnityEngine;

public class CheeseContact : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle cheese collection logic here
            Debug.Log("Cheese collected!");
            Destroy(gameObject); // Remove the cheese from the scene
        }
    }
}
