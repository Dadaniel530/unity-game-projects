using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool shieldActive = false;

    public void ActivateShield(float duration)
    {
        if (shieldActive) return;

        shieldActive = true;
        Debug.Log("Shield ON");

        Invoke(nameof(DeactivateShield), duration);
    }

    void DeactivateShield()
    {
        shieldActive = false;
        Debug.Log("Shield OFF");
    }
}
