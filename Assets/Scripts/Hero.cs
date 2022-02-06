using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; 
    [SerializeField] private int lives = 5; 
    [SerializeField] private float jumpForce = 15f; 
    
    private bool isGrounded = false;
     
    public Joystick joystick;

    private float moveInput;    
    private Vector3 respawmPoint;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool facingright = true;
    public GameObject fallDetector;
    public float normalspeed;


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

       
    }

    private void Update()
    {
        
       CheckGround();
        
          if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    void Flip()
    {
        facingright =! facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = collider.Length > 1;
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