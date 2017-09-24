using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour {

    public GameObject PlayerObject;
    public Text Dialogue;
    public string[] DialogueText;

    //Name variables
    private string FirstName;
    private string MiddleName;
    private string LastName;

    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "AI")
        {
            LookAtPlayer();
            RandomTextBox();
            Dialogue.text = "Oh hey! Is that... " + FirstName + " Senpai!!!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AI")
        {
            Dialogue.text = "";
        }
    }

    private void Awake()
    {
        FirstName = PlayerPrefs.GetString("First Name");
        MiddleName = PlayerPrefs.GetString("Middle Name");
        LastName = PlayerPrefs.GetString("Last Name");
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RandomTextBox();

    }

    void LookAtPlayer()
    {
        transform.LookAt(PlayerObject.transform);
    }

    void RandomTextBox()
    {

    }
}
