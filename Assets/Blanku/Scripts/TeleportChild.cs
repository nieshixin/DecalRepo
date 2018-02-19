using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class TeleportChild : MonoBehaviour {
	//this script only provides infor if player is inside the trigger box
	public IllusionTeleport boss;

	[Range(1,2)]

	public bool PlayerInside = false;
	public GameObject playerRef;
	FirstPersonCharacterController controller;
	 void Start(){
		playerRef = GameObject.FindGameObjectWithTag ("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
		//OnCameraRotateCheck ();
	}
	public void OnTriggerEnter(Collider other){
		if( other.tag == "Player"){
			PlayerInside = true;
			}
	}

	public void OnTriggerExit(){
		PlayerInside = false;

		//boss.portalOn = true;
	}
}
