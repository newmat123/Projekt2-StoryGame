﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWon : MonoBehaviour
{
    public bool gameHasEnded = false;
    public Text Score_UIText = null; //Score variable
    public GameObject completeLevelUI;
    private int score;

    public void Start()
    {
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void Update()
    {
        score = PlayerMovement.pickUpValue;
        Score_UIText.text = "Notes: " + score.ToString();
        
    }
    
}