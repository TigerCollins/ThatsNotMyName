using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour {

    public static KeyScript Instance;
    public int NamePosition;

    public void Awake()
    {
        Instance = this;
    }

    public void KeyClicked()
    {
        KeyboardInputField.Instance.UpdateInputField(gameObject.name);
    }

    public void BackspaceClicked()
    {
        KeyboardInputField.Instance.UpdateInputField(gameObject.name);
    }

    public void ContinueClicked()
    {
        KeyboardInputField.Instance.NameSelection += 1;
        KeyboardInputField.Instance.NameField();
        KeyboardInputField.Instance.NameFields();

    }

    public void ConfirmSelection()
    {
        if (NamePosition == 3)
        {
            Application.LoadLevel("Dialogue");
        }
    }

    public void Update()
    {
        NamePosition = KeyboardInputField.Instance.NameSelection;
    }
}
