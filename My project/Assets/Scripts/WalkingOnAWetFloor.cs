using UnityEngine;

public class WalkingOnAWetFloor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Vector3 targetDirection = Vector3.zero;
    private bool isMoving = false;

    void Update()
    {
        // Получаем ввод
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Определяем направление
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Если есть ввод
        if (inputDirection != Vector3.zero)
        {
            // Если это новое направление (не совпадает с текущим)
            if (targetDirection != inputDirection)
            {
                // Резкий поворот в нужную сторону
                targetDirection = inputDirection;
                transform.rotation = Quaternion.LookRotation(targetDirection);
                isMoving = false; // Сбрасываем движение
            }
            else
            {
                // Если нажали ту же клавишу повторно - начинаем движение
                isMoving = true;
            }
        }

        // Движение
        if (isMoving && targetDirection != Vector3.zero)
        {
            transform.Translate(targetDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}