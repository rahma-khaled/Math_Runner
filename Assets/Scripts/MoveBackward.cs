using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    public float speed = 5f;
    public float resetZ = -10f;
    public float startZ = 50f;
    public float randomXRange = 3f;

    void Update()
    {
        // نحرك العنصر للخلف
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // لو خرج من الشاشة نرجعه قدام تاني
        if (transform.position.z < resetZ)
        {
            float newX = Random.Range(-randomXRange, randomXRange);
            transform.position = new Vector3(newX, transform.position.y, startZ);
        }
    }
}
