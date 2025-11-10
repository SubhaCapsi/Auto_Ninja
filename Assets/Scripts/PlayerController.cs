using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float defaultRotationY = 0f;
    private float oppsiteRotationY = 180f;
    private Rigidbody2D rb;
    public bool isGameStarted = false;
    private bool movingRight = true;
    private bool isGrounded = true;
    private bool jumpPressed = false;
    private bool canDoubleJump = false;
    private bool isOnWall = false;
    private bool isWallJumping;
    public GameObject gameOverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Taking jump input from pc
        bool jumpPressedPC = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        // Taking double-jump input from mobile
        bool jumpPressedMobile = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;

        // Putting PC and mobile input in one variable
        jumpPressed = jumpPressedPC || jumpPressedMobile;

        // Moving the character automatically
        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * speed, rb.linearVelocity.y);

        if (isGameStarted == false && jumpPressed)
        {
            Time.timeScale = 1f;
            isGameStarted = true;
        }
        
        if (jumpPressed)
        {
            if (isOnWall)
            {
                movingRight = !movingRight;
                transform.rotation = Quaternion.Euler(0, movingRight ? defaultRotationY : oppsiteRotationY, 0);
                rb.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
                isOnWall = false;
                canDoubleJump = true;
                isWallJumping = true;
                Invoke(nameof(EndWallJump), 0.2f);
            }
            else if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }

    }
    private void EndWallJump()
    {
        isWallJumping = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            // if (!isWallJumping)
            // {
            isOnWall = true;
            transform.rotation = Quaternion.Euler(0, movingRight ? oppsiteRotationY : defaultRotationY, 0);
            rb.gravityScale = 4f;
            // }
        }
        if (collision.gameObject.CompareTag("Top-Wall"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.gravityScale = 1f;
            isOnWall = false;
            if (!isWallJumping)
            {
                transform.rotation = Quaternion.Euler(0, movingRight ? defaultRotationY : oppsiteRotationY, 0);
            }

        }
    }
}
