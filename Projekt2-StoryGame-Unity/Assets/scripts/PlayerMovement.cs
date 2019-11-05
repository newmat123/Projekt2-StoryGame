using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //hastigheden spilleren bevægersig
    public float speed = 3;

    public Rigidbody2D RB;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        //modtager input
        float inputHori = Input.GetAxis("Horizontal");
        float inputVerti = Input.GetAxis("Vertical");

        //samler inputsne i en vector2
        Vector2 movement  = new Vector2(inputHori, inputVerti);

        //sætter spillerens fart * hastigheden.
        RB.velocity = movement * speed;

    }
}
