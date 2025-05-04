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

    /*void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }*/
    void Shoot()
    {
        /*GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            Vector2 direction = player.position.x < transform.position.x ? Vector2.left : Vector2.right;
            bulletScript.SetDirection(direction);
            bulletScript.playerHealth = player.GetComponent<PlayerHealth>(); // Set langsung
        }*/
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.SetDirection(player.position.x < transform.position.x ? Vector2.left : Vector2.right);
            bulletScript.playerHealth = player.GetComponent<PlayerHealth>(); // ← Tambahkan baris ini
        }

}

}
