using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject QuitMenu;
    public UnityEngine.UI.Button QuitButton;
    public UnityEngine.UI.Button NoButton;
    public UnityEngine.UI.Button ResumeButton;

    // Use this for initialization
    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Pause();
	}

    public void MainMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Main Menu");
    }

    public void Keyboard()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Keyboard");
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void Credits()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Credits");
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            ResumeButton.Select();
            QuitMenu.SetActive(false);
        }
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    public void QuitPrompt()
    {
        QuitMenu.SetActive(true);
        NoButton.Select();
    }

    public void QuitPromptNo()
    {
        QuitMenu.SetActive(false);
        QuitButton.Select();

    }
}
