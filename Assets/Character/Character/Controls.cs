using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Character controlledC;

    private void Awake()
    {
        controlledC = GetComponent<Character>();
    }
    // Update is called once per frame
    void Update()
    {
        if (controlledC.isActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //controlledC.Heal(CharacterSystem.characters["Undead"]);
                controlledC.EndTurn();
            }
        }
    }

}

