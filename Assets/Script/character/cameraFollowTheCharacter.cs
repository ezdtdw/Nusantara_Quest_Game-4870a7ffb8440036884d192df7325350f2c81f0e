using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target; // Target yang akan diikuti (Character)
    public float smoothSpeed = 0.125f; // Kecepatan smoothing
    public Vector3 offset = new Vector3(0, 0, -10); // Offset kamera ke belakang (biar kelihatan)
    public float lookAheadDistance = 2f; // Jarak kamera bergerak ke arah gerak karakter

    private Vector3 velocity = Vector3.zero;
    private float direction = 1f;

    void LateUpdate()
    {
        if (target == null) return;

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Update arah gerakan
        if (horizontalInput != 0)
        {
            direction = Mathf.Sign(horizontalInput);
        }

        // Posisi yang diinginkan kamera
        Vector3 lookAhead = Vector3.right * direction * lookAheadDistance * Mathf.Abs(horizontalInput);
        Vector3 desiredPosition = target.position + offset + lookAhead;

        // Smooth follow
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}