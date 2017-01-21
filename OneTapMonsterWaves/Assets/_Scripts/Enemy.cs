using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor {

    public double derivedXP;

    private bool left;
    private bool fight;
    private Vector3 vec3Movement;

    // Use this for initialization
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            left = false;
        } else
        {
            left = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            dead();
        }
        else
        {
            if (!fight)
            {
                move();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Obstacle")
        {
            left = !left;
        }
        if(col.tag == "Player")
        {
            fight = true;
        }
    }

    void move()
    {
        if (left)
        {
            vec3Movement = Vector3.left * movement;
        } else
        {
            vec3Movement = Vector3.right * movement;
        }
        transform.Translate(vec3Movement);
    }


    void dead()
    {
        Destroy(this);
    }

}
