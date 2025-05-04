using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {
                patrolDestination = 1;
            }
        }

        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
            {
                patrolDestination = 0; // <- PERBAIKI DI SINI
            }
        }
    }

}
/*
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;
    public int patrolDestination = 0;

    void Update()
    {
        Transform target = patrolPoints[patrolDestination];s
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;

            // Balik arah visual (flip sprite)
            Vector3 scale = transform.localScale;
            scale.x = (patrolDestination == 0) ? 1 : -1;
            transform.localScale = scale;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (patrolPoints.Length < 2) return;

        Vector2 targetPos = patrolPoints[patrolDestination].position;
        Vector2 direction = (targetPos - (Vector2)transform.position).normalized;

        // Gerakan horizontal ke arah target, simpan ke velocity
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        // Jika sudah cukup dekat, ganti tujuan
        if (Vector2.Distance(transform.position, targetPos) < 0.2f)
        {
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
        }

        // Opsional: Balik arah sprite jika perlu
        if (direction.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = direction.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}
*/