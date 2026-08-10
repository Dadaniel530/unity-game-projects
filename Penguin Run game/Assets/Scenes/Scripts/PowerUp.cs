using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    [Header("Time Slow Settings")]
    [Tooltip("How slow time should go (1 = normal speed, 0.5 = half speed, etc.)")]
    public float slowTimeScale = 0.5f;

    [Tooltip("How long (in real-time seconds) the slowdown should last")]
    public float duration = 3f;

    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            PenguinSoundManager.instance.PlaySFX(PenguinSoundManager.instance.powerUpClip);
            StartCoroutine(SlowTimeRoutine());
            isActive = true; // prevent re-triggering
            gameObject.SetActive(false); // hide or destroy power-up
        }
    }

    private IEnumerator SlowTimeRoutine()
    {
        Debug.Log("🕓 Time slowed down!");
        float originalTimeScale = Time.timeScale;
        float originalFixedDelta = Time.fixedDeltaTime;

        // Apply slow motion
        Time.timeScale = slowTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // maintain physics stability

        // Wait for real-world seconds (not affected by timeScale)
        yield return new WaitForSecondsRealtime(duration);

        // Restore normal time
        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = originalFixedDelta;

        Debug.Log("Time restored to normal!");
    }
}
