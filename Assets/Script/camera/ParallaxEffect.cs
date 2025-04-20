using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cam;
    public float parallaxEffect;
    public GameObject backgroundPrefab;

    private float length;
    private Vector3 lastCamPos;
    private GameObject leftCopy, rightCopy;

    void Start()
    {
        lastCamPos = cam.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        // Inisialisasi copy awal
        CreateCopy(1);  // kanan
        CreateCopy(-1); // kiri
    }

    void Update()
    {
        float deltaX = cam.position.x - lastCamPos.x;
        transform.position += Vector3.right * (deltaX * parallaxEffect);
        lastCamPos = cam.position;

        // Tambah background di kanan jika kamera mendekat ke ujung kanan
        if (cam.position.x > rightCopy.transform.position.x - (length / 2))
        {
            Destroy(leftCopy);
            leftCopy = gameObject;
            gameObject.transform.position = rightCopy.transform.position;
            rightCopy = CreateCopy(1);
        }

        // Tambah background di kiri jika kamera mendekat ke ujung kiri
        if (cam.position.x < leftCopy.transform.position.x + (length / 2))
        {
            Destroy(rightCopy);
            rightCopy = gameObject;
            gameObject.transform.position = leftCopy.transform.position;
            leftCopy = CreateCopy(-1);
        }
    }

    GameObject CreateCopy(int direction)
    {
        Vector3 spawnPos = transform.position + Vector3.right * length * direction;
        GameObject copy = Instantiate(backgroundPrefab, spawnPos, Quaternion.identity);
        copy.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); // Mirror

        return copy;
    }
}