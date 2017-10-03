using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.ImageEffects
{
    public class AI : MonoBehaviour {

        public static AI Instance;
        public Image RageFilter;

        public GameObject PlayerObject;
        public Text Dialogue;

        //Name variables
        private string FirstName;
        private string MiddleName;
        private string LastName;

        //Dialogue
        public int DialogueTracker = 0;
        public GameObject DialogueBackground;

        public bool DialogueProgressCheck;

        //Sound
        public AudioSource TriggeredNoise;

        //Trigger
        public bool Triggered;
        // Use this for initialization
        public void OnTriggerStay(Collider other)
        {
            if (other.tag == "AI")
            {
                LookAtPlayer();

                DialogueBackground.SetActive(true);
                
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "AI")
            {
                //if something requires to happen on Ai entry
                AiTracker.Instance.TriggerBool = true;
                TextBox();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.tag == "AI")
            {
                Dialogue.text = "";
                DialogueBackground.SetActive(false);
                AiTracker.Instance.TriggerBool = false;
            }
        }

        private void Awake()
        {
            FirstName = PlayerPrefs.GetString("First Name");
            MiddleName = PlayerPrefs.GetString("Middle Name");
            LastName = PlayerPrefs.GetString("Last Name");

            DialogueBackground.SetActive(false);
            DialogueProgressCheck = false;

            Instance = this;

        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Trigger();
            TalkCheck();//Constructor to check if everyone has been spoken too
        }

        private void Trigger()
        {


            if (AI.Instance.Triggered == true && DialogueProgressCheck == false)
            {
                VignetteAndChromaticAberration.Instance.chromaticAberration += 20 * Time.deltaTime;
                if (VignetteAndChromaticAberration.Instance.chromaticAberration >= 200)
                {
                    VignetteAndChromaticAberration.Instance.chromaticAberration = 200;
                }

                var tempColor = RageFilter.color;
                
                tempColor.a += .1f * Time.deltaTime;
                if (tempColor.a >= .3922f)
                 {
                    tempColor.a = .3922f;
                 }

                RageFilter.color = tempColor;
                print(tempColor.a);

                if (DialogueProgressCheck == true)
                {

                }

                else
                {
                    TriggeredNoise.volume += .05f * Time.deltaTime;
                    if (TriggeredNoise.volume >= .1f)
                    {
                        TriggeredNoise.volume = .1f;
                    }
                }

            }

            if (AI.Instance.Triggered == false)
            {
                VignetteAndChromaticAberration.Instance.chromaticAberration -= 40 * Time.deltaTime;
                if (VignetteAndChromaticAberration.Instance.chromaticAberration <= 0)
                {
                    VignetteAndChromaticAberration.Instance.chromaticAberration = 0;
                }

                TriggeredNoise.volume -= .1f * Time.deltaTime;
                if (TriggeredNoise.volume <= 0f)
                {
                    TriggeredNoise.volume = 0f;
                }

                var tempColor = RageFilter.color;
                tempColor.a -= .2f * Time.deltaTime;
                if (tempColor.a <= 0f)
                {
                    tempColor.a = 0f;
                }
                RageFilter.color = tempColor;
            }
                
        }

        void LookAtPlayer()
        {
            transform.LookAt(PlayerObject.transform);
        }

        void TextBox()
        {
            
            if (DialogueTracker == 0)
            {
                if (DialogueProgressCheck == false)
                {
                    Dialogue.text = "Ah yes. Welcome back " + FirstName + " " + LastName + "! Oh, hold on... What was that? UGH. I'm sorry... I know you prefer to go by your middle name, " + MiddleName + " Right? I'll try to remember that! But while you're back home, would you mind visiting everyone? We all miss you very much!";
                    AiTracker.Instance.DialogueProgress[0] += 1;
                }

                if (DialogueProgressCheck == true)
                {
                    Dialogue.text = "Hey, " + MiddleName + "! Head north of here to talk to our leader, he was wanting you!";
                }
            }

            if (DialogueTracker == 1)
            {
                if (DialogueProgressCheck == false)
                {
                    Dialogue.text = "Wait a minute... I know that stench! Is that you " + FirstName + " ? What on earth are you doing back here? Why aren't you responding... Oh that's right, you go by some other name. What's your name again dudette?";
                    AiTracker.Instance.DialogueProgress[1] += 1;
                }

                if (DialogueProgressCheck == true)
                {
                    Dialogue.text = "OK " + MiddleName + ", so maybe you dont smell... wait... what? WHAT DO YOU MEAN I SMELL!?";
                }
            }

            if (DialogueTracker == 2)
            {
                if (DialogueProgressCheck == false)
                {
                    Dialogue.text = "Well well well, if it isn't the young " + LastName + " kid. Back on your adventures aye? I have some supplies for you young-... Please forgive me, but I seem to have forgotten your name kiddo";
                    AiTracker.Instance.DialogueProgress[2] += 1;
                }

                if (DialogueProgressCheck == true)
                {
                    Dialogue.text = "IVE GOT IT NOW! You go by " + MiddleName + ", don't you? It's good to see you again while you were here though";
                }
            }

            if (DialogueTracker == 3)
            {
                if (DialogueProgressCheck == false)
                {
                    Dialogue.text = "Oh hey " + FirstName + ", havent seen you in years, how've you been? Woah... whats wrong with you? Don't tell me I got your name wrong!?";
                    AiTracker.Instance.DialogueProgress[3] += 1;
                }

                if (DialogueProgressCheck == true)
                {
                    Dialogue.text = "OK " + MiddleName + ", so maybe you dont smell... wait... what? WHAT DO YOU MEAN I SMELL!?";
                }
            }

            if (DialogueTracker == 3)
            {
                if (DialogueProgressCheck == false)
                {
                    Dialogue.text = "HAH! I've seen you before on family photos " + FirstName + "! You haven't met me yet but I go by CERTIFIED WEEB around here! NANI? WHATS SO FUNNY " + LastName + "!? THE POWER OF ANIME COMPELS ME AND NO, I DON'T CARE FOR WHAT YOU WANT TO BE CALLED!!!";
                    AiTracker.Instance.DialogueProgress[4] += 1;
                }

                if (DialogueProgressCheck == true)
                {
                    Dialogue.text = "Don't give me sass " + MiddleName + ". Omae wa mou shindeiru, that means that you're already dead! Don't come back here again if you know what's good for you kid!";
                }
            }

            if (DialogueTracker == 4)
            {
                if (DialogueProgressCheck == false)
                {
                    Dialogue.text = "Sorry " + FirstName + ". It's too dangerous to walk into the forest lately, so I'm on gaurd. It's good to see you again though!";
                    AiTracker.Instance.DialogueProgress[5] += 1;
                }

                if (DialogueProgressCheck == true)
                {
                    Dialogue.text = "It's still to dangerous this way! Try going north of here " + MiddleName + ", the exit should be free by now. Oh, and sorry about the whole name thing...";
                }
            }

            if (DialogueTracker == 5)
            {
                if (DialogueProgressCheck == false)
                {
                    Dialogue.text = "Sorry " + FirstName + " but I'm not letting you through until you talk to everyone. Come back once you've found everyone.";

                    
                }

                if (DialogueProgressCheck == true)
                {
                    Dialogue.text = "So... this is awkward. I was told that your name is " + MiddleName + "... I'm actually so sorry about that, please feel free to leave and come back soon " + MiddleName + " " + LastName;
                    Invoke("GameOver", 1);
                }
            }
        }

        void TalkCheck()
        {
            if (AiTracker.Instance.DialogueProgress[0] > 0)
            {
                if (AiTracker.Instance.DialogueProgress[1] > 0)
                {
                    if (AiTracker.Instance.DialogueProgress[2] > 0)
                    {
                        if (AiTracker.Instance.DialogueProgress[3] > 0)
                        {
                            if (AiTracker.Instance.DialogueProgress[4] > 0)
                            {
                                if (AiTracker.Instance.DialogueProgress[5] > 0)
                                {
                                    DialogueProgressCheck = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        void GameOver()
        {
            AiTracker.Instance.VignetteEndBool = true;
        }
    }
}
