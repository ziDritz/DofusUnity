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
    public int boostBonus;
    public int Initiative { get; private set; }
    public int TurnAssigned;
    

    // State variables
    public bool isAlive;
    public bool isActive;


    // Sub-systems
    public HealthSystem healthSystem;
    public SpellSystem actionSystem;

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



    // Turn Methods

    public void EndTurn()
    {
        isActive = false;
        print(CName + " ended his turn");
        OnTurnEnded?.Invoke(this, EventArgs.Empty);
    }

    private void TryToActivate(object sender, EventArgs e)
    {
        if (TurnAssigned == turnSystem.turnState)
        {
            isActive = true;
            print("----------------------------------");
            print(CName + " is active");
        }
        else isActive = false;
    }

    // Utility Methods

    public int CompareTo(Character other)
    {
        if (other == null) return 1;

        return Initiative - other.Initiative;
    }
}
