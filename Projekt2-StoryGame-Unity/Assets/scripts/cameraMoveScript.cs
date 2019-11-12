using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveScript : MonoBehaviour
{

    public GameObject[] camPoses;
    public GameObject[] playerStartPoses;

    public GameObject cam;

    public void ChangeRoomTo(int i, int j)
    {
        //flytter spiller og cam til pos x
        cam.transform.position = camPoses[i].transform.position;
        this.transform.position = playerStartPoses[j].transform.position;

        //eventuelt trigger dør lyd her

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case "Room1":
                //køre funktionen og siger hvor der skal skiftes til
                ChangeRoomTo(0, 0);
                break;

            case "Room11":
                ChangeRoomTo(0, 3);
                break;

            case "Room2":
                ChangeRoomTo(1, 1);
                break;

            case "Room3":
                ChangeRoomTo(2, 2);
                break;

            case "Room4":
                ChangeRoomTo(3, 3);
                break;

            case "Room5":
                ChangeRoomTo(4, 4);
                break;
        }
    }
}
