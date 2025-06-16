using UnityEngine;

public class SimpleItemCollector : MonoBehaviour
{
    [SerializeField] private string pickupTag = "Pickup"; // Тег предметов для подбора
    private int itemsCollected = 0; // Счётчик собранных предметов

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что у объекта есть нужный тег
        if (other.CompareTag(pickupTag))
        {
            itemsCollected++; // Увеличиваем счётчик
            Debug.Log($"Собрано предметов: {itemsCollected}"); // Выводим в консоль
            Destroy(other.gameObject); // Удаляем предмет
        }
    }
}
