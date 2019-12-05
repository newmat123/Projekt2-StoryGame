using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWon : MonoBehaviour
{
    public bool gameHasEnded = false;
    public Text Score_UIText = null; 
    public GameObject completeLevelUI;
    private int score;
    public int LevelWonValue;

    public void Update()
    {   
        //Henter variablen pickUpValue fra vores playerMovement script
        score = PlayerMovement.pickUpValue;

        //Checker om spilleren har samlet alle objecterne op
        if (score >= LevelWonValue)
        {
            //Sætter vores UI til aktivt
            completeLevelUI.SetActive(true);
        }

        //Teksten der står i spillet plus vores score variable der laves om til en string
        Score_UIText.text = "Items: " + score.ToString() +"/" + LevelWonValue; 
        
    }
    
}
