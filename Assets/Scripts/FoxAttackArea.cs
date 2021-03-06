﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAttackArea : MonoBehaviour
{
    public Fox fox;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<Frog>().Hurt();
            fox.Jump();
        }
    }
}
