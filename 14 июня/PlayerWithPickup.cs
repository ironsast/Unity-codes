using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class PlayerWithPickup : MonoBehaviour // Объявляем публичный класс, наследуемый от MonoBehaviour
{
    public float moveSpeed = 5f; // Переменная для задания скорости движения игрока (открыта в Inspector)
    private int itemsCollected = 0; // Переменная для хранения количества собранных предметов (только внутри скрипта)

    void Update() // Метод вызывается каждый кадр
    {
        float moveX = Input.GetAxis("Horizontal"); // Получаем ввод по горизонтали (A/D или стрелки)
        float moveZ = Input.GetAxis("Vertical");   // Получаем ввод по вертикали (W/S или стрелки)
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime; // Создаём вектор движения и масштабируем по скорости и времени
        transform.Translate(move); // Перемещаем объект игрока согласно рассчитанному вектору
    }

    private void OnTriggerEnter(Collider other) // Метод вызывается при входе в триггер-коллайдер
    {
        if (other.CompareTag("Pickup")) // Проверяем, что у объекта есть тег "Pickup"
        {
            itemsCollected++; // Увеличиваем счётчик собранных предметов
            Debug.Log("Собрано предметов: " + itemsCollected); // Выводим количество собранных предметов в консоль
            Destroy(other.gameObject); // Удаляем предмет с игровой сцены
        }
    }
}
