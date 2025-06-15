using UnityEngine; // Подключаем пространство имён UnityEngine для работы с Unity API

public class DisappearOnKey : MonoBehaviour // Класс для исчезновения объекта по нажатию клавиши
{
    [SerializeField] private KeyCode key = KeyCode.E; // Клавиша для исчезновения

    void Update() // Каждый кадр
    {
        if (Input.GetKeyDown(key)) // Если нажата нужная клавиша
        {
            gameObject.SetActive(false); // Делаем объект неактивным (исчезает)
        }
    }
}
