using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class TeleportChild : MonoBehaviour {

	public IllusionTeleport boss;
	public Transform targetPoint;
	[Range(1,2)]

	public bool PlayerInside = false;
	GameObject playerRef;
	FirstPersonCharacterController controller;
	 void Start(){
		playerRef = GameObject.FindGameObjectWithTag ("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
	}
	public void OnTriggerEnter(Collider other){
		if( other.tag == "Player"){
			PlayerInside = true;
			if (boss.portalOn) {
					TeleportPlayer ();
				}
			}
	}

	public void OnTriggerExit(){
		PlayerInside = false;

		//boss.portalOn = true;
	}

	public void OnCameraRotateCheck(){// use this to secure the case when  PLAYER IS ALREADY IN THE TRIGGER WHEN ROTATE THE CAMERA
		if (PlayerInside) {
			TeleportPlayer ();
		}
	}


	 void TeleportPlayer(){
		//calculate difference between portal
		Vector3 diff =  targetPoint.position - transform.position;
		playerRef.transform.position += diff ;
		Debug.Log ("teleport");
		//Time.timeScale = 0f;

	}
}
