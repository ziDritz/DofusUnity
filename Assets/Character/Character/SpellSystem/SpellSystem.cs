using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : MonoBehaviour
{

    // Supra-sytems
    [SerializeField] private CharacterSystem characterSystem;
    [SerializeField] private Character caster;
    [SerializeField] private Character target;
    
    // System
    [SerializeField] private List<Spell> spells = new();
    [SerializeField] private int iSpells = 0;


    public void Start()
    {
        characterSystem = GetComponentInParent<CharacterSystem>();

        AddSpell("Heal");
    }

    private void Update()
    {
        if (caster.isActive == true)
        {
            if (Input.GetKeyDown(KeyCode.A)) { ChooseTarget("Speedo"); Cast(iSpells); }
            if (Input.GetKeyDown(KeyCode.Z)) { ChooseTarget("Slowmo"); Cast(iSpells); }
            if (Input.GetKeyDown(KeyCode.E)) { ChooseTarget("Undead"); Cast(iSpells); }
        }
    }




    // Construct Spell and add it to the Character's spell list
    public void AddSpell(string name)
    {
        switch (name)
        {
            case "Heal": spells.Add(new Heal(caster)); break;
        }
    }

    private void ChooseTarget(string CName)
    {
        target = characterSystem.charactersDictionnary[CName];
    }
    
    // Cast the spell
    public void Cast(int iSpells)
    {
        spells[iSpells].Activate(target);
        target = null;
    }




    //private void Heal(Character target)
    //{
    //    var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
    //    var finalPower = (int)System.Math.Floor(caster.BasePower * mutliplier) + caster.boostBonus;
    //    //target.actionSystem.Regenerate(finalPower);

    //    print(caster.CName + " use Heal");
    //}

    private void Boost(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        var finalPower = (int)Math.Floor(caster.BasePower * mutliplier);
        target.boostBonus += finalPower;
        print(caster.CName + " use Boost on " + target.CName);
        print(target.CName + " boost bonus : " + target.boostBonus);
    }

    private void Rage(Character target)
    {
        var mutliplier = UnityEngine.Random.Range(1.2f, 1.5f);
        var finalPower = (int)System.Math.Floor(caster.BasePower * mutliplier);
        print(caster.CName + " use Rage");
        //target.actionSystem.Tank(finalPower);
    }



    private void Tank(int amount)
    {
        caster.healthSystem.SubtractHealth(amount);
        print(caster.CName + " tanked " + amount + " damages");
    }

    private void Regenerate(int amount)
    {
        caster.healthSystem.AddHealth(amount);
        print(caster.CName + " regenerate " + amount + " HP");
    }
}
