using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{

    private int timeTo = 3;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeTo)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
