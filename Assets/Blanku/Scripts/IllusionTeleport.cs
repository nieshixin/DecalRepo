using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionTeleport : MonoBehaviour {

	GameObject playerRef;
	FirstPersonCharacterController controller;
	public TeleportChild A; //A is the gate
	//public Transform B; //B is the target point

	public Transform targetPoint;
	[Header("Available angles")]
	public float MinAngle;//minimum y angle for camera to enable this portal
	public float MaxAngle;

	public bool portalOn = false;


	// Use this for initialization
	void Start () {

		playerRef = GameObject.FindGameObjectWithTag("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
		//register the check function to the player, so everytime the player rotates the camera, this checks the illusion
		controller.m_lookAngleChangeEvent.AddListener (CheckIllusion);
	}

	// Update is called once per frame
	void Update () {

	}

	public void CheckIllusion(float lookAngle){
		//Debug.Log (lookAngle);
		portalOn = false;

		if (lookAngle < MaxAngle && lookAngle > MinAngle) {
			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
				if (A.PlayerInside) {
					TeleportPlayer ();
				}
			}
		}

			}
	void TeleportPlayer(){
		//calculate difference between portal
		Vector3 diff =  targetPoint.position - playerRef.transform.position;
		playerRef.transform.position += diff;
		Debug.Log ("teleport");
		//Time.timeScale = 0f;

	}
}

