using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject fox;

    void Update()
    {
        if (fox.transform.position.x >= -5)
            this.transform.position = new Vector3(fox.transform.position.x, 0, -10);
    }
}
