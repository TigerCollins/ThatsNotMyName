using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScreen : MonoBehaviour {

    public Text Dialogue;
    
    // Use this for initialization
	void Start ()
    {
        Dialogue.text = "Looks like I'm back home... I've changed a lot over the past few years. I already know that everyone back home is going to call me everything but " + PlayerPrefs.GetString("Middle Name") + "... Ugh, so mind numbing. Well, I may as well talk to everyone before I leave and try and not get too annoyed about the name situation...";

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ButtonPress()
    {
        Dialogue.text = "LOADING LEVEL";
        Invoke("LoadWorld", .1f);
    }

    public void LoadWorld()
    {
        Debug.Log("wow");
        Application.LoadLevel("World");
    }
}
