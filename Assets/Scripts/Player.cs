using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    // Use this for initialization

    


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMovement();
	}

    void PlayerMovement()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        }
    }
}
