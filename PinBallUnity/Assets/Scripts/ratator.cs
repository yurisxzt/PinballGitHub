using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 90f; // graus por segundo

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}