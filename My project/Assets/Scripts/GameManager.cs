using TMPro;
using UnityEditor.Animations;
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
    [SerializeField] public TMP_Text liveTrackerText;
    [SerializeField] public TMP_Text cheeseTrackerText;
    [SerializeField] public Animator animator;

    void Start()
    {
        UpdateLiveUI();
        UpdateCheeseUI();
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
        UpdateLiveUI();
    }
    private void UpdateLiveUI()
    {
        if (liveTrackerText != null)
        {
            liveTrackerText.text = $"Жизней осталось: {health}";
        }
    }
    private void UpdateCheeseUI()
    {
        if (cheeseTrackerText != null)
        {
            cheeseTrackerText.text = $"Сыра осталось собрать: {cheese}";
        }
    }
    public void CollectCheese()
    {
        cheese -= 1;
        Debug.Log("Собрано сыра: " + cheese);
        UpdateCheeseUI();
        if (cheese <= 0)
        {
            Debug.Log("Вы собрали весь сыр!");
            animator.SetBool("AllCheeseColected",true);
        }
    }



}
