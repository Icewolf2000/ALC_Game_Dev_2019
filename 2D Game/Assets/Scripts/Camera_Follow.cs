using System.Collections;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

	public Character_Movement Player;

	public bool isFollowing;

	//Camera position offset
	public float xOffset;
	public float yOffset;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<Character_Movement>();

		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing){
			transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, transform.position.z);
		}
		
	}
}
