using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private int leftYmove;
    [SerializeField] private int rightYmove;
    float dirY;
    float dirX = 0;
    float speed = 2f;

    bool movingUp = true;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= leftYmove)
        {
            movingUp = false;
        }
        else if (transform.position.y <= rightYmove)
        {
            movingUp = true;
        }

        if (movingUp)
        {
            transform.position = new Vector2( transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
