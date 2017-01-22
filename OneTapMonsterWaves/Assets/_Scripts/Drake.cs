using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drake : Enemy
{
    public new void dead()
    {
        base.dead();
        Grid.EventHub.TriggerGameWon();
    }
}
