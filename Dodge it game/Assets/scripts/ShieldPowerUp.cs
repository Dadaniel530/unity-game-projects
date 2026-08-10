using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 5f;

    void Start()
    {
        
        transform.rotation = Quaternion.Euler(-90f, -180f, -90f);
    }

    void OnTriggerEnter(Collider other)
    {
      

        if (!other.CompareTag("Player")) return;

        PlayerShield shield = other.GetComponent<PlayerShield>();
        if (shield != null)
        {
            shield.ActivateShield(shieldDuration);
        }

        Destroy(gameObject); // one-time pickup
    }
}
