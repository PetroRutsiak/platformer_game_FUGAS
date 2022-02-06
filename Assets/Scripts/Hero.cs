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

    private Vector3 respawmPoint;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public GameObject fallDetector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        respawmPoint = transform.position;

    }
    
    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
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

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.name.Equals("Platform"))
        { 
            this.transform.parent = collision.transform;
        }

    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.name.Equals("Platform"))
        { 
            this.transform.parent = null;
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