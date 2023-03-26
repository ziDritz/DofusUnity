using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Static
    public static Dictionary<string, Character> characters = new Dictionary<string, Character>();

    // Caracteritics
    public string cName;
    public int BasePower { get; private set; }

    public int initiative;

    // States
    public bool isAlive;
    public bool isActive;


    // Sub-systems
    public HealthSystem healthSystem;

    // Events
    public event EventHandler OnTurnEnded;

    private void Start()
    {
        // Subscribe to events
        BattleHandler.Instance.OnStateChanged += Activate;
    }



    // Actions
    public void Heal(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        var finalPower = (int)System.Math.Floor(BasePower * mutliplier);
        print(cName + " use Heal");
        target.Regenerate(finalPower);
    }

    public void Rage(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        var finalPower = (int)System.Math.Floor(BasePower * mutliplier);
        print(cName + " use Rage");
        target.Tank(finalPower);
    }

    public void Tank(int amount)
    {
        healthSystem.SubtractHealth(amount);
        print(cName + " tanked " + amount + " damages");
    }

    public void Regenerate(int amount)
    {
        healthSystem.AddHealth(amount);
        print(cName + " regenerate " + amount + " HP");
    }

    public virtual void Activate(object sender, BattleHandler.OnStateChangedEA e)
    {
    }

    public void EndTurn()
    {
        isActive = false;
        print(cName + " ended his turn");
        OnTurnEnded?.Invoke(this, EventArgs.Empty);
    }

    public int CompareTo(Character other)
    {
        if (other == null) return 1;

        return initiative - other.initiative;
    }

    //public int CompareTo(Character other)
    //{
    //    if (other == null) return 1;

    //    return initiative - other.initiative;
    //}

}
