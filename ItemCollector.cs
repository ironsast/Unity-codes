using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // Счетчик собранных предметов (можно убрать, если не нужен)
    public int itemsCollected = 0;

    // Этот метод вызывается, когда объект с этим скриптом входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что у объекта есть тег "Pickup"
        if (other.CompareTag("Coin"))
        {
            // Можно добавить логику: увеличить счетчик, воспроизвести звук и т.д.
            itemsCollected += 1; //itemsCollected ++;
            Debug.Log("Предмет собран! Всего предметов: " + itemsCollected);
            // Удаляем предмет с сцены
            Destroy(other.gameObject);
        }
    }
    
}
