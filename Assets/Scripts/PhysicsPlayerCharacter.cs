﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsPlayerCharacter : MonoBehaviour {
    #region
    [SerializeField]
    private float accelerationForce = 5;

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private float jumpForce = 10;

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private Collider2D playerGroundCollider;

    [SerializeField]
    private PhysicsMaterial2D playerMovingPhysicsMaterial, playerStoppingPhysicsMaterial;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    [SerializeField]
    private Collider2D groundDetectTrigger;
    #endregion


    private Animator playeranimator;

    public bool canDoInput = true;
    private bool canDoubleJump;
    private float horizontalInput;
    private bool isOnGround;
    private Collider2D[] groundHitDetectionResults = new Collider2D[16];
    private Checkpoint currentCheckpoint;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private AudioClip jumpclip;
    private AudioSource audioSource;

    private void Start()
    {
        playeranimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame

    void Update ()
    {
        UpdateIsOnGround();

        if (canDoInput)
        {
            UpdateHorizontalInput();

            HandleJumpInput();
        }
        playeranimator.SetFloat("animSpeed", Mathf.Abs(rb2d.velocity.x));
        playeranimator.SetFloat("vSpeed", rb2d.velocity.y);
        playeranimator.SetBool("Ground", isOnGround);
    }

    private void FixedUpdate()
    {
        UpdatePhysicsMaterial();

        if (canDoInput)
        {
            Move();
        }
    }

    private void UpdatePhysicsMaterial()
    {
        if (Mathf.Abs(horizontalInput) > 0)
        {
            playerGroundCollider.sharedMaterial = playerMovingPhysicsMaterial;
        }
        else
        {
            playerGroundCollider.sharedMaterial = playerStoppingPhysicsMaterial;
        }
    }
    private void UpdateIsOnGround()
    {
        isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) > 0;
        //Debug.Log("isOnGround?: " + isOnGround);
    }

    private void UpdateHorizontalInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void HandleJumpInput()
    {
        audioSource = GetComponent<AudioSource>();

        if (Input.GetButtonDown("Jump") & isOnGround )
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playeranimator.SetTrigger("Jump");
            audioSource.clip = jumpclip;
            audioSource.Play();



        }

        else if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playeranimator.SetTrigger("Jump");
            audioSource.clip = jumpclip;
            audioSource.Play();
        }

    }

    private void Move()
    {
        rb2d.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;

        if (rb2d.velocity.x > 0.1)
        {
            transform.localScale = new Vector3(1, 1, 1);  
        }
        else if (rb2d.velocity.x < -0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        playeranimator.SetBool("Ground", isOnGround);

        float move = Input.GetAxis("Horizontal");
    }

    public void Respawn()
    {
        canDoInput = true; 

        if (currentCheckpoint == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
        {
            rb2d.velocity = Vector2.zero;
            transform.position = currentCheckpoint.transform.position;
        }
     }
    public void SetCurrentCheckpoint(Checkpoint newCurrentCheckpoint)
    {
        if (currentCheckpoint != null)
            currentCheckpoint.SetIsActivated(false);

        currentCheckpoint = newCurrentCheckpoint;
        currentCheckpoint.SetIsActivated(true);
    }
}
