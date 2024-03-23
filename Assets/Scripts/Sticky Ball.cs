using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyBall : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PhysicsMaterial2D bouncy;
    [SerializeField] private PhysicsMaterial2D notBouncy;
    [Header("Settings")]
    [SerializeField] private bool isSticky;

    private Rigidbody2D rb;
    private TrailRenderer trailRenderer;
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;

    private Color baseColor;
    private bool isBouncy = true;
    private float gravity;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        trailRenderer = gameObject.GetComponent<TrailRenderer>();

        baseColor = spriteRenderer.color;
        gravity = rb.gravityScale;
    }

    void Update()
    {
        if (isSticky && isBouncy)
        {
            isBouncy = !isBouncy;
            circleCollider.sharedMaterial = notBouncy;
            spriteRenderer.color = Color.green;
            trailRenderer.startColor = Color.green;
        }

        if (!isSticky && !isBouncy)
        {
            isBouncy = !isBouncy;
            circleCollider.sharedMaterial = bouncy;
            spriteRenderer.color = baseColor;
            trailRenderer.startColor = baseColor;
            rb.gravityScale = gravity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isSticky)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(isSticky)
            rb.gravityScale = gravity;
    }
}
