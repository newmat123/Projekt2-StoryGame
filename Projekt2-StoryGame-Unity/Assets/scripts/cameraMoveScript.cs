using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveScript : MonoBehaviour
{

    public GameObject[] camPoses;
    public GameObject[] Room1;
    public GameObject[] Room2;
    public GameObject[] Room3;
    public GameObject[] Room4;


    public GameObject cam;

    public void ChangeRoomTo(int i, GameObject j, float camSize)
    {
        //flytter spiller og cam til pos x
        cam.transform.position = camPoses[i].transform.position;
        this.transform.position = j.transform.position;
        Camera.main.orthographicSize = camSize;


        //eventuelt trigger dør lyd her

        //Få enemy til at følge efter spilleren

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.name)
        {
            case "Room2To1":
                //køre funktionen og siger hvor der skal skiftes til
                ChangeRoomTo(0, Room1[0], 5f);
                break;

            case "Room3To1":
                ChangeRoomTo(0, Room1[1], 5f);
                break;

            case "Room1To2":
                ChangeRoomTo(1, Room2[0], 5f);
                break;

            case "Room1To3":
                ChangeRoomTo(2, Room3[0], 5f);
                break;

            case "Room3To4":
                ChangeRoomTo(3, Room4[0], 12f);
                break;

            case "Room4To3":
                ChangeRoomTo(2, Room3[1], 5f);
                break;

        }
    }
}
