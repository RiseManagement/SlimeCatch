using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -7.8)
        {
            transform.Translate(speed, 0f, 0f);
        }
        else
        {
            speed = 0;
        }
    }
}
