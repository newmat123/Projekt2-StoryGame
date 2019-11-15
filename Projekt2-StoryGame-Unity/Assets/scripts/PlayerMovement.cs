using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //hastigheden spilleren bevægersig
    public float speed = 5;

    Rigidbody2D rbody;

    Animator anim;

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

        //Sørger for at spilleren kan animeres når den bevæger sig
        if (movement != Vector2.zero)
        {
            anim.SetFloat("X", inputHori);
            anim.SetFloat("Y", inputVerti);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Hvis vi rammer et object med taget "Pickups"
        if (coll.gameObject.tag == "Pickups")
        {
            //Skal den fjerne objektet og tilføje 1 til "pickUpValue"
            Destroy(coll.gameObject);
            pickUpValue++;
        }
    }
}
