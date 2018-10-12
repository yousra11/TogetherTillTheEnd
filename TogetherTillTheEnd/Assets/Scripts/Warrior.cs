using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour // Player2
{
    float walkSpeed = 2.0f;
    float runSpeed = 5.5f;
    bool mRunning = true;

    public float jumpForce = 550.0f;

    int CanJump = 1;

    public bool HasDoubleJumpAbility;

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
        if (Input.GetButtonDown("WalkPlay1"))
        {
            mRunning = false;
        }
        if (Input.GetButtonUp("WalkPlay1"))
        {
            mRunning = true;
        }

        float moveSpeed = mRunning ? runSpeed : walkSpeed;

        if (Input.GetButton("LeftPlay1"))
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            //FaceDirection(-Vector2.right);
        }
        if (Input.GetButton("RightPlay1"))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            //FaceDirection(Vector2.right);
        }

        if (Input.GetButtonDown("JumpPlay1") && CanJump >= 1)
        {
            CanJump--;
            rigidBody2D.AddForce(Vector2.up * jumpForce);
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "PlayerTwo")
            if (HasDoubleJumpAbility)
                CanJump = 2;
            else
                CanJump = 1;
    }

    /*void OnCollisionExit2D(Collision2D col)     //If want to have the jump only usable from the ground
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "PlayerTwo")
            CanJump = false;
    }*/

    /*private void FaceDirection(Vector2 direction)
    {
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        spriteChild.rotation = rotation3D;
    }*/
}
