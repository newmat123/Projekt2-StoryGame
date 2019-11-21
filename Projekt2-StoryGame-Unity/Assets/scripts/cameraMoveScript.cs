using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveScript : MonoBehaviour
{

    public AudioSource doorEffect;

    //holder alle cameraets positioner.
    public GameObject[] camPoses;

    //holder alle startpositioner til spileren i hver rum.
    public GameObject[] Room1;
    public GameObject[] Room2;
    public GameObject[] Room3;
    public GameObject[] Room4;

    //Room er en variabel, som fjenden bruger for at finde ud af hvilke rum spilleren er i.
    public int Room;

    //holder cameraet.
    public GameObject cam;

    private void Start()
    {
        Room = 1;
    }

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
        
        //switch tjækker om der er nogle af de definerede cases, som er ens med collision.name.
        switch (collision.name)
        {
            case "Room2To1":
                Instantiate(doorEffect);
                //køre funktionen og siger hvor der skal skiftes til
                ChangeRoomTo(0, Room1[0], 5f);
                //definere det rum spilleren befinder sig i.
                Room = 1;
                break;

            case "Room3To1":
                Instantiate(doorEffect);
                ChangeRoomTo(0, Room1[1], 5f);
                Room = 1;
                break;

            case "Room1To2":
                Instantiate(doorEffect);
                ChangeRoomTo(1, Room2[0], 5f);
                Room = 2;
                break;

            case "Room1To3":
                Instantiate(doorEffect);
                ChangeRoomTo(2, Room3[0], 5f);
                Room = 3;
                break;

            case "Room3To4":
                Instantiate(doorEffect);
                ChangeRoomTo(3, Room4[0], 12f);
                Room = 4;
                break;

            case "Room4To3":
                Instantiate(doorEffect);
                ChangeRoomTo(2, Room3[1], 5f);
                Room = 3;
                break;

        }
    }
}
