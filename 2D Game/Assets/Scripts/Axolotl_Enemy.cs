﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axolotl_Enemy : MonoBehaviour {

	//Movement Variables
	public float MoveSpeed;
	public bool MoveRight;

	//Wall Check
	public Transform WallCheck;
	public float WallCheckRadius;
	public LayerMask WhatIsWall;
	private bool HittingWall;

	//Edge Check
	private bool NotAnEdge;
	public Transform EdgeCheck;


	// Update is called once per frame
	void Update () {
		NotAnEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);
		
		HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

		if(HittingWall || !NotAnEdge){
			MoveRight = !MoveRight;
		}
		
		if (MoveRight){
			transform.localScale = new Vector3(-0.383f,0.377f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else {
			transform.localScale = new Vector3(0.383f,0.37f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}