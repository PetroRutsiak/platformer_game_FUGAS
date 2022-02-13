using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{
    [SerializeField] private float rightYmove;
    [SerializeField] private float leftYmove;
    [SerializeField] private float speed;
    
    float dirX;
    

    bool movingRight = true;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > leftYmove)
        {
            movingRight = false;
        }
        else if (transform.position.x < rightYmove)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
