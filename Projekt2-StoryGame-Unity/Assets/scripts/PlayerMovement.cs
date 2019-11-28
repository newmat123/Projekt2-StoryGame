using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //hastigheden spilleren bevægersig
    public float speed = 5;

    Rigidbody2D rbody;
    Animator anim;

    public static int pickUpValue;
    public GameObject deathScreen;

    void Start()
    {
        deathScreen.SetActive(false);
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
        //hvis den rammer et pickup. gør det her.
        if (coll.gameObject.tag == "Pickups")
        {
            Destroy(coll.gameObject);
            pickUpValue++;
        }
    }
}
