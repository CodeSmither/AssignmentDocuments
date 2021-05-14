 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesAndButtons : MonoBehaviour
{
    // this value stores if the all the buttons have been pressed
    public bool AllButtonsOn = false;
    // this stores the open and close animatons for the gate
    public Animator Gateanimator;
    // this is a game object which has a collider stopping people going through the closed gate
    public GameObject GateClosed;

    void Update()
    {// this checks if all the buttons have been activated
        if(Buttons.Button1OnorOff == true)
        {
            if (Buttons.Button2OnorOff == true)
            {
                if (Buttons.Button3OnorOff == true)
                {
                    if (Buttons.Button4OnorOff == true)
                    {
                        AllButtonsOn = true;
                    }
                }
            }
        }
     // this shows the gate openning if the player has pressed all the buttons
        Gateanimator.SetBool("AllButtonsOn", AllButtonsOn);
     
        GateCheck();
    }

    private void GateCheck()
    { // this checks if the gate is open or closed and if it has it removes the collider stoping them go through
        if(AllButtonsOn == true)
        {
            GateClosed.SetActive(false);
        }
        else 
        {
            GateClosed.SetActive(true);
        }
    }


}
