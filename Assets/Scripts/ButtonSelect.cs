using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour, ISelectHandler
{
    public AudioClip SelectButton;

    AudioSource audioSource;

    public void OnSelect(BaseEventData eventData)
    {
        PlaySound();
        print("cool");

    }


    public void PlaySound()
    {
        audioSource.PlayOneShot(SelectButton, 1f);
        print("cool2");
    }
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        print("cool3");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
