using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 5;
    public int jumpHeight = 10;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

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

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
