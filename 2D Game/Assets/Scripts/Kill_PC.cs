using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_PC : MonoBehaviour {

	public Level_Manager Level_Manager;

	// Use this for initialization
	void Start () {
		Level_Manager = FindObjectOfType<Level_Manager>();
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "PC"){
			Level_Manager.RespawnPlayer();
		}
		
	}
}
