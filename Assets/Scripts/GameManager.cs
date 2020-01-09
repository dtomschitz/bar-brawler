using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver = false;

    public GameObject gameOverUI;


    void Update()
    { 
        if (gameIsOver)
        {
            return;
        }
        
        if (Input.GetKeyDown("y"))
        {
            EndGame();
        }

        if (PlayerStats.CurrentHealth <= 0)
        {
            EndGame();
        }

        void EndGame()
        {
            gameIsOver = true;

            gameOverUI.SetActive(true);
        }
    }

}
