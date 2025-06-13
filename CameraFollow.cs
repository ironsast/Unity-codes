using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Цель, за которой следует камера
    public Transform target;
    // Смещение камеры относительно цели
    public Vector3 offset = new Vector3(0, 5, -10);
    // Скорость сглаживания движения камеры
    public float smoothSpeed = 5f;
    // Чувствительность мыши
    public float mouseSensitivity = 3f;
    // Текущий угол поворота
    private float currentYaw = 0f;

    void LateUpdate()
    {
        // Управление поворотом камеры мышью
        float mouseX = Input.GetAxis("Mouse X");
        currentYaw += mouseX * mouseSensitivity;

        // Если цель не назначена, ничего не делаем
        if (target == null) return;
        // Позиция камеры вокруг игрока с учетом поворота
        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;
        // Плавно перемещаем камеру к желаемой позиции
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        // Смотрим на игрока
        transform.LookAt(target.position);
    }

    // Публичный метод для получения текущего угла поворота камеры
    public float GetCurrentYaw()
    {
        return currentYaw;
    }
}
