using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D RB;

    public float step = 5;
    public float radius;

    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if (dist < radius)
        { 
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step * Time.deltaTime);
        }
    }
}
