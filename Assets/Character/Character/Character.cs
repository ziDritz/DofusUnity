using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Supra-sytems
    [SerializeField] private BattleHandler battleHandler;
    [SerializeField] private CharacterSystem characterSystem;
    [SerializeField] private TurnSystem turnSystem;

    // Caracteristics
    public string CName { get; private set; }
    public int BasePower { get; private set; }
    public int Initiative { get; private set; }
    public int TurnAssigned;
    

    // State variables
    public bool isAlive;
    public bool isActive;


    // Sub-systems
    public HealthSystem healthSystem;

    // Events
    public event EventHandler OnTurnEnded;

    // State methods
    public void Init(CData cData)
    {
        characterSystem = GetComponentInParent<CharacterSystem>();
        turnSystem = GetComponentInParent<TurnSystem>();
        battleHandler = GetComponentInParent<BattleHandler>();

        CName = cData.cName;
        BasePower = cData.basePower;
        Initiative = cData.initiative;

        // Subscribe to events
        battleHandler.OnBattleStarted += TryToActivate;
        turnSystem.OnTurnStateChanged += TryToActivate;

    }

    // Actions methods
    public void Heal(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        var finalPower = (int)System.Math.Floor(BasePower * mutliplier);
        print(CName + " use Heal");
        target.Regenerate(finalPower);
    }

    public void Rage(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        var finalPower = (int)System.Math.Floor(BasePower * mutliplier);
        print(CName + " use Rage");
        target.Tank(finalPower);
    }

    public void Tank(int amount)
    {
        healthSystem.SubtractHealth(amount);
        print(CName + " tanked " + amount + " damages");
    }

    public void Regenerate(int amount)
    {
        healthSystem.AddHealth(amount);
        print(CName + " regenerate " + amount + " HP");
    }

    public void EndTurn()
    {
        isActive = false;
        print(CName + " ended his turn");
        OnTurnEnded?.Invoke(this, EventArgs.Empty);
    }

    public int CompareTo(Character other)
    {
        if (other == null) return 1;

        return Initiative - other.Initiative;
    }

    private void TryToActivate(object sender, EventArgs e)
    {
        if (TurnAssigned == turnSystem.turnState)
        {
            isActive = true;
            print(CName + " is active");
        }
        else isActive = false;
    }


}
