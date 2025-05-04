/*using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (!other.CompareTag("Enemy") && !other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}*/
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public PlayerHealth playerHealth; // ← drag dari Inspector (seperti EnemyDamage.cs)
    private Vector2 direction = Vector2.right;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (!other.CompareTag("Enemy") && !other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Peluru mengenai: " + other.name); // ← Tambahkan ini

    if (other.CompareTag("Player"))
    {
        Debug.Log("Peluru mengenai PLAYER"); // ← Tambahkan ini

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}

}
