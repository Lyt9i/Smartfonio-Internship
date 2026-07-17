using UnityEngine;

public class EnemySphere : MonoBehaviour
{
    [Header("Настройки врага")]
    [SerializeField] private float moveSpeed = 5f;
    
    private Transform player;
    private float fixedY; // Запоминаем начальную высоту

    void Start()
    {
        // Запоминаем начальную позицию по Y
        fixedY = transform.position.y;
        
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