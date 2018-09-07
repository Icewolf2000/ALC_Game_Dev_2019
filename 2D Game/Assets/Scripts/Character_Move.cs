using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour {


	// Player Movement Variables
	public int MoveSpeed;
	public float JumpHeight;

	//Player Grounded Variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask WhatIsGround;
	private bool grounded;

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
	
	}	
	
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);

	}

	
}

