using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{// this starts the game when the start button is played
    public void GameBegin()
    {
        SceneManager.LoadScene("MainGame");
    }
}
