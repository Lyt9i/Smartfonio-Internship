using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 targetDirection = Vector3.zero;
    private bool isMoving = false;
    private bool isFirstPress = true;
    private Animator modelAnimator;

    void Start()
    {
        modelAnimator = GetComponentInChildren<Animator>();
        if (modelAnimator == null)
        {
            Debug.LogError("Animator not found in children of " + gameObject.name);
        }
    }
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
                if(modelAnimator != null)    
                {
                    modelAnimator.SetBool("isMoving", isMoving);
                }
                isFirstPress = true;
            }
            else if (isFirstPress)
            {
                // Если нажали ту же клавишу - разрешаем движение
                isMoving = true;
                if(modelAnimator != null)
                {
                    modelAnimator.SetBool("isMoving", isMoving);
                }
                isFirstPress = false;
            }
        }
        else
        {
            // Если отпустили клавиши - останавливаем движение
            isMoving = false;
            if(modelAnimator != null)
            {
                modelAnimator.SetBool("isMoving", isMoving);
            }
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