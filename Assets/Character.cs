using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour
{

    public string cName;
    public int basePower;
    public int finalPower;
    public bool isAlive;

    public HealthSystem healthSystem;


    public void Heal(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        finalPower = (int)System.Math.Floor(basePower * mutliplier);
        print("Healer healed with " + finalPower + " power");
        target.Regenerate(finalPower);
    }

    public void Rage(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        finalPower = (int)System.Math.Floor(basePower * mutliplier);
        print("Wounded hit with " + finalPower + " power");
        target.Tank(finalPower);
    }

    public void Tank(int amount)
    {
        healthSystem.SubtractHealth(amount);
        print("Healer tanked " + amount + " damages");
        print("Healer's current health : " + healthSystem.GetHealth());
    }

    public void Regenerate(int amount)
    {
        healthSystem.AddHealth(amount);
        print("Wounded regenerate " + amount + " HP");
        print("Wounded's current health : " + healthSystem.GetHealth());
    }


}
