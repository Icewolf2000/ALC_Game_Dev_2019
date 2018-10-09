using UnityEngine;
using System.Collections;

public class Kill_PC : MonoBehaviour {

	public LevelManager LevelManager;

	// Use this for initialization
	void Start () {
		LevelManager = FindObjectOfType<LevelManager>();
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "PC"){
			LevelManager.RespawnPlayer();
		}
		
	}
}
