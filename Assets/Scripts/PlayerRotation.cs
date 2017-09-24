using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerRotate();
	}
    void PlayerRotate()
    {
        //WASD
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (Input.GetKeyDown(KeyCode.A) == true)
            {
                transform.rotation = Quaternion.Euler(0, -45, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        //Arrow Keys
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
