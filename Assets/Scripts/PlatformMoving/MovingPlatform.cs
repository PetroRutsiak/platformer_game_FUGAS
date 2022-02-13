using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float updot;
    [SerializeField] private float downdot;
    [SerializeField] private float speed;

    float dirY;
    float dirX = 0;
    

    bool movingUp = true;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= updot)
        {
            movingUp = false;
        }
        else if (transform.position.y <= downdot)
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
