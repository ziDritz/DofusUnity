using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSystem : MonoBehaviour
{
    public static CharacterSystem Instance;

    public event EventHandler<OnCharacterSpawnedEA> OnCharacterSpawned;
    public class OnCharacterSpawnedEA : EventArgs
    {
        public Character character;
    }

    [SerializeField] private Transform pfHealer;
    [SerializeField] private Transform pfUndead;

    public static Dictionary<string, Character> characters = new Dictionary<string, Character>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Spawn Healer
        Transform healerTransform = Instantiate(pfHealer);
        Character healer = healerTransform.GetComponent<Character>();
        CharacterSystem.characters.Add(healer.cName, healer);
        OnCharacterSpawned?.Invoke(this, new OnCharacterSpawnedEA { character = healer });

        // Spawn Undead
        Transform undeadTransform = Instantiate(pfUndead);
        Character undead = undeadTransform.GetComponent<Character>();
        CharacterSystem.characters.Add(undead.cName, undead);
        OnCharacterSpawned?.Invoke(this, new OnCharacterSpawnedEA { character = undead });
    }
}
