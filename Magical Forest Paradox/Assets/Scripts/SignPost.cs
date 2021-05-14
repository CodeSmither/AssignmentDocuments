using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    // this is used to project the message the sign post has onto the textbox in the bottom left of the screen
    public Text PlayerTextBox;
    // this is the message the signpost contains
    public string SignPostMessage;
    // this is the player as a gameobject
    public GameObject Player;

    void OnTriggerStay2D(Collider2D col)
    {
        // this checks if the player is next to the sign post
        if(col.gameObject == Player)
        {
            // this displays the message the signpost has
            PlayerTextBox.text = SignPostMessage;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // this checks if the player has left the signpost radius
        if (col.gameObject == Player)
        {
            // this empties the textbox
            PlayerTextBox.text = " ";
        }
    }

}
