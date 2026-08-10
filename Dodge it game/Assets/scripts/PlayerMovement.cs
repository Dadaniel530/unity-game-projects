using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.WakeUp();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // ← →
        float moveZ = Input.GetAxisRaw("Vertical");   // ↑ ↓

        // Move on X and Z, keep Y controlled by physics
        rb.linearVelocity = new Vector3(
            -moveX * moveSpeed,   // left/right (inverted like you had)
            rb.linearVelocity.y,        // keep gravity
            moveZ * moveSpeed     // up/down
        );
    }
}
