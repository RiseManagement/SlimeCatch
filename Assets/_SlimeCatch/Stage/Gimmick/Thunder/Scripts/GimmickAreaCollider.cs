﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickAreaCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gimmick")) ;
    }
}
