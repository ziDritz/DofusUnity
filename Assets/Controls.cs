using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public enum Controller { PLAYER, IA }

    public Controller controller;
    public Character controlledC;

    // Update is called once per frame
    void Update()
    {
        switch (controller)
        {
            case Controller.PLAYER:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //controlledC.Heal();

                }
                break;

        }
       
    }
}
