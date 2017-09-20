using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour {


    public void Awake()
    {

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
    }

}
