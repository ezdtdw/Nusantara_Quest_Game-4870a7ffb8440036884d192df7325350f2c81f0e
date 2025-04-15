using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target; // Target yang akan diikuti (Character)
    public float smoothSpeed = 0.125f; // Kecepatan smoothing
    public Vector3 offset; // Offset kamera saat idle
    public float lookAheadDistance = 2f; // Jarak kamera bergerak ke depan berdasarkan arah karakter
    
    private Vector3 velocity = Vector3.zero;
    private float direction = 1f;

    void LateUpdate()
    {
        if (target == null) return;
        
        // Cek arah pergerakan karakter
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            direction = Mathf.Sign(horizontalInput); // 1 untuk kanan, -1 untuk kiri
        }

        // Posisi target yang diinginkan
        Vector3 desiredPosition = target.position + offset + (Vector3.right * direction * lookAheadDistance * Mathf.Abs(horizontalInput));
        
        // Gunakan Lerp untuk perpindahan yang lebih smooth
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}