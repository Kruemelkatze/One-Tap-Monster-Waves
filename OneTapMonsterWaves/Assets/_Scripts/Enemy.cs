using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            dead();
        }
    }

    void dead()
    {
        Destroy(this);
    }

}
