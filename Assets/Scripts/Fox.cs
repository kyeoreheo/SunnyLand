using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public Rigidbody2D myBody;
    public Animator myAnimator;
    public bool isOnFloor;
    public bool isHurt;
    public float speed;

    public float timer;
    private bool isTimerCounting;

    void Start()
    {
        Debug.Log("Hello :)");
    }

    void Update()
    {
        if (isTimerCounting)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 1.0f)
        {
            timer = 0.0f;
            isTimerCounting = false;
            isHurt = false;
        }

        if (isHurt)
        {
            myAnimator.Play("Player_Hurt", 0);
        }

        if (!isOnFloor && !isHurt)
        {
            myAnimator.Play("Player_Jump", 0);
        }

        if (Input.GetKey("left"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            if (isOnFloor && !isHurt)
            {
                myAnimator.Play("Player_Run", 0);
            }
        }
        else if (Input.GetKey("right"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            if (isOnFloor)
            {
                myAnimator.Play("Player_Run", 0);
            }
        }
        else if(isOnFloor && !isHurt)
        {
            myAnimator.Play("Player_Idel", 0);
        }

        if (Input.GetKeyDown("space") && isOnFloor && !isHurt)
        {
            Jump();
        }
    }

    public void Jump()
    {
        myBody.velocity = Vector2.up * speed * 3;
        isOnFloor = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnFloor = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            isTimerCounting = true;
            isHurt = true;
        }
    }
}
