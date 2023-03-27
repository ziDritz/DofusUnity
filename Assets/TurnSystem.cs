using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    [SerializeField] private CharacterSystem characterSystem;

    public int turnState;
    private int turnStateMax;
    private int turnCount;

    // Event
    public event EventHandler OnTurnStateChanged;

    public void Init()
    {
        turnState = 1;

        characterSystem.OnAllCharacterSpawned += CharacterSystem_OnAllCharacterSpawned;
    }

    private void CharacterSystem_OnAllCharacterSpawned(object sender, EventArgs e)
    {
        // Set Turn Order
        List<Character> TurnOrderList = new List<Character>(characterSystem.characters);
        TurnOrderList.Sort((c1, c2) => c2.Initiative.CompareTo(c1.Initiative));

        print("----------------------------------");
        for (int i = 0; i < TurnOrderList.Count; i++)
        {
            TurnOrderList[i].OnTurnEnded += ChangeTurnState;
            TurnOrderList[i].TurnAssigned = i + 1;

            print(TurnOrderList[i].TurnAssigned + " : " + TurnOrderList[i].CName);
        }

        // Set turnStateMax
        turnStateMax = characterSystem.characters.Count;
    }

    private void ChangeTurnState(object sender, EventArgs e)
    {
        turnState++;
        if (turnState > turnStateMax) turnState = 1;

        OnTurnStateChanged?.Invoke(this, EventArgs.Empty);
    }
}
