using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D RB;
    public float step = 5;

    public float radius;

    void Start()
    {
        
    }

    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if (dist < radius)
        { 
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step*Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Hvis vi rammer et object med taget "Pickups"
        if (coll.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
        }
    }

}
