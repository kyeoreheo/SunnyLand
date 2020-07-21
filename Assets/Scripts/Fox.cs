using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public Rigidbody2D myBody;
    public Animator myAnimator;
    public bool isOnFloor;

    public float speed;
    void Start()
    {
        Debug.Log("Hello :)");
    }

    void Update()
    {
        if (!isOnFloor)
        {
            myAnimator.Play("Player_Jump", 0);
        }

        if (Input.GetKey("left"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            if (isOnFloor)
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
        else if(isOnFloor)
        {
            myAnimator.Play("Player_Idel", 0);
        }

        if (Input.GetKeyDown("space") && isOnFloor)
        {
            myBody.velocity = Vector2.up * speed * 2;
            isOnFloor = false;
        }

        //var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //transform.position += move * 1.0f * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnFloor = true;
       

        }
    }
}
