using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public CharacterController controller;
    public Transform groundChecker;
    public LayerMask groumdMask;

    [SerializeField]
    private float speed = 8f;
    public float gravity = -9.81f;
    public float groundDistance = 0.5f;
    public float jumpHeight = 2f;

    private bool isGrounded;
    private bool doubleJump;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groumdMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump") && !doubleJump)
        {
            if (!isGrounded)
                doubleJump = true;

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // z wzoru fizycznego na skok xD

        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime); //odpowiada za poruszanie sie w szerokosci i dlugosci geograf

        velocity.y += gravity * Time.deltaTime; // podwojne mnozenie *Time.deltaTime wynika z wzoru na grawitacje
        controller.Move(velocity * Time.deltaTime); //odpowiada za grawitacje (spadanie)
    }
}
