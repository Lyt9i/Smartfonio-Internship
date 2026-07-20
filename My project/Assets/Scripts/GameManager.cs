using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [Header("Настройки игрока")]
    [SerializeField]private int score = 0;
    [SerializeField]private int health = 3;
    [SerializeField]private int cheese = 3;
    private Text liveTrackerText;
    void Start()
    {
        // Автоматически находим LiveTracker
        GameObject liveTrackerObj = GameObject.Find("LiveTracker");
        if (liveTrackerObj != null)
        {
            liveTrackerText = liveTrackerObj.GetComponent<Text>();
            if (liveTrackerText == null)
            {
                liveTrackerText = liveTrackerObj.GetComponentInChildren<Text>();
            }
        }
        
        UpdateUI();
    }
    public void TakeDamage(int damage)
    {

        health -= damage;
        Debug.Log("Здоровье игрока: " + health);
        if (health <= 0)
        {
            Debug.Log("Игра окончена!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void UpdateUI()
    {
        if (liveTrackerText != null)
        {
            liveTrackerText.text = $"Жизни: {health}";
        }
    }


}
