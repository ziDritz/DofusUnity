using UnityEngine;
using System;
public class HealthSystem : MonoBehaviour 
{
    public Character character;

    public event EventHandler OnHealthChange;
    public int health;

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        if (health > 0) character.isAlive = true;
        if (OnHealthChange != null) OnHealthChange(this, EventArgs.Empty);
    }

    public void SubtractHealth(int amount)
    {
        health -= amount;
        if (health <= 0) character.isAlive = false;
        if (OnHealthChange != null) OnHealthChange(this, EventArgs.Empty);
    }
}
