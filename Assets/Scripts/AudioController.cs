using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;     //Allows other scripts to call functions from SoundManager.    

    [Header("Sound Tracks")]
    public AudioSource World;                   //Drag a reference to the audio source which will play the music.
    public AudioSource Menu;                 //Drag a reference to the audio source which will play the music.

    [Header("Sound Effects")]
    public AudioSource soundFX;             //Drag a reference to the audio source which will play the sound effects.

    public float minPitch;
    public float maxPitch;

    

    //Scene Detection
    private int CurrentLevel;


    private void Update()
    {

    }

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (Instance == null)
            //if not, set it to this.
            Instance = this;
        //If instance already exists:
        else if (Instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
        OnLevelWasLoaded();
    }



    public void PlaySingle(AudioClip clip, bool pitchChange)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        soundFX.clip = clip;
        if (pitchChange == true)
        {
            float soundPitch = Random.Range(minPitch, maxPitch);
            soundFX.pitch = soundPitch;
        }
        //Play the clip.
        soundFX.Play();
    }

    public void PlaySinglePitch(AudioClip clip, float pitchChange)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        soundFX.clip = clip;
        float soundPitch = pitchChange;
        soundFX.pitch = soundPitch;

        //Play the clip.
        soundFX.Play();
    }

    public void OnLevelWasLoaded()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        if (CurrentLevel == 1)
        {
            if (!World.isPlaying)
            {
                World.Play();              //Play this sound
            }
            Menu.Stop();
        }

        else
        {
            if (!Menu.isPlaying)
            {
                Menu.Play();              //Play this sound
            }
            World.Stop();
        }
    }
    }
