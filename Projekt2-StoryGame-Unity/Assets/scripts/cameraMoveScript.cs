using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveScript : MonoBehaviour
{

    public GameObject[] camPoses;
    public GameObject[] playerStartPoses;
    public GameObject cam;

   /*
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
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(collision.tag == "Player")
        {
            changeCameraPosTo();
        }
        */

        switch (collision.tag)
        {
            case "Room1":
                cam.transform.position = camPoses[0].transform.position;
                this.transform.position = playerStartPoses[0].transform.position;
                break;

            case "Room2":
                cam.transform.position = camPoses[1].transform.position;
                this.transform.position = playerStartPoses[1].transform.position;
                break;

            case "Room3":
                cam.transform.position = camPoses[2].transform.position;
                break;

            case "Room4":
                cam.transform.position = camPoses[3].transform.position;
                break;

            case "Room5":
                cam.transform.position = camPoses[4].transform.position;
                break;
        }
    }
}
