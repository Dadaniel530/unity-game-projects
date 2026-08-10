using UnityEngine;

public class PenguinController : MonoBehaviour
{
    public float moveSpeed = 5f; // speed of sliding
    private Rigidbody rb;
    private Vector3 input;
    private bool isSliding = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // keeps penguin upright
        rb.useGravity = false;
    }

    void Update()
    {
        // get input from arrow keys
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) vertical = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) vertical = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;

        input = new Vector3(horizontal, 0f, vertical).normalized;
    }

    void FixedUpdate()
    {
        if (input != Vector3.zero)
        {
            // move penguin using Rigidbody physics
            Vector3 move = input * moveSpeed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + move);
        }
    }
}
