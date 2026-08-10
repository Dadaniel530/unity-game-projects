using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public GameObject dodgeballPrefab;
    public Transform firePoint;
    public Transform player;

    public float shootForce = 20f;
    public float shootInterval = 1f;

    private float normalInterval;
    private bool isSlowed = false;

    void Start()
    {
        normalInterval = shootInterval;
        StartShooting(normalInterval);
    }

    void StartShooting(float interval)
    {
        CancelInvoke(nameof(ShootBall));
        InvokeRepeating(nameof(ShootBall), 0f, interval);
    }

    // ⏰ Called by Clock
    public void SlowFireRate(float slowMultiplier, float duration)
    {
        if (isSlowed) return;

        isSlowed = true;

        float slowedInterval = normalInterval * slowMultiplier;
        StartShooting(slowedInterval);

        Invoke(nameof(ResetFireRate), duration);
    }

    void ResetFireRate()
    {
        StartShooting(normalInterval);
        isSlowed = false;
    }

    void ShootBall()
    {
        if (player == null) return;

        GameObject ball = Instantiate(dodgeballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Aim toward player (horizontal only)
        Vector3 direction = player.position - firePoint.position;
        direction.y = 0;
        direction = direction.normalized;

        // ✅ CORRECT Rigidbody movement
        rb.linearVelocity = direction * shootForce;

        Destroy(ball, 2f);
    }
}
