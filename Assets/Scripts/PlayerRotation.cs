using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public float speed = 6f;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       

        //  PlayerRotateWASD();
        // PlayerRotateArrow();
    }
    void PlayerRotateWASD()
    {
        //WASD
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
            print("Test for WA");
        }

        else if (Input.GetKeyDown(KeyCode.S) == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if (Input.GetKeyDown(KeyCode.D) == true)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else if (Input.GetKeyDown(KeyCode.A) == true)
        {
           transform.rotation = Quaternion.Euler(0, -90, 0);
        }

    }

    void PlayerRotateArrow()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
