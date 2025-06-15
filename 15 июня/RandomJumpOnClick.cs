using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class RandomJumpOnClick : MonoBehaviour // Класс для случайного прыжка объекта при клике
{
    [SerializeField] private float minJump = 3f; // Минимальная сила прыжка
    [SerializeField] private float maxJump = 8f; // Максимальная сила прыжка
    private Rigidbody rb; // Ссылка на Rigidbody

    void Start() // Вызывается при запуске
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
    }

    void OnMouseDown() // Срабатывает при клике мышкой по объекту
    {
        float jumpForce = Random.Range(minJump, maxJump); // Выбираем случайную силу прыжка
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Применяем силу вверх
    }
}
