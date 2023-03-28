using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each new spell derives from Spell
public class Spell
{
    private Character caster;
    private Character target;

    public string name;
    protected Effect[] effects;

    public Spell(Character caster)
    {
        this.caster = caster;
    }

    // Loop trough effect array and apply them
    public void Activate(Character target)
    {
        Debug.Log(caster.CName + " uses " + name);

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].ApplyEffect(target);
        }

    }
}

// Overrides name & effect array
public class Heal : Spell
{
    public Heal(Character caster) : base(caster)    // je sais pas trop à quoi sert le base : voir vod C# Inheritance in Unity! (4:20)
    {                                               // alors si en fait y a une histoire de chaque constructeur est unique à la classe,
        name = "Heal";                              // il est pas hérité, donc on l'appelle explicitement (je crois que c'est ça)

        effects = new Effect[]
        {
            new HealEffect(8)
        };
    }
}




