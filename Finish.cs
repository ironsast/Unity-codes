using UnityEngine;

public class Finish : MonoBehaviour
{
    // Срабатывает при входе в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что это игрок
        if (other.CompareTag("Player"))
        {
            Debug.Log("Level Complete!"); // Сообщение о завершении уровня
            // Здесь можно вызвать переход на следующий уровень через LevelManager
        }
    }
}
