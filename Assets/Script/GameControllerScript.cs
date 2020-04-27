using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;

    int score = 0;

    public static GameControllerScript instanse;

    public void incrementScore(int additional)
    {
        score += additional;
        scoreText.text = "Score: " + score;
    }
    
    void Start()
    {
        instanse = this;
    }

    
    void Update()
    {
        
    }
}
