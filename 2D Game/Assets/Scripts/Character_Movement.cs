using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {

	// Player Movement Variables
	public int MoveSpeed;
	public float JumpHeight;
	private bool doubleJump;

	//Player Grounded Variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask WhatIsGround;
	private bool grounded;

	//Non-Slide Player
	private float moveVelocity;

	// Use this for initialization
	void Start () {

	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
	}

	// Update is called once per frame
	void Update () {

		//Code makes charater jump
		if(Input.GetKeyDown (KeyCode.Space)&& grounded){
			Jump();
		}

		//Double Jump Code
		if(grounded)
			doubleJump = false;

		if(Input.GetKeyDown (KeyCode.Space)&& !doubleJump && !grounded){
			Jump();
			doubleJump = true;
		}
		//Non-Slide Player
		moveVelocity = 0f;

		//This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.D)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = MoveSpeed;
		}
		if(Input.GetKey (KeyCode.A)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -MoveSpeed;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(0.2f,0.2f,1f);

		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-0.2f,0.2f,1f);

	}	
	
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}

	
}