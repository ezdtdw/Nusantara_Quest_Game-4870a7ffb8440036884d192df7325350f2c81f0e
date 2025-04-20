using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public Transform cam; // Kamera utama
    public float parallaxMultiplier = 0.5f; // 0 = diam, 1 = ikut penuh

    private Vector3 lastCamPos;

    void Start()
    {
        if (cam == null)
            cam = Camera.main.transform;

        lastCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCamPos;

        // Hanya bergerak di sumbu X (horizontal)
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplier, 0, 0);

        lastCamPos = cam.position;
    }
}