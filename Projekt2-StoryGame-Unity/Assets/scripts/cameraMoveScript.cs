using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveScript : MonoBehaviour
{

    public GameObject[] camPoses;
    public GameObject[] Room1;
    public GameObject[] Room2;
    public GameObject[] Room3;


    public GameObject cam;

    public void ChangeRoomTo(int i, GameObject j)
    {
        //flytter spiller og cam til pos x
        cam.transform.position = camPoses[i].transform.position;
        this.transform.position = j.transform.position;

        //eventuelt trigger dør lyd her

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case "Enemy":
                Debug.Log("yes");
                break;
            case "Room1":
                //køre funktionen og siger hvor der skal skiftes til
                ChangeRoomTo(0, Room1[0]);
                break;

            case "Room11":
                ChangeRoomTo(0, Room1[1]);
                break;

            case "Room2":
                ChangeRoomTo(1, Room2[0]);
                break;

            case "Room3":
                ChangeRoomTo(2, Room3[0]);
                break;

        }
    }
}
