using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckRadius;
    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;
    
    // Animasi berjalan
    public Sprite[] walkingSprites;
    public Sprite[] idleSprites;
    public float frameRate = 0.1f;
    private int currentFrame;
    private float frameTimer;
    private int idleFrame;
    private float idleTimer;
    
    // Public class untuk mengatur skala sprite
    public Vector2 walkingSpriteScale = new Vector2(1, 1);
    public Vector2 idleSpriteScale = new Vector2(1, 1);

    void Start() {
        playerRb.freezeRotation = true;
        if (idleSprites.Length > 0) {
            spriteRenderer.sprite = idleSprites[0]; // Set sprite awal ke idle
        }
        spriteRenderer.transform.localScale = idleSpriteScale; // Set skala awal
    }

    void Update() {
        input = Input.GetAxisRaw("Horizontal");
        if (input > 0) {
            spriteRenderer.flipX = false;
        } else if (input < 0) {
            spriteRenderer.flipX = true;
        }
        
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckRadius, groundLayer);

        if (isGrounded == true && Input.GetButtonDown("Jump")) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.linearVelocity = Vector2.up * jumpForce;
        }
        if (Input.GetButton("Jump") && isJumping == true) {
            if (jumpTimeCounter > 0) {
                playerRb.linearVelocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
        }

        AnimateCharacter();
    }
    //test

    void FixedUpdate() {
        playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);
    }

    void AnimateCharacter() {
        if (input != 0) {
            frameTimer += Time.deltaTime;
            if (frameTimer >= frameRate) {
                frameTimer = 0;
                currentFrame = (currentFrame + 1) % walkingSprites.Length;
                spriteRenderer.sprite = walkingSprites[currentFrame];
                spriteRenderer.transform.localScale = walkingSpriteScale; // Set skala saat berjalan
            }
        } else {
            idleTimer += Time.deltaTime;
            if (idleTimer >= frameRate) {
                idleTimer = 0;
                idleFrame = (idleFrame + 1) % idleSprites.Length;
                spriteRenderer.sprite = idleSprites[idleFrame]; // Animasi idle
                spriteRenderer.transform.localScale = idleSpriteScale; // Set skala idle
            }
        }
    }
}