using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSystem : MonoBehaviour
{
    // Supra-system
    [SerializeField] private BattleHandler BattleHandler;

    // Event
    public event EventHandler<OnSpawnEA> OnSpawn;
    public class OnSpawnEA : EventArgs
    {
        public Character character;
    }

    public event EventHandler OnAllCharacterSpawned;

    // Prefab
    [SerializeField] public Character healerPrefab;
    [SerializeField] private Character undeadPrefab;

    [SerializeField] private CData undeadData;
    [SerializeField] private CData slowmoData;
    [SerializeField] private CData speedoData;

    // Collections
    public List<Character> charactersList;
    public Dictionary<string, Character> charactersDictionnary;

    // State method
    public void Init()
    {
        charactersList = new List<Character>();
        charactersDictionnary = new Dictionary<string, Character>();
    }

    public void PrepareBattle()
    {
        Spawn(healerPrefab, slowmoData);
        Spawn(healerPrefab, speedoData);
        Spawn(undeadPrefab, undeadData);
        OnAllCharacterSpawned?.Invoke(this, EventArgs.Empty);
    }


    private void Spawn(Character prefab, CData cData)
    {
        var c = Instantiate(prefab, this.GetComponent<Transform>());
        c.Init(cData);
        charactersList.Add(c);
        charactersDictionnary.Add(c.CName, c);

        OnSpawn?.Invoke(null, new OnSpawnEA { character = c });
    }


}
