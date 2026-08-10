using UnityEngine;

public class CannonAim : MonoBehaviour
{
    public Transform player;
    public float rotateSpeed = 5f;

    void Update()
    {
        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        // Rotate to look at the player
        Quaternion targetRot = Quaternion.LookRotation(dir);

        // Apply offset because cannon's forward is X instead of Z
        targetRot *= Quaternion.Euler(0, -90, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
    }
}
