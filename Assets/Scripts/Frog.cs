using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public Rigidbody2D myBody;
    public Animator myAnimator;
    public float speed;
    public float standingTime;
    public float movementRange;

    private Vector2 leftMostPosition;
    private Vector2 rightMostPosition;
    private bool reachedLeftMost = false;
    private bool reachedRightMost = true;

    private float timer;
    private bool isReadyToMove = false;
    private bool isHurt = false;

    void Start()
    {
        leftMostPosition = new Vector2(transform.position.x - movementRange, transform.position.y);
        rightMostPosition = new Vector2(transform.position.x + movementRange, transform.position.y);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= standingTime && !isReadyToMove)
        {
            isReadyToMove = true;
        }

        if (!isHurt)
        {
            if (isReadyToMove)
            {
                if (!reachedLeftMost)
                {
                    if (transform.position.x > leftMostPosition.x)
                    {
                        myBody.velocity = new Vector2(-speed, myBody.velocity.y);
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        myAnimator.Play("Frog_Jump", 0);
                    }
                    else
                    {
                        reachedLeftMost = true;
                        reachedRightMost = false;
                        isReadyToMove = false;
                        timer = 0.0f;
                    }
                }

                if (!reachedRightMost)
                {
                    if (transform.position.x < rightMostPosition.x)
                    {
                        myBody.velocity = new Vector2(speed, myBody.velocity.y);
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        myAnimator.Play("Frog_Jump", 0);
                    }
                    else
                    {
                        reachedLeftMost = false;
                        reachedRightMost = true;
                        isReadyToMove = false;
                        timer = 0.0f;
                    }
                }
            }
            else
            {
                if (reachedLeftMost)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }

                myAnimator.Play("Frog_Idle", 0);
            }
        }
        else if (timer >= 1.0f)
        {
            Debug.Log("HERE");
            Destroy(this.gameObject);
        }
    }

    public void Hurt()
    {
        timer = 0.0f;
        isHurt = true;
        myAnimator.Play("Frog_Hurt", 0);
    }
}
