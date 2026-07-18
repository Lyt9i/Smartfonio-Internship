using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 targetDirection = Vector3.zero;
    private bool isMoving = false;
    private bool isFirstPress = true;

    void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    // Метод для поворота
    private void HandleRotation()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Если есть ввод
        if (inputDirection != Vector3.zero)
        {
            // Если направление изменилось
            if (targetDirection != inputDirection)
            {
                // Резкий поворот в нужную сторону
                targetDirection = inputDirection;
                transform.rotation = Quaternion.LookRotation(targetDirection);
                isMoving = false; // Сбрасываем движение
                isFirstPress = true;
            }
            else if (isFirstPress)
            {
                // Если нажали ту же клавишу - разрешаем движение
                isMoving = true;
                isFirstPress = false;
            }
        }
        else
        {
            // Если отпустили клавиши - останавливаем движение
            isMoving = false;
            isFirstPress = true;
        }
    }

    // Метод для ходьбы
    private void HandleMovement()
    {
        // Движение только если isMoving = true и есть направление
        if (isMoving && targetDirection != Vector3.zero)
        {
            transform.Translate(targetDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}