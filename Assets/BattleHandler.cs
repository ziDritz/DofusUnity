using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform pfCharacterBattle;

    private enum State { HEALERTURN, WOUNDEDTURN }
    private State state;

    private Character healer;
    private Character wounded;

    private void Start()
    {
        healer = SpawnCharacter();
        wounded = SpawnCharacter();
        wounded.isAlive = false;
        state = State.HEALERTURN;
    }

    private void Update()
    {
        switch (state)
        {

            case State.HEALERTURN:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    healer.Heal(wounded);
                    state = State.WOUNDEDTURN;
                    IsBattleOver();
                }
                break;

            case State.WOUNDEDTURN:
                wounded.Rage(healer);
                state = State.HEALERTURN;
                IsBattleOver();
                break;
        }

    }

    private Character SpawnCharacter()
    {
        Transform characterTransform = Instantiate(pfCharacterBattle);
        Character character = characterTransform.GetComponent<Character>();

        return character;
    }

    private void IsBattleOver()
    {
        if (healer.isAlive == false) 
        {
            print("Battle is over");
            Destroy(this);
        }
    }
}
