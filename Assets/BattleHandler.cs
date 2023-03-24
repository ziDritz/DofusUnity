using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public static BattleHandler Instance;

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
        //Subscribe to events
        CharacterSystem.Instance.OnCharacterSpawned += ListenCharacter;

        state = State.INIT;

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
        if (CharacterSystem.characters.ContainsKey("Healer"))
        {
            var healer = CharacterSystem.characters["Healer"];

            if (healer.isAlive == false)
            {
                print("Healer is dead !");
                print("Battle is over");
                state = State.ENDED;
            }
        }

        if (CharacterSystem.characters.ContainsKey("Undead"))
        {
            var undead = CharacterSystem.characters["Undead"];

            if (undead.isAlive == true)
            {
                print("Undead is alive !");
                print("Battle is over");
                state = State.ENDED;
            }
        }
    }

    private void ListenCharacter(object sender, CharacterSystem.OnCharacterSpawnedEA e)
    {
        e.character.OnTurnEnded += ChangeState;
    }
}
