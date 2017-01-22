using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drake : Enemy
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void dead()
    {
        base.dead();
        Grid.EventHub.TriggerGameWon();
    }
}
