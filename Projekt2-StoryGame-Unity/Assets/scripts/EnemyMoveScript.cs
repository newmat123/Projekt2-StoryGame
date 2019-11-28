using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{

    //holder spillerens position, så fjenden ved hvor den skal bevæge sig hen.
    public GameObject Player;

    //farten fjenden bevæger sig med
    public float step = 5;

    //x er det rum som enemyen befindersig i.
    public int x;

    void Update()
    {
        //er x lig med room, som er defineret i cameraMoveScript, så gå mod spilleren, ellers stå stille.
        if (x == FindObjectOfType<cameraMoveScript>().Room)
        { 
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step * Time.deltaTime);
        }
    }
}
