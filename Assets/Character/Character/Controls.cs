using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private Character controlledC;
    [SerializeField] private CharacterSystem characterSystem;

    private void Start()
    {
        characterSystem = GetComponentInParent<CharacterSystem>();
    }


}

