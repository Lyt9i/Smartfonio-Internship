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
    [SerializeField] public GameObject loseGameCanvas;
    [SerializeField] public GameObject endGameCanvas;

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
            loseGame();
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
    public void ResetGame()
    {
        Debug.Log("Игра окончена!");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void loseGame()
    {
        Time.timeScale = 0f;
        if (loseGameCanvas != null)
        {
            loseGameCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("Канвас не найден!");
        }
    }
    public void endGame()
    {
        Time.timeScale = 0f;
        if (endGameCanvas != null)
        {
            endGameCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("Канвас не найден!");
        }
    }


}
