using UnityEngine;

public class StandCharacter : MonoBehaviour{
    private Rigidbody2D rb;
    private Collider2D npcCollider;

    [Header("NPC Behavior Settings")]
    [SerializeField] private bool canBePushed = false; // NPC bisa didorong?
    [SerializeField] private bool canBePassedThrough = false; // NPC bisa dilewati?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        npcCollider = GetComponent<Collider2D>();

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Mencegah NPC tumbang
            if (!canBePushed)
            {
                rb.bodyType = RigidbodyType2D.Kinematic; // NPC tidak akan terdorong jika canBePushed = false
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canBePushed)
            {
                rb.bodyType = RigidbodyType2D.Dynamic; // Jika bisa didorong, aktifkan physics normal
                rb.mass = 50; // Pastikan massanya cukup agar tidak mudah terbang
            } //
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBePassedThrough && collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(npcCollider, collision, true); // Bypass collider player
        }
    }
}