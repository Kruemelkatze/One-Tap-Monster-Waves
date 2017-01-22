using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drake : Enemy
{
    public override void dead()
    {
        base.dead();
        Grid.EventHub.TriggerGameWon();
    }
}
