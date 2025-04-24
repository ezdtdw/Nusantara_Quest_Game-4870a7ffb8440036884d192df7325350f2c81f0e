using UnityEngine;

public class PlayerJumpBoost : MonoBehaviour
{
    public float jumpBoostForce = 20f; // gaya dorong ke atas

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JumpPad"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // reset kecepatan vertikal
            rb.AddForce(Vector2.up * jumpBoostForce, ForceMode2D.Impulse);
        }
    }
}
