using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each effects derives from Effect
public class Effect
{
    protected Character target;
    protected int basePower;

    public Effect(int basePower)
    {
        this.basePower = basePower;
    }

    public virtual void ApplyEffect(Character target) { }
}

// Override the base power & ApplyEffect
public class HealEffect : Effect
{
    public HealEffect(int basePower) : base(basePower)
    {

    }

    public override void ApplyEffect(Character target)
    {
        Debug.Log(target.CName + " has been healed by " + basePower);
    }

} 

    


