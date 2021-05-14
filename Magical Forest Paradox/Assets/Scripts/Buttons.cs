using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // these 4 buttons are the pressure plates scattered througout the world
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    // this checks which button this object is connected to
    public GameObject ThisObject;
    // this checks the current state of each pressure plate being weighted or not as true or false
    public static bool Button1OnorOff = false;
    public static bool Button2OnorOff = false;
    public static bool Button3OnorOff = false;
    public static bool Button4OnorOff = false;
    // these are the animators of each button
    public Animator Buttonanimator;
    public Animator Buttonanimator2;
    public Animator Buttonanimator3;
    public Animator Buttonanimator4;

    public void Update()
    {
        // this sends the true or false value to the animator to make them look weighted or not
        Buttonanimator.SetBool("ButtonOnOff", Button1OnorOff);
        Buttonanimator2.SetBool("ButtonOnOff", Button2OnorOff);
        Buttonanimator3.SetBool("ButtonOnOff", Button3OnorOff);
        Buttonanimator4.SetBool("ButtonOnOff", Button4OnorOff);
    }

    private void OnTriggerEnter2D(Collider2D BolldierCollider)
    {
        // this checks if any of the buttons has a bollder placed on top of it
        if (BolldierCollider.gameObject.tag == "Bollder")
        {
            if(Button1 == ThisObject)
            {
                Button1OnorOff = true;
            }
            if (Button2 == ThisObject)
            {
                Button2OnorOff = true;
            }
            if (Button3 == ThisObject)
            {
                Button3OnorOff = true;
            }
            if (Button4 == ThisObject)
            {
                Button4OnorOff = true;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D BolldierCollider)
    {   // this checks if a bollder has been removed from any of the buttons
        if (BolldierCollider.gameObject.tag == "Bollder")
        {
            if (Button1 == ThisObject)
            {
                Button1OnorOff = false;
            }
            if (Button2 == ThisObject)
            {
                Button2OnorOff = false;
            }
            if (Button3 == ThisObject)
            {
                Button3OnorOff = false;
            }
            if (Button4 == ThisObject)
            {
                Button4OnorOff = false;
            }
        }
        // this checks if the player has used their hammer on a button and makes them waited if they have
        if (BolldierCollider.gameObject.tag == "Hammer")
        {
            if (Button1 == ThisObject)
            {
                Button1OnorOff = true;
            }
            if (Button2 == ThisObject)
            {
                Button2OnorOff = true;
            }
            if (Button3 == ThisObject)
            {
                Button3OnorOff = true;
            }
            if (Button4 == ThisObject)
            {
                Button4OnorOff = true;
            }
            // this sets a time keeping the button weighted for only a few seconds stopping exploits by only using the hammer
            Invoke("HammerEnd", 5f);
        }
    }

    public void HammerEnd()
    {   // this disables the weight after the hammer effect has finished
        if (Button1 == ThisObject)
        {
            Button1OnorOff = false;
        }
        if (Button2 == ThisObject)
        {
            Button2OnorOff = false;
        }
        if (Button3 == ThisObject)
        {
            Button3OnorOff = false;
        }
        if (Button4 == ThisObject)
        {
            Button4OnorOff = false;
        }
    }
}
