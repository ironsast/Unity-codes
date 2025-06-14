using UnityEngine;

public class ColorChangeOnApproach : MonoBehaviour
{
    [SerializeField] private Transform player; // Ссылка на игрока
    [SerializeField] private float changeDistance = 3f; // Дистанция, на которой меняется цвет
    [SerializeField] private Color nearColor = Color.red; // Цвет при приближении
    [SerializeField] private Color farColor = Color.white; // Цвет по умолчанию
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>(); // Получаем компонент Renderer
        rend.material.color = farColor; // Устанавливаем начальный цвет
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position); // Считаем расстояние до игрока
        if (distance < changeDistance) // Если игрок близко
        {
            rend.material.color = nearColor; // Меняем цвет на заданный
        }
        else // Если игрок далеко
        {
            rend.material.color = farColor; // Возвращаем исходный цвет
        }
    }
}
