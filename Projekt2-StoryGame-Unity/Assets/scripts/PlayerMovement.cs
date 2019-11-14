using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //hastigheden spilleren bevægersig
    public float speed = 5;

    Rigidbody2D rbody;

    Animator anim;

    public GameObject pickups;

    public int pickUpValue;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {

        
        //modtager input
        float inputHori = Input.GetAxis("Horizontal");
        float inputVerti = Input.GetAxis("Vertical");

        //samler inputsne i en vector2
        Vector2 movement  = new Vector2(inputHori, inputVerti);

        //sætter spillerens fart * hastigheden.
        rbody.velocity = movement * speed;

        if (movement != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("X", inputHori);
            anim.SetFloat("Y", inputVerti);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pickups")
        { 
            Destroy(pickups);
            pickUpValue++;
        }
    }
}
