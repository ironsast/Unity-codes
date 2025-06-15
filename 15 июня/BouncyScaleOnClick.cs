using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class BouncyScaleOnClick : MonoBehaviour // Класс для увеличения объекта при клике
{
    private Vector3 originalScale; // Сохраняем исходный масштаб
    [SerializeField] private float scaleFactor = 1.5f; // Во сколько раз увеличивать
    [SerializeField] private float bounceTime = 0.2f; // Время анимации
    private bool isBouncing = false; // Флаг анимации

    void Start() // Вызывается при запуске
    {
        originalScale = transform.localScale; // Сохраняем исходный масштаб
    }

    void OnMouseDown() // Срабатывает при клике мышкой по объекту
    {
        if (!isBouncing) // Если не идёт анимация
            StartCoroutine(Bounce()); // Запускаем анимацию
    }

    private System.Collections.IEnumerator Bounce() // Корутина для анимации
    {
        isBouncing = true; // Включаем флаг
        transform.localScale = originalScale * scaleFactor; // Увеличиваем масштаб
        yield return new WaitForSeconds(bounceTime); // Ждём заданное время
        transform.localScale = originalScale; // Возвращаем исходный масштаб
        isBouncing = false; // Снимаем флаг
    }
}
