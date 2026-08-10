using UnityEngine;

public class SlidingIceCube2 : MonoBehaviour
{
    public float moveDistance = 2f;        // how far it slides up/down
    public float speed = 2f;               // how fast it moves
    public float wallCheckDistance = 0.5f; // ray distance to detect walls

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move cube along the Z axis (forward/back = up/down in top view)
        transform.position += Vector3.forward * speed * Time.deltaTime * direction;

        // Reverse direction if hitting a wall in front or behind
        if (Physics.Raycast(transform.position, Vector3.forward * direction, wallCheckDistance))
        {
            direction *= -1;
        }

        // Reverse if distance exceeded (prevents drifting too far)
        if (Vector3.Distance(startPos, transform.position) >= moveDistance)
        {
            direction *= -1;
        }
    }
}
