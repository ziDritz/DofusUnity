using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    public Character controlledC;

    // Update is called once per frame
    void Update()
    {
        if (controlledC.isActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //controlledC.Heal();
                controlledC.Heal(CharacterSystem.characters["Undead"]);
                controlledC.EndTurn();
            }
        }
    }

}

