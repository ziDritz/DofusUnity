using UnityEngine;

public class IA : MonoBehaviour
{
    public Character controlledC;

    // Update is called once per frame
    void Update()
    {
        if (controlledC.isActive == true)
        {
            //controlledC.Rage(CharacterSystem.characters["Speedo"]);
            controlledC.EndTurn();
        }
    }
}