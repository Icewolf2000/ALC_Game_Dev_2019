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

	public Animator animator;

	// Use this for initialization
	void Start () {
		animator.SetBool("isWalking",false);
		animator.SetBool("isJumping",false);
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
	}

	// Update is called once per frame
	void Update () {

		//Code makes charater jump
		if(Input.GetKeyDown (KeyCode.W)&& grounded){
			Jump();
			animator.SetBool("isJumping",true);
		}
		else if (Input.GetKeyUp (KeyCode.W)){
			animator.SetBool("isJumping",false);
		}

		//Double Jump Code
		if(grounded){
			doubleJump = false;
			animator.SetBool("isJumping",false);
		}
			

		if(Input.GetKeyDown (KeyCode.W)&& !doubleJump && !grounded){
			Jump();
			doubleJump = true;
		}
		
		//Non-Slide Player
		moveVelocity = 0f;

		//This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.D)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = MoveSpeed;
			animator.SetBool("isWalking",true);
		}
		else if (Input.GetKeyUp (KeyCode.D)){
			animator.SetBool("isWalking",false);
		}

		if(Input.GetKey (KeyCode.A)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -MoveSpeed;
			animator.SetBool("isWalking",true);
		}
		else if (Input.GetKeyUp (KeyCode.A)){
			animator.SetBool("isWalking",false);
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//Player Flip
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(0.171f,0.173f,1f);

		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-0.17f,0.173f,1f);

	}	
	
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
		animator.SetBool("isJumping",true);
	}

	
}