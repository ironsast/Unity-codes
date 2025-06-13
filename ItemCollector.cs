using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // Счетчик собранных предметов
    public int itemsCollected = 0;

    // Срабатывает при входе в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что у объекта есть тег "Pickup"
        if (other.CompareTag("Pickup"))
        {
            itemsCollected++; // Увеличиваем счетчик
            Destroy(other.gameObject); // Удаляем предмет
        }
    }
}
