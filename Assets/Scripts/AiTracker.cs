using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class AiTracker : MonoBehaviour
    {

        public static AiTracker Instance;

        public bool TriggerBool;

        public int[] DialogueProgress;

        public bool VignetteBool = false;
        public bool VignetteEndBool = false;

        // Use this for initialization
        private void Awake()
        {
            Instance = this;
            Invoke("VignetteTrue", .5f);
        }

        void Start()
        {
            VignetteAndChromaticAberration.Instance.intensity = 1f;

        }

        // Update is called once per frame
        void Update()
        {
            VignetteEnd();
            Vignette();
            Trigger();
        }

        void Trigger()
        {
            if (TriggerBool == true)
            {
                AI.Instance.Triggered = true;
            }

            else
            {
                AI.Instance.Triggered = false;
            }
        }

        public void VignetteEnd()
        {
            print("sure1");
            if (VignetteEndBool == true)
            {
                print("sure2");
                VignetteAndChromaticAberration.Instance.intensity += .4f * Time.deltaTime;
                if (VignetteAndChromaticAberration.Instance.intensity >= 1f)
                {
                    VignetteAndChromaticAberration.Instance.intensity = 1f;
                    Application.LoadLevel("Main Menu");
                    print("sure3");
                }
            }
        }

        void Vignette()
        {
            if (VignetteBool == true)
            {
                if (VignetteEndBool == false)
                {
                    VignetteAndChromaticAberration.Instance.intensity -= .4f * Time.deltaTime;
                    if (VignetteAndChromaticAberration.Instance.intensity <= .225f)
                    {
                        VignetteAndChromaticAberration.Instance.intensity = .225f;
                        Player.Instance.CanMove = true;
                    }
                }

                else
                {
                    
                }  
            }
        }

        void VignetteTrue()
        {
            VignetteBool = true;
        }

       
    }
}
