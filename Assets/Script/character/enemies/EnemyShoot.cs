using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // ujung laras
    public float fireRange = 5f;
    public float fireRate = 1f;
    public SpriteRenderer spriteRenderer;
    public Sprite shootSprite;
    public Sprite idleSprite;

    private float nextFireTime;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= fireRange)
        {
            spriteRenderer.sprite = shootSprite;

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
