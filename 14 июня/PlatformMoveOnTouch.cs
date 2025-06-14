using UnityEngine;

public class PlatformMoveOnTouch : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset = new Vector3(0, 0, 5); // Смещение, на которое платформа будет двигаться
    [SerializeField] private float moveSpeed = 2f; // Скорость движения
    private Vector3 startPos; // Начальная позиция
    private Vector3 targetPos; // Целевая позиция
    private bool shouldMove = false; // Флаг, нужно ли двигаться

    void Start()
    {
        startPos = transform.position; // Запоминаем начальную позицию
        targetPos = startPos + moveOffset; // Вычисляем целевую позицию
    }

    void Update()
    {
        if (shouldMove) // Если нужно двигаться
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Если столкнулись с игроком
        {
            shouldMove = true; // Включаем движение
        }
    }
}
