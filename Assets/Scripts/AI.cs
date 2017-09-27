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

        //Trigger
        public bool Triggered;
        // Use this for initialization
        public void OnTriggerStay(Collider other)
        {
            if (other.tag == "AI")
            {
                LookAtPlayer();
                TextBox();
                DialogueBackground.SetActive(true);
                TalkCheck();//Constructor to check if everyone has been spoken too
                
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "AI")
            {
                //if something requires to happen on Ai entry
                AiTracker.Instance.TriggerBool = true;
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
        }

        private void Trigger()
        {
            if(AI.Instance.Triggered == true)
            {
                VignetteAndChromaticAberration.Instance.chromaticAberration += 20 * Time.deltaTime;
                if (VignetteAndChromaticAberration.Instance.chromaticAberration >= 200)
                {
                    VignetteAndChromaticAberration.Instance.chromaticAberration = 200;
                }

                var tempColor = RageFilter.color;
                tempColor.a += .1f*Time.deltaTime;
                if(tempColor.a >= .3922f)
                {
                    tempColor.a = .3922f;
                }
                RageFilter.color = tempColor;
            }

            if (AI.Instance.Triggered == false)
            {
                VignetteAndChromaticAberration.Instance.chromaticAberration -= 40 * Time.deltaTime;
                if (VignetteAndChromaticAberration.Instance.chromaticAberration <= 0)
                {
                    VignetteAndChromaticAberration.Instance.chromaticAberration = 0;
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
                Dialogue.text = "Ah yes. Welcome back " + FirstName + " " + LastName + "! Oh, hold on... What was that? UGH. I'm sorry... I know you prefer to go by your middle name, " + MiddleName + " Right? I'll try to remember that! But while you're back home, would you mind visiting everyone? We all miss you very much!";
                AiTracker.Instance.DialogueProgress[0] += 1;
            }

            if (DialogueTracker == 1)
            {
                Dialogue.text = "Wait a minute... I know that stench! Is that you " + FirstName + " ? What on earth are you doing back here? Why aren't you responding... Oh that's right, you go by some other name. What's your name again dudette?";
                AiTracker.Instance.DialogueProgress[1] += 1;
            }

            if (DialogueTracker == 2)
            {
                Dialogue.text = "Well well well, if it isn't the young " + LastName + " kid. Back on your adventures aye? I have some supplies for you young-... Please forgive me, but I seem to have forgotten your name kiddo";
                AiTracker.Instance.DialogueProgress[2] += 1;
            }

            if (DialogueTracker == 3)
            {
                Dialogue.text = "Oh hey " + FirstName + ", havent seen you in years, how've you been? Woah... whats wrong with you? Don't tell me I got your name wrong!?";
                AiTracker.Instance.DialogueProgress[3] += 1;
            }

            if (DialogueTracker == 3)
            {
                Dialogue.text = "HAH! I've seen you before on family photos " + FirstName + "! You haven't met me yet but I go by CERTIFIED WEEB around here! NANI? WHATS SO FUNNY " + LastName + "!? THE POWER OF ANIME COMPELS ME!!! AND NO I DON'T CARE FOR WHAT YOU WANT TO BE CALLED";
                AiTracker.Instance.DialogueProgress[4] += 1;
            }

            if (DialogueTracker == 4)
            {
                Dialogue.text = "Sorry " + FirstName + ". It's too dangerous to walk into the forest lately, so I'm on gaurd. It's good to see you again though!";
                AiTracker.Instance.DialogueProgress[5] += 1;
            }

            if (DialogueTracker == 5)
            {
                if (AiTracker.Instance.DialogueProgress[5] <= 0)
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
