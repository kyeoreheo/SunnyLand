using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject fox;

    private Fox myFox;
    private float currentFoxY;
    private void Start()
    {
        myFox = fox.GetComponent<Fox>();
        currentFoxY = 0.0f;
    }

    void Update()
    {
        if (fox.transform.position.x >= -5)
        {
            this.transform.position = new Vector3(fox.transform.position.x, currentFoxY, -10);
        }
        if (myFox.isInFallingArea)
        {
            currentFoxY = fox.transform.position.y;
            //this.transform.position = new Vector3(fox.transform.position.x, fox.transform.position.y, -10);
        }

    }
}
