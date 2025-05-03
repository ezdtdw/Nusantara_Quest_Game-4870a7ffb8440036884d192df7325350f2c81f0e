using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; // Referensi ke komponen PlayerHealth
    public int damage = 2;
    /*private void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Mengambil komponen PlayerHealth dari objek yang bertabrakan
            playerHealth.TakeDamage(damage); // Mengurangi kesehatan pemain 
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
}

