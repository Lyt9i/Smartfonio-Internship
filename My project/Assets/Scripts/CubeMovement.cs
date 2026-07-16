using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        // Получаем ввод с клавиатуры
        float horizontal = Input.GetAxis("Horizontal"); // Стрелки влево/вправо или A/D
        float vertical = Input.GetAxis("Vertical");     // Стрелки вверх/вниз или W/S

        // Вариант 1: Движение в мировых координатах
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Вариант 2: Движение в локальных координатах (относительно поворота куба)
        // transform.Translate(horizontal * moveSpeed * Time.deltaTime, 0, vertical * moveSpeed * Time.deltaTime);

        // Вариант 3: Поворот куба вместо движения
        // float rotation = horizontal * rotationSpeed * Time.deltaTime;
        // transform.Rotate(0, rotation, 0);
    }
}
