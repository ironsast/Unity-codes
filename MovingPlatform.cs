using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Точка A (начальная позиция)
    public Vector3 pointA;
    // Точка B (конечная позиция)
    public Vector3 pointB;
    // Скорость движения платформы
    public float speed = 2f;
    // Флаг направления движения
    private bool movingToB = true;

    void Update()
    {
        // Двигаемся к точке B или A
        if (movingToB)
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);

        // Меняем направление, если достигли точки
        if (Vector3.Distance(transform.position, pointA) < 0.1f) movingToB = true;
        if (Vector3.Distance(transform.position, pointB) < 0.1f) movingToB = false;
    }
}
