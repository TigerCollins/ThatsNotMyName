using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyboardInputField : MonoBehaviour {

    public static KeyboardInputField Instance;

    public string FirstName;
    public string MiddleName;
    public string LastName;

    public Text InputField;
    public Text PlayerName;

    public Text NamePrompt;
    public GameObject NamePromptObject;

    public int NameSelection = 0;



    // Use this for initialization
    void Awake ()
    {
        Instance = this;
       // FirstName.text = "blah";
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerName.text = "My name is " + FirstName + " " + MiddleName + " " + LastName;
        TextPrompt();
    }

    public void NameField()
    {
        if (NameSelection == 1)
        {
            NamePrompt.text = "Middle or Preferred Name...";//Easier to put this here than fix it (should be selection 2)
            if (InputField.text == "")
            {
                NameSelection -= 1;
            }
            else
            {
                FirstName = InputField.text;
                InputField.text = "";
            }
        }

        if (NameSelection == 2)
        {
            NamePrompt.text = "Last Name...";//Easier to put this here than fix it (should be selection 3)
            if (InputField.text == "")
            {
                NameSelection -= 1;
            }
            else
            {
                MiddleName = InputField.text;
                InputField.text = "";
            }
        }

        if (NameSelection == 3)
        {
            NamePrompt.text = "Please Confirm Your Selection...";
            if (InputField.text == "")
            {
                NameSelection -= 1;
            }
            else
            {
                LastName = InputField.text;
                InputField.text = "";
            }
        }

        if (NameSelection == 4)
        {
        }

    }

    public void TextPrompt()
    {
        
        if (InputField.text.Length == 0)
        {
            NamePromptObject.SetActive(true);
        }

        else
        {
            NamePromptObject.SetActive(false);
        }
    }

    public void UpdateInputField(string input)
    {
        if (input == "Backspace")
        {
            InputField.text = InputField.text.Substring(0, InputField.text.Length - 1);
        }

        else
        {
            InputField.text += input;
        }
    }

    


}
