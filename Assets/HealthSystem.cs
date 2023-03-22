using UnityEngine;
using System;
public class HealthSystem : MonoBehaviour 
{
    public Character character;

    public event EventHandler OnHealthChange;
    private int health;
    [SerializeField] private int healthMax;

    private void Start()
    {
        Init();
    }

    // le => c'est pour écrire une méthode sur une ligne
    private void Init() => health = healthMax;

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        if (OnHealthChange != null) OnHealthChange(this, EventArgs.Empty);
    }

    public void SubtractHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            character.isAlive = false;
            print("Healer is dead !");
        }
        if (OnHealthChange != null) OnHealthChange(this, EventArgs.Empty);
    }

}
