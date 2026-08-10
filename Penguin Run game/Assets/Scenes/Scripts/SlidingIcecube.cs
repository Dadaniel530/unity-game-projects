using UnityEngine;

public class SlidingIceCube : MonoBehaviour
{
    public float moveDistance = 2f;  // how far it slides
    public float speed = 2f;         // how fast it moves
    public float wallCheckDistance = 0.5f; // ray distance to detect walls

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move cube along the X axis
        transform.position += Vector3.right * speed * Time.deltaTime * direction;

        // Reverse direction if hitting a wall
        if (Physics.Raycast(transform.position, Vector3.right * direction, wallCheckDistance))
        {
            direction *= -1;
        }

        // Reverse if distance exceeded (to prevent drifting out of bounds)
        if (Vector3.Distance(startPos, transform.position) >= moveDistance)
        {
            direction *= -1;
        }
    }
}
