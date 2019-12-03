using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWon : MonoBehaviour
{
    public bool gameHasEnded = false;
    public Text Score_UIText = null; //Score variable
    public GameObject completeLevelUI;
    private int score;

    public int LevelWonValue;

    public void Start()
    {
    }

    public void Update()
    {
        score = PlayerMovement.pickUpValue;

        if (score >= LevelWonValue)
        {
            completeLevelUI.SetActive(true);
        }

        //Teksten der står i spillet plus vores score variable der laves om til en string
        Score_UIText.text = "Items: " + score.ToString(); 
        
    }
    
}
