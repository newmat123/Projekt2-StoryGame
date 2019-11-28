using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //hastigheden spilleren bevægersig
    public float speed = 5;

    Rigidbody2D rbody;
    Animator anim;
    public TextMeshProUGUI notesText;

    public static int pickUpValue;
    public GameObject deathScreen;

    void Start()
    {
        deathScreen.SetActive(false);
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        notesText.text = "Notes: 0/3";
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
            notesText.text = "Notes: " + pickUpValue + "/3";
        }
    }
}
