using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    private bool isOpen;

    void Start()
    {
        isOpen = false;
        pauseMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isOpen)
            {
                open();
            }
            else
            {
                close();
            }
        }
    }


    public void open()
    {
        Time.timeScale = 0f;
        isOpen = true;
        pauseMenu.SetActive(true);
    }

    public void close()
    {
        Time.timeScale = 1f;
        isOpen = false;
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
