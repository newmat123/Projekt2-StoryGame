using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D RB;
    public float step = 5;

    void Start()
    {
        
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);

    }

    

}
