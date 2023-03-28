using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField] private Character controlledC;
    [SerializeField] private CharacterSystem characterSystem;

    private void Start()
    {
        characterSystem = GetComponentInParent<CharacterSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlledC.isActive == true)
        {
            //controlledC.actionSystem.Rage(characterSystem.charactersDictionnary["Speedo"]);
            controlledC.EndTurn();
        }
    }
}
