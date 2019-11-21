using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManeger : MonoBehaviour
{

    void Start()
    {
        int sounds = FindObjectsOfType<soundManeger>().Length;

        if (sounds != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
