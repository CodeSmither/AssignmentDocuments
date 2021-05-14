using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{// this is the objects needed for the start screen and the how to play screen
    public GameObject TheBorder;
    public GameObject TheMessage;
    public GameObject TheButton;
    public GameObject StartButton;
    public GameObject HowToPlayButton;
    public GameObject TheTitle;

    public void OpenPage()
    {// this turns on and off the objects needed for the hot to play screen
        TheBorder.SetActive(true);
        TheMessage.SetActive(true);
        TheButton.SetActive(true);
        StartButton.SetActive(false);
        HowToPlayButton.SetActive(false);
        TheTitle.SetActive(false);
    }
    public void ClosePage()
    {// this does the inverse of the previous function
        TheBorder.SetActive(false);
        TheMessage.SetActive(false);
        TheButton.SetActive(false);
        StartButton.SetActive(true);
        HowToPlayButton.SetActive(true);
        TheTitle.SetActive(true);
    }
}
