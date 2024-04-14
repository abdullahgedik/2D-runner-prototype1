using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;
    [Header("Settings")]
    [SerializeField] private float jumpForce;
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(IsGrounded());
        Jump();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2 (rb.velocity.x , rb.velocity.y * 0.5f);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .2f, layerMask);
    }
}
