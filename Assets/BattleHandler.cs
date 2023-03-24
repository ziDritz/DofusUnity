using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public static BattleHandler Instance;

    // Prefabs
    [SerializeField] private Transform pfHealer;
    [SerializeField] private Transform pfUndead;

    // State
    public enum State { INIT, HEALERTURN, UNDEADTURN, ENDED }
    private State state;

    // Events
    public event EventHandler<OnStateChangedEA> OnStateChanged;
    public class OnStateChangedEA : EventArgs
    {
        public State state;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        state = State.INIT;
        Spawn();
    }

    private void Update()
    {
        switch (state)
        {
            case State.INIT:
                state = State.UNDEADTURN; // on le met en UNDEADTURN comme ça ChangeState change en HEALERTURN
                print("Battle ready");
                ChangeState(this, new OnStateChangedEA { state = state });
                break;
        }
    }

    private void Spawn()
    {
        // Spawn Healer
        Transform healerTransform = Instantiate(pfHealer);
        Character healer = healerTransform.GetComponent<Character>();
        healer.OnTurnEnded += ChangeState;
        Character.characters.Add(healer.cName, healer);

        // Spawn Undead
        Transform undeadTransform = Instantiate(pfUndead);
        Character undead = undeadTransform.GetComponent<Character>();
        undead.OnTurnEnded += ChangeState;
        Character.characters.Add(undead.cName, undead);
    }

    private void ChangeState(object sender, EventArgs e)
    {
        IsBattleOver();

        switch (state)
        {
            case State.HEALERTURN:
                state = State.UNDEADTURN;
                print("Undead's turn");
                break;

            case State.UNDEADTURN:
                state = State.HEALERTURN;
                print("Healer's Turn");
                break;
        }

        OnStateChanged?.Invoke(this, new OnStateChangedEA { state = state });
    }

    private void IsBattleOver()
    {
        if (Character.characters.ContainsKey("Healer"))
        {
            var healer = Character.characters["Healer"];

            if (healer.isAlive == false)
            {
                print("Healer is dead !");
                print("Battle is over");
                state = State.ENDED;
            }
        }

        if (Character.characters.ContainsKey("Undead"))
        {
            var undead = Character.characters["Undead"];

            if (undead.isAlive == true)
            {
                print("Undead is alive !");
                print("Battle is over");
                state = State.ENDED;
            }
        }
    }
}
