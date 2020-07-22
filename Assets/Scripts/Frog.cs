using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public Rigidbody2D myBody;
    public Animator myAnimator;
    public float speed;

    public float movementRange;
    public Vector2 leftMostPosition;
    public Vector2 rightMostPosition;

    public bool reachedLeftMost = false;
    public bool reachedRightMost = true;
    // Start is called before the first frame update
    void Start()
    {
        leftMostPosition = new Vector2(transform.position.x - movementRange, transform.position.y);
        rightMostPosition = new Vector2(transform.position.x + movementRange, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedLeftMost && transform.position.x > leftMostPosition.x)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }
        else
        {
            reachedLeftMost = true;
            reachedRightMost = false;
        }

        if (!reachedRightMost && transform.position.x < rightMostPosition.x)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else
        {
            reachedLeftMost = false;
            reachedRightMost = true;
        }


    }


}
