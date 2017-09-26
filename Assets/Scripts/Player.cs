using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    private Vector3 movement;

    private Component rigidBody;

    
    // Use this for initialization

    


    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMovement();
        ParticleUpdate();
    }

    void Update ()
    {
        
	}

    void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void ParticleUpdate()
    {
        bool Moving;
        if (Input.GetAxisRaw("Horizontal")!=1 && Input.GetAxisRaw("Vertical") != 1 && Input.GetAxisRaw("Horizontal") != 1 && Input.GetAxisRaw("Vertical") != -1 && Input.GetAxisRaw("Horizontal") != -1)
        {
            Moving = false;
        }

        else
        {
            Moving = true;
        }

        if (Moving == true)
        {
            if(GetComponent<ParticleSystem>().IsAlive() == false)
            {
                GetComponent<ParticleSystem>().Play();
            }

            else
            {

            }
        }

        else 
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
