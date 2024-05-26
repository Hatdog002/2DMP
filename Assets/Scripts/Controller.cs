using System.Collections;
using UnityEngine;
using Photon.Pun;

public class Controller : MonoBehaviourPunCallbacks
{
    [Header("Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 4f;
    
    [Header("Collision")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool m_facingRight = true;
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    private SpriteRenderer m_spriteRenderer;
    private BoxCollider2D m_collider;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_collider = GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            HandleMovement();
            HandleJumping();
            UpdateAnimator();
        }
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (!isCollided())
        {
            m_rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, m_rigidbody.velocity.y);
        }
        FlipCharacter(horizontalInput);
    }

    private void HandleJumping()
    {
        Vector2 groundPosition = new Vector2(transform.position.x, m_collider.bounds.min.y - 0.1f);
        Vector2 colliderSize = new Vector2(m_collider.size.x, 0.1f);
        bool isGrounded = Physics2D.OverlapBox(groundPosition, colliderSize, 0f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, jumpForce);
    }

    private void UpdateAnimator()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool walking = movement.magnitude > 0 ? true : false;
        m_animator.SetBool("isWalking", walking);
        m_animator.SetBool("isGrounded", IsGrounded());
    }

    private bool IsGrounded()
    {
        Vector2 groundPosition = new Vector2(transform.position.x, m_collider.bounds.min.y - 0.1f);
        Vector2 colliderSize = new Vector2(m_collider.size.x, 0.1f);
        return Physics2D.OverlapBox(groundPosition, colliderSize, 0f, groundLayer);
    }

    private bool isCollided()
    {
        Vector2 direction = m_facingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.1f, groundLayer);
        return hit.collider != null;
    }

    
    [PunRPC]
    private void FlipCharacter(float horizontalInput)
    {
        m_facingRight = horizontalInput != 0 ? horizontalInput > 0 : m_facingRight;
        m_spriteRenderer.flipX = !m_facingRight;
    }
}
