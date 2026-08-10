using UnityEngine;

public class BadToken : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ScoreManager sm = FindFirstObjectByType<ScoreManager>();
        if (sm != null)
        {
            sm.RemoveToken();
        }

        Destroy(gameObject);
    }
}
