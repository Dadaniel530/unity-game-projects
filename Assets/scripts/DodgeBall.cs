using UnityEngine;

public class DodgeBall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        // Check for shield
        PlayerShield shield = collision.gameObject.GetComponent<PlayerShield>();
        if (shield != null && shield.shieldActive)
        {
            Debug.Log("Hit blocked by shield");
            Destroy(gameObject);
            return;
        }

        // No shield → take damage
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage();
        }

        Destroy(gameObject);
    }
}
