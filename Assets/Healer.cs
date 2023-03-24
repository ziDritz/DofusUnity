using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Character
{
    public override void Activate(object sender, BattleHandler.OnStateChangedEA e)
    {
        if (e.state == BattleHandler.State.HEALERTURN) isActive = true; 
    }
}
