using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void Keyboard()
    {
        Application.LoadLevel("Keyboard");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
