using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class ColorLerpOnHover : MonoBehaviour // Класс для плавной смены цвета при наведении мыши
{
    [SerializeField] private Color targetColor = Color.green; // Цвет при наведении
    [SerializeField] private float lerpSpeed = 5f; // Скорость смены цвета
    private Color originalColor; // Исходный цвет
    private Renderer rend; // Ссылка на Renderer
    private bool isHover = false; // Флаг наведения

    void Start() // Вызывается при запуске
    {
        rend = GetComponent<Renderer>(); // Получаем Renderer
        originalColor = rend.material.color; // Сохраняем исходный цвет
    }

    void OnMouseEnter() // Навели мышь
    {
        isHover = true; // Включаем флаг
    }

    void OnMouseExit() // Убрали мышь
    {
        isHover = false; // Выключаем флаг
    }

    void Update() // Каждый кадр
    {
        // Плавно меняем цвет к целевому или исходному
        Color target = isHover ? targetColor : originalColor;
        rend.material.color = Color.Lerp(rend.material.color, target, Time.deltaTime * lerpSpeed);
    }
}
