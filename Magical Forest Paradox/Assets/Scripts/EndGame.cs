using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // this checks if the main objective has been achieved
    public bool Victoryreached = false;
    // these are the features used on the game over screen being the background and two buttons being restart and quit
    public GameObject GameOverScreen;
    public GameObject GameOverButton;
    public GameObject GameOverButton2;
    // this is the screen shown if the player wins
    public GameObject VictoryScreen;
    // this is the eye jem which the player must reach to win
    public GameObject TheEndPortal;


    public void Update()
    {
        // this activates the game over screen if the players health reaches 0
        if (PlayerHit.Health <= 0)
        {
            GameOverScreen.SetActive(true);
            GameOverButton.SetActive(true);
            GameOverButton2.SetActive(true);
        } 
        // this activates the victory screen when the objective has been achieved then activates Gameover
        if (Victoryreached == true)
        {
            VictoryScreen.SetActive(true);
            Invoke("GameOver", 10f);
        }
        
    }
    // this resets the main values of the game when restarting the game these being the objective gate and the buttons as well as resets the scene
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
        PlayerHit.Health = 3;
        Buttons.Button1OnorOff = false;
        Buttons.Button2OnorOff = false;
        Buttons.Button3OnorOff = false;
        Buttons.Button4OnorOff = false;
    }
    // this resets the main values of the game and then also returns the player to the main menu
    public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerHit.Health = 3;
        Buttons.Button1OnorOff = false;
        Buttons.Button2OnorOff = false;
        Buttons.Button3OnorOff = false;
        Buttons.Button4OnorOff = false;
    }
    // this checks if the player has reached the objective point being the eye jem portal
    private void OnTriggerEnter2D(Collider2D EndPortal)
    {
        if(EndPortal.gameObject == TheEndPortal)
        {
            Victoryreached = true;
        }
    }
}
