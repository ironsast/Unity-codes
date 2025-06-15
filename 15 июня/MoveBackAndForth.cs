using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class MoveBackAndForth : MonoBehaviour // Класс для движения объекта туда-обратно
{
    [SerializeField] private Vector3 pointA = new Vector3(0,0,0); // Первая точка
    [SerializeField] private Vector3 pointB = new Vector3(0,0,5); // Вторая точка
    [SerializeField] private float speed = 2f; // Скорость движения
    private Vector3 target; // Текущая цель

    void Start() // При запуске
    {
        target = pointB; // Начинаем движение к точке B
    }

    void Update() // Каждый кадр
    {
        // Двигаем объект к цели
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // Если достигли цели — меняем направление
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = (target == pointA) ? pointB : pointA; // Меняем цель
        }
    }
}
