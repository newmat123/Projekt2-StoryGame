using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 3;
    public Rigidbody2D RB;

    void Start()
    {
        
    }


    void FixedUpdate()
    {

        float inputHori = Input.GetAxis("Horizontal");
        float inputVerti = Input.GetAxis("Vertical");

        Vector2 movement  = new Vector2(inputHori, inputVerti);

        RB.velocity = movement * speed;

    }
}
