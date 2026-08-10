using UnityEngine;

public class ClockPowerUp : MonoBehaviour
{
    public float slowMultiplier = 2f; // 2x slower
    public float slowDuration = 5f;   // 5 seconds

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CannonShooter cannon = FindFirstObjectByType<CannonShooter>();
        if (cannon != null)
        {
            cannon.SlowFireRate(slowMultiplier, slowDuration);
        }

        Destroy(gameObject); // spawn once
    }
}
