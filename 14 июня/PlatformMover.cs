using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class PlatformMover : MonoBehaviour // Объявляем публичный класс, наследуемый от MonoBehaviour
{
    // Две точки, между которыми будет двигаться платформа
    [SerializeField] private Transform pointA; // Первая точка движения платформы (можно задать в Inspector)
    [SerializeField] private Transform pointB; // Вторая точка движения платформы (можно задать в Inspector)
    // Скорость движения
    [SerializeField] private float speed = 2f; // Скорость движения платформы (можно задать в Inspector)
    // Текущая цель
    private Transform target; // Текущая цель, к которой движется платформа

    void Start() // Метод вызывается при запуске сцены
    {
        // Начинаем движение к точке B
        target = pointB; // В начале движения платформа направляется к точке B
    }

    void Update() // Метод вызывается каждый кадр
    {
        // Двигаем платформу к текущей цели
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Перемещаем платформу к текущей цели с заданной скоростью
        // Если достигли цели — меняем направление
        if (Vector3.Distance(transform.position, target.position) < 0.05f) // Проверяем, достигла ли платформа цели (расстояние меньше 0.05f)
        {
            // Меняем цель: если была точка A — теперь B, если была B — теперь A
            target = (target == pointA) ? pointB : pointA; // Меняем цель на противоположную
        }
    }
}
