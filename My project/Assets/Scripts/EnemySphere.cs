using UnityEngine;

public class EnemySphere : MonoBehaviour
{
    [Header("Настройки врага")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float enemySize = 5f;
    
    [Header("Компоненты")]
    [SerializeField] private GameObject sprite;
    
    private Transform player;
    private float fixedY;

    void Start()
    {
        // Запоминаем начальную позицию по Y
        fixedY = transform.position.y;
        
        // Если sprite не назначен, ищем его в дочерних объектах
        if (sprite == null)
        {
            // Ищем SpriteRenderer в дочерних объектах
            SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
            if (renderer != null)
            {
                sprite = renderer.gameObject;
                Debug.Log("Спрайт найден автоматически: " + sprite.name);
            }
            else
            {
                Debug.LogError("Не найден SpriteRenderer ни на объекте, ни на его детях! Добавьте компонент SpriteRenderer.");
                enabled = false;
                return;
            }
        }
        
        // Применяем размер
        sprite.transform.localScale = new Vector3(enemySize, enemySize, enemySize);
        
        // Поиск игрока
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Не найден объект с тегом 'Player'! Добавьте тег к игроку.");
            enabled = false;
        }
    }

    void Update()
    {
        if (player == null) return;

        // Двигаемся к игроку, но фиксируем Y
        Vector3 targetPos = new Vector3(player.position.x, fixedY, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}