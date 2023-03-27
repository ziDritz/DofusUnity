using System;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    // State
    // INIT : initialize systems variables
    // PREPARING : Spawn characters
    public enum State { INIT, PREPARING, BATTLE, ENDED }
    private State state;

    // Events
    public event EventHandler OnBattleStarted;
    public event EventHandler<OnStateChangedEA> OnStateChanged;
    public class OnStateChangedEA : EventArgs
    {
        public State state;
    }

    // Sub-system
    [SerializeField] CharacterSystem characterSystem;
    [SerializeField] TurnSystem turnSystem;

    private void Start()
    {
        state = State.INIT;
    }

    private void Update()
    {
        switch (state)
        {
            case State.INIT:
                print("----------------------------------");

                characterSystem.Init();
                turnSystem.Init();

                print("Battle Initialized");

                state = State.PREPARING;

                break;

            case State.PREPARING:
                print("Prepating battle...");
                characterSystem.PrepareBattle();

                state = State.BATTLE;
                print("Battle has started !");
                print("----------------------------------");
                OnBattleStarted?.Invoke(this, EventArgs.Empty);
                break;

            case State.BATTLE:

                break;

            case State.ENDED:
                break;
        }
    }

    private void ListenCharacter (object sender, CharacterSystem.OnSpawnEA e) { 
        e.character.OnTurnEnded += ChangeState;
    }

    private void ChangeState(object sender, EventArgs e)
    {
        //IsBattleOver();

        OnStateChanged?.Invoke(this, new OnStateChangedEA { state = state });
    }

    //private void IsBattleOver()
    //{
    //    if (CharacterSystem.characters.ContainsKey("Healer"))
    //    {
    //        var healer = CharacterSystem.characters["Healer"];

    //        if (healer.isAlive == false)
    //        {
    //            print("Healer is dead !");
    //            print("Battle is over");
    //            state = State.ENDED;
    //        }
    //    }

    //    if (CharacterSystem.characters.ContainsKey("Undead"))
    //    {
    //        var undead = CharacterSystem.characters["Undead"];

    //        if (undead.isAlive == true)
    //        {
    //            print("Undead is alive !");
    //            print("Battle is over");
    //            state = State.ENDED;
    //        }
    //    }
    //}
}
