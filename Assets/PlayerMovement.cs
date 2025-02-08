using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 5;
    public int jumpHeight = 10;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetKey(KeyCode.LeftArrow) ? Vector2.left :
                   Input.GetKey(KeyCode.RightArrow) ? Vector2.right :
                   Vector2.zero;

        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }


        FlipCharacter(movement.x);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    void FlipCharacter(float horizontal)
    {
        if (horizontal > 0 && !facingRight)
        {
            facingRight = true;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (horizontal < 0 && facingRight)
        {
            facingRight = false;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
