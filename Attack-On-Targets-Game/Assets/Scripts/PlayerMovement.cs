using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundChecker; 
    public LayerMask groumdMask; // potrzebuje oznaczenia ziemi jako Ground 
    public float groundDistance = 0.5f;
    public float gravity = -20f;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private float speed = 14f;
    
    [SerializeField]
    private float jumpHeight = 2f;

    [SerializeField]
    private AudioSource WalkAudio;

    [SerializeField]
    private AudioSource RunAudio;

    [SerializeField]
    private AudioSource CrouchWalkAudio;

    [SerializeField]
    private AudioSource jumpUpAudio;

    [SerializeField]
    private AudioSource jumpDownAudio;


    private bool isGrounded;
    private bool jump;
    private bool doubleJump;
    private bool crouched;
    private bool speeded;
    private float controlerHeight;
    
    private Vector3 velocity;
    private Vector3 move;


    // Update is called once per frame
    void LateUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groumdMask); //sprawdza czy postac stoi na ziemi

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            doubleJump = false;
            
            if(jump) //Po wyladowaniu wlacza dzwiek
            {
                jumpDownAudio.Play();
                jump = false;
            }
        }

        if (Input.GetButtonDown("Jump") && !doubleJump)
        {
            jump = true;
            if (!isGrounded)
                doubleJump = true;

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // z wzoru fizycznego na skok xD
            jumpUpAudio.Play();
        }

        //Aby dzialalo nalezy w inputach dodac wejscie o nazwie "Crouch"
        if (Input.GetButtonDown("Crouch"))
        {
            controlerHeight = GetComponent<CharacterController>().height; //przechwytywanie starej wysokosci chC
            GetComponent<CharacterController>().height = 1;       //zmniejszenie wysokosci chK
            crouched = true;
            speed /= 2; // zmniejszenie predkosci podczas kucania chodzimy o polowe wolniej
        }
        if(Input.GetButtonUp("Crouch"))
        {
            GetComponent<CharacterController>().height = controlerHeight; //przypisanie z powrotem strej wysokosci chC
            crouched = false;
            speed *= 2; //powrot to wczesniejszych ustawien
        }
        
        //Kiedy kliniemy lewy Alt zwiekszamy predkosc x2 podrzebuje wejscia "HighSpeed"
        if(Input.GetButtonDown("HighSpeed") && !crouched){ speed *= 2; speeded = true;}
        if(Input.GetButtonUp("HighSpeed") && !crouched) { speed /= 2; speeded = false;}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z; //do wektora move dopisywane sa wartosci x i z
        controller.Move(move * speed * Time.deltaTime);     //odpowiada za poruszanie sie w szerokosci i dlugosci geograf

        velocity.y += gravity * Time.deltaTime;             // podwojne mnozenie *Time.deltaTime wynika z wzoru na grawitacje
        controller.Move(velocity * Time.deltaTime);         //odpowiada za os Y

        PlayFootsteps(Mathf.Abs(x + z)); 

    }

    void PlayFootsteps(float speed1)
    {
        //Debug.Log("Speed: " + speed1 + "Grounded: " + isGrounded);

        if(speed1 == 0 || (!isGrounded && !crouched))
        {
            WalkAudio.Stop();
            RunAudio.Stop();
            CrouchWalkAudio.Stop();
        }

        if (isGrounded && !jump && speed1 > 0.2f && !WalkAudio.isPlaying && !speeded && !crouched)
        {
            WalkAudio.pitch = Random.Range(1f, 1.2f);
            WalkAudio.volume = Random.Range(0.7f, 1.1f);
            WalkAudio.Play();
        }

        if (speeded && speed1 > 0.2f && !RunAudio.isPlaying)
        {
            WalkAudio.Stop();
            RunAudio.Play();
        } 

        if(crouched && speed1 > 0.2f && !CrouchWalkAudio.isPlaying)
        {
            WalkAudio.Stop();
            RunAudio.Stop();
            CrouchWalkAudio.Play();
        }

    }

}
