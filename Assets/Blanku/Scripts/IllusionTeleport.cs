using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionTeleport : MonoBehaviour {
	[HideInInspector]
	public GameObject playerRef;
	FirstPersonCharacterController controller;
	public TeleportChild A; //A is the gate
	//public Transform B; //B is the target point

	public Transform targetPoint;
	[Header("Available angles")]
	public float MinAngle;//minimum y angle for camera to enable this portal
	public float MaxAngle;

	public float IdealAngle;
	public bool LookHelper;

	public float RequireTime = 1f; // time required to be in correct angle for camera helper to start
	public float RotateTime = 0.5f; //time rotating the camera helper
	[HideInInspector]
	public bool portalOn = false;

	[SerializeField]
	float angleTimer;
	// Use this for initialization
	void Start () {

		playerRef = GameObject.FindGameObjectWithTag("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
		//register the check function to the player, so everytime the player rotates the camera, this checks the illusion
		controller.m_lookAngleChangeEvent.AddListener (CheckIllusion);
	}

	// Update is called once per frame
	void Update () {
		if (angleTimer >= RequireTime && !controller.CamLock && LookHelper) {
			CamToIdealAngle ();
		}
		/*
		if (Mathf.Abs (Input.GetAxisRaw ("Mouse Y")) > 0.18f) {
			controller.CamLock = false;
			angleTimer = 0f;
		}
		*/
	}

	public void CheckIllusion(float lookAngle){
		//Debug.Log (lookAngle);
		portalOn = false;

		if (lookAngle < MaxAngle && lookAngle > MinAngle) {
			//if angle is correct, add to timer, 0.5 value/sec
			if (angleTimer < 1) {
				angleTimer += Time.deltaTime * 0.5f;
			}
			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
				if (A.PlayerInside) {
					//if player teleports, unlock camera
					controller.CamLock = false;

					TeleportPlayer ();
				}
			}
		} else {
			angleTimer = 0;

		}
	}
	void TeleportPlayer(){
		//calculate difference between portal
		Vector3 diff =  targetPoint.position - playerRef.transform.position;
		playerRef.transform.position += diff;
		Debug.Log ("teleport");
		//Time.timeScale = 0f;


	}

	void CamToIdealAngle(){
		
			Debug.Log ("start ease");
			angleTimer = 0f;
		controller.CamLock = true;
		iTween.RotateTo (Camera.main.gameObject, iTween.Hash("y", IdealAngle, "time", RotateTime, "islocal", true, "easetype", "easeinoutQuart", "oncomplete", "UpdateRot", "oncompletetarget", gameObject, "onstart", "RotatePlayer", "onstarttarget", gameObject));
		}
	public void ResetTimer(){
		

	}

	public void UpdateRot(){

		controller.cameraRotation.y = IdealAngle;
		angleTimer = 0f;
		controller.CamLock = false;
	}
	public void RotatePlayer(){
		Debug.Log ("rotate player");
		//iTween.RotateTo (playerRef, iTween.Hash("y", IdealAngle, "time", 0.2f, "islocal", true));
		Vector3 PR = playerRef.transform.localRotation.eulerAngles;
		PR.y = IdealAngle;
		playerRef.transform.localRotation = Quaternion.Euler (PR);
	}
}

