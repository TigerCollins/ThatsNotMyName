using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance;

    public float speed;
    private Vector3 movement;

    private Component rigidBody;
    Quaternion oldRotation;

    public bool CanMove;

    public AudioSource PlayerMovementNoise;
    public float minPitch;
    public float maxPitch;

    // Use this for initialization
    private void Awake()
    {
        GetComponent<ParticleSystem>().Stop();
        Instance = this;
        speed = 6f;
        CanMove = false;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMovement();
        
        UpdateRotation();
    }

    void Update()
    {
        ParticleUpdate();
    }

    void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if(CanMove == true)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                transform.rotation = Quaternion.LookRotation(movement);
                transform.Translate(movement * speed * Time.deltaTime, Space.World);
                MovementNoise();
            }

            else
            {
                UpdateRotation();
            }
            
            print("fkn rip");
        } 
    }


    public void MovementNoise()
    {
        PlayerMovementNoise.pitch = Random.Range(minPitch, maxPitch);
        if (PlayerMovementNoise.isPlaying == false)
        {
            PlayerMovementNoise.Play();
        }
    }
    void ParticleUpdate()
    {
        
        if (CanMove == true)
        {
            // If no keyboard press, moving is false.
            if (Input.GetAxisRaw("Horizontal") != 1 && Input.GetAxisRaw("Vertical") != 1 && Input.GetAxisRaw("Horizontal") != 1 && Input.GetAxisRaw("Vertical") != -1 && Input.GetAxisRaw("Horizontal") != -1)
            {
                GetComponent<ParticleSystem>().Stop();
            }

            else
            {
                if (transform.rotation == oldRotation)
                {
                    if (GetComponent<ParticleSystem>().IsAlive() == false)
                    {
                        GetComponent<ParticleSystem>().Play();
                    }
                }

                else
                {
                    GetComponent<ParticleSystem>().Play();
                    Debug.Log("Direction Changed!");
                }

            }
        }
        
    }

    void UpdateRotation()
    {
        oldRotation = transform.rotation;
        Debug.Log(oldRotation);
    }
}
