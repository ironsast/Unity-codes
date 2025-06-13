using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        Vector3 direction = new Vector3(h, 0, v);// x y z
        transform.Translate(direction * speed * Time.deltaTime);
    }
}