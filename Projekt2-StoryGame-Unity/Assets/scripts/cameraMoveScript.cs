using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveScript : MonoBehaviour
{

    public GameObject[] rooms;
    public GameObject cam;

   
    private void changeCameraPosTo()
    {
        if (cam.transform.position == rooms[1].transform.position)
        {
            cam.transform.position = rooms[0].transform.position;
        }
        else
        {
            cam.transform.position = rooms[1].transform.position;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            changeCameraPosTo();
        }
    }
}
