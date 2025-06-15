using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class SimpleFollow : MonoBehaviour // Класс для простого следования за целью
{
    [SerializeField] private Transform target; // Цель для следования
    [SerializeField] private float speed = 3f; // Скорость следования

    void Update() // Каждый кадр
    {
        if (target != null) // Если цель назначена
        {
            // Двигаем объект к цели
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
