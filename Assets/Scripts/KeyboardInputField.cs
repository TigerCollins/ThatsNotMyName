using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyboardInputField : MonoBehaviour {

    public static KeyboardInputField Instance;

    //String name variables
    public string FirstName;
    public string MiddleName;
    public string LastName;

    //Text for inputfields (as a variable)
    public Text InputField;
    public Text PlayerName;

    //Variables for name prompts
    public Text NamePrompt;
    public GameObject NamePromptObject;

    //Variable to keep track of first, second and last name
    public int NameSelection = 0;

    //Keeps track of initial name input and repetitive inputs
    public bool InitalInput;
    public string RepeatFirstName;
    public string RepeatPreferredName;
    public string RepeatLastName;




    // Use this for initialization
    void Awake ()
    {
        Instance = this;
        InitalInput = true;

        RepeatFirstName = PlayerPrefs.GetString("First Name");
        RepeatPreferredName = PlayerPrefs.GetString("Middle Name");
        RepeatLastName = PlayerPrefs.GetString("Last Name");
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerName.text = "My name is " + FirstName + " " + MiddleName + " " + LastName;
        TextPrompt();
        PlayerNamePreview();
    }

    public void PlayerNamePreview()
    {
        if (InitalInput == true)
        {
            PlayerName.text = "My name is " + FirstName + " " + MiddleName + " " + LastName;
        }

        if (InitalInput == false)
        {
            PlayerName.text = "Yeah, my name is " + RepeatFirstName + " but I'd prefer to go by" + MiddleName;
        }
    }
    public void NameField()
    {
        //Initial Name Input
        if (InitalInput == true)
        {
            NameSelection = 0;
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
                    PlayerPrefs.SetString("First Name", FirstName);
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
                    PlayerPrefs.SetString("Middle Name", MiddleName);
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
                    PlayerPrefs.SetString("Last Name", LastName);
                }
            }
        }
        //Secondary Name Input
        if (InitalInput == false)
        {
            NameSelection = 0;
            FirstName = RepeatFirstName;
            LastName = RepeatLastName;
            if (NameSelection == 0)
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
