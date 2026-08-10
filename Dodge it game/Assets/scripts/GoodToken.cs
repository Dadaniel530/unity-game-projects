using UnityEngine;

public class GoodToken : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ScoreManager sm = FindFirstObjectByType<ScoreManager>();
        if (sm != null)
        {
            sm.AddToken();
        }

        Destroy(gameObject);
    }
}
