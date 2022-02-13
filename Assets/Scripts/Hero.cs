using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; 
    [SerializeField] private int lives = 5; 
    [SerializeField] private float jumpForce = 5f; 
    
    private bool isGrounded = true;
     
    public Joystick joystick;

    private Vector3 respawmPoint;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public GameObject fallDetector;
    public float horizontalspeed;
    private float moveInput;
    private bool facingright = true;

   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        respawmPoint = transform.position;

    }
    
    private void FixedUpdate()
    {
        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingright == false &&  moveInput  > 0)
        {
            Flip();
        }
        else if(facingright == true &&  moveInput  < 0)
        {
            Flip();
        }
        CheckGround();
    }

    private void Update()
    {
        
       if (Input.GetButton("Horizontal"))
            Run();

    }

    void Flip()
    {
        facingright =! facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);
        isGrounded = collider.Length > 0.5;
       
    }

     private void Run()
    {
       
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    public void onJumpButtonDown()
    {
        if(isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else
        {
            rb.velocity = Vector2.up;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawmPoint;
        }
        else if(collision.tag == "Checkpoint")
        {
            respawmPoint = transform.position;
        }
    }
}