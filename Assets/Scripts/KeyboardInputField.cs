using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyboardInputField : MonoBehaviour {

    public static KeyboardInputField Instance;

    public Text FirstName;
    public Text MiddleName;
    public Text LastName;

    public Text InputField;

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
        if(Input.GetKeyDown("space"))
        {
            
        }
    }

    public void UpdateInputField(string input)
    {
        if (input == "Space")
        {
            InputField.text += " ";
        }

        else
        {
            InputField.text += input;
        }
    }

    public void FirstNameField()
    {
        Debug.Log("name select" + NameSelection + " text is: " + InputField.text);
        if (NameSelection == 1)
        {
            FirstName.text = InputField.text;

        }

        if (NameSelection == 2)
        {
            MiddleName.text = InputField.text;
        }

        if (NameSelection == 3)
        {
        }

        if (NameSelection == 4)
        {
        }

    }


}
