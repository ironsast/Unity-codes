using UnityEngine;

public class SpherePlayerController : MonoBehaviour
{
    // Скорость перемещения
    public float moveSpeed = 5f;
    // Сила прыжка
    public float jumpForce = 7f;
    // Ссылка на Rigidbody
    private Rigidbody rb;
    // Флаг, находится ли сфера на земле
    private bool isGrounded;
    // Оригинальный масштаб сферы
    private Vector3 originalScale;
    // Минимальный масштаб по Y для squash
    public float squashAmount = 0.7f;
    // Длительность squash/stretch
    public float squashDuration = 0.1f;
    // Флаг, идет ли сейчас squash/stretch
    private bool isSquashing = false;
    // Скорость плавного изменения масштаба
    private float squashLerpSpeed = 10f;
    // Флаг прыжка
    private bool isJumping = false;
    // Целевой масштаб по Y
    private float squashTarget = 1f;
    // Переменная для хранения вращения по мыши
    private float rotationY = 0f;
    // Чувствительность мыши
    public float mouseSensitivity = 3f;
    // Флаг, крутится ли мяч в прыжке
    private bool isRolling = false;
    // Скорость вращения мяча
    public float rollSpeed = 300f;

    void Start()
    {
        // Получаем Rigidbody
        rb = GetComponent<Rigidbody>();
        // Сохраняем исходный масштаб
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Получаем ссылку на скрипт камеры
        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
        float cameraYaw = 0f;
        if (camFollow != null)
            cameraYaw = camFollow.GetCurrentYaw();
        // Получаем ввод с клавиатуры
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        // Формируем вектор движения относительно поворота камеры
        Vector3 move = Quaternion.Euler(0, cameraYaw, 0) * new Vector3(moveX, 0, moveZ) * moveSpeed;
        // Получаем текущую скорость
        Vector3 velocity = rb.velocity;
        // Обновляем скорость, сохраняя вертикальную составляющую
        rb.velocity = new Vector3(move.x, velocity.y, move.z);

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            squashTarget = 0.7f; // squash при старте прыжка
            isRolling = true; // начинаем крутить мяч
        }

        // Плавное восстановление масштаба
        float currentY = transform.localScale.y;
        float newY = Mathf.Lerp(currentY, squashTarget, Time.deltaTime * squashLerpSpeed);
        transform.localScale = new Vector3(originalScale.x, newY, originalScale.z);

        // Stretch в полёте
        if (isJumping && !Input.GetButton("Jump") && rb.velocity.y > 0.1f)
        {
            squashTarget = 1.2f; // stretch в полёте
        }
        // Возврат к норме при приземлении
        if (isGrounded && isJumping)
        {
            squashTarget = 1f;
            isJumping = false;
            isRolling = false;
        }
    }

    void FixedUpdate()
    {
        // Применяем поворот к Rigidbody для физики
        Quaternion deltaRotation = Quaternion.Euler(0, rotationY - rb.rotation.eulerAngles.y, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Реалистичное вращение мяча при движении
        if (isRolling)
        {
            // Вращаем мяч по локальной оси X (визуальный эффект)
            transform.Rotate(Vector3.right, rollSpeed * Time.fixedDeltaTime, Space.Self);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, что столкновение с землей
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            squashTarget = 0.8f; // squash при приземлении
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Проверяем, что стоим на земле
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Сфера в воздухе
        isGrounded = false;
    }
}
