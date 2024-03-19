using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Settings")]
    [SerializeField] private float baseSpeed;
    [SerializeField] private float speedMultiply;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce; 

    private float speed = 0;

    void Start()
    {
        speed = baseSpeed;
    }

    void Update()
    {
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        Jump();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Wall")
        {
            if(IsGrounded())
                speed *= -1;
            if(!IsGrounded())
            {
                speed *= -speedMultiply;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .1f, groundLayer);
    }

    private bool IsTouchedCeiling()
    {
        return Physics2D.OverlapCircle(ceilingCheck.position, .1f, groundLayer);
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Fire1") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
