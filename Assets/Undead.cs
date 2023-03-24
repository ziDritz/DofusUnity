using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undead : Character
{
    public override void Activate(object sender, BattleHandler.OnStateChangedEA e)
    {
        if (e.state == BattleHandler.State.UNDEADTURN) isActive = true;
    }
}
