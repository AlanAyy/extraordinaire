using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Should Always Be Positive
    public float jumpForce = 1.0f; // Should Always Be Positive

    private float xInput;
    private float yInput;

    
    public bool isAirborn; // Made Public Incase we soemthing that allows you to jump in the air

    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
       
        yInput = Input.GetAxisRaw("Vertical");

        //Maybe add code to get angle of the input?
       


        //It may be a good idea to allow for some deadzone for control sticks
        if (xInput > 0)
        {
            rigidBody.AddForce(new Vector2(moveSpeed, 0));
        }
        else if (xInput < 0)
        {
            rigidBody.AddForce(new Vector2(moveSpeed * -1, 0));
        }

        if (yInput > 0 && !isAirborn) {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isAirborn = true;
        }

        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isAirborn && collision.collider.tag.Equals("Ground")
             && collision.GetContact(0).normal.y > 0 ) { //Zero is used just since there was a contact there must be atleast one point. IDK why we'd use any other point
                                                         //Checing the normal vetor of the contact to make sure we hit the top of a platform and not the side 
            isAirborn = false;
        }
    }
    
}
