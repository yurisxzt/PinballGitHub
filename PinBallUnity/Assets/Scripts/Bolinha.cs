using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OutZone"))
        {
            transform.position = startPos;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}