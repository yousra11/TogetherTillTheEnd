using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour // Player1
{
    float walkSpeed = 2.0f;
    float runSpeed = 5.5f;
    bool mRunning = true;

    public float jumpForce = 550.0f;

    bool CanJump = true;

    public bool HasTPAbility = false;

    public GameObject tpShadow;

    Rigidbody2D rigidBody2D;
    Transform spriteChild;
    Transform groundCheck;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        //spriteChild = transform.Find("Player1");
    }

    void Update()
    {
        MoveCharacter();

    }


    private void MoveCharacter()
    {
        if (Input.GetButtonDown("WalkPlay2"))
        {
            mRunning = false;
        }
        if (Input.GetButtonUp("WalkPlay2"))
        {
            mRunning = true;
        }

        float moveSpeed = mRunning ? runSpeed : walkSpeed;

        if (Input.GetButton("LeftPlay2"))
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            //FaceDirection(-Vector2.right);
        }
        if (Input.GetButton("RightPlay2"))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            //FaceDirection(Vector2.right);
        }

        if (Input.GetButtonDown("JumpPlay2") && CanJump)
        {
            CanJump = false;
            rigidBody2D.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetButtonDown("TPAbilityPlay2") && HasTPAbility)
        {
            Teleport();
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "PlayerOne")
            CanJump = true;
    }

    void Teleport()
    {
        transform.position = new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z); //Simple Teleport
        //Instantiate(tpShadow, new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z), transform.rotation); //Teleport Using Shadow
    }

    /*void OnCollisionExit2D(Collision2D col)   //If want to have the jump only usable from the ground
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "PlayerOne")    
            CanJump = false;
    }*/

    /*private void FaceDirection(Vector2 direction)
    {
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        spriteChild.rotation = rotation3D;
    }*/
}
