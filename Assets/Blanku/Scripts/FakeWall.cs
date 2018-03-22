using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWall : MonoBehaviour {

	GameObject playerRef;
	FirstPersonCharacterController controller;
	BoxCollider col; 

	[Header("Available angles")]
	public float MinAngle;//minimum y angle for camera to enable this portal
	public float MaxAngle;
	public float IdealAngle;
	public bool ReverseCase;


	public bool LookHelper;

	[SerializeField]
	float angleTimer;
	// Use this for initialization
	void Start () {
		col = gameObject.GetComponent<BoxCollider> ();

		playerRef = GameObject.FindGameObjectWithTag("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
		//register the check function to the player, so everytime the player rotates the camera, this checks the illusion
		controller.m_lookAngleChangeEvent.AddListener (CheckIllusion);
	}

	// Update is called once per frame
	void Update () {
		if (angleTimer >= 1f && !controller.CamLock && LookHelper) {
			CamToIdealAngle ();
		}

	}

	public void CheckIllusion(float lookAngle){

		if (ReverseCase) {
			if (lookAngle < MaxAngle || lookAngle > MinAngle) {
				//if angle is correct, add to timer, 0.5 value/sec
				if (angleTimer < 1) {
					angleTimer += Time.deltaTime * 0.5f;
				}
				if (col.isTrigger == false) {
					return;
				} else {
					EnableCollision ();
				}
			} else {
				angleTimer = 0;
				if (col.isTrigger == true) {
					return;
				} else {
					DisableCollision ();
				}
			}
		}
		else{// normal case

			if (lookAngle < MaxAngle && lookAngle > MinAngle) {
				//if angle is correct, add to timer, 0.5 value/sec
				if (angleTimer < 1) {
					angleTimer += Time.deltaTime * 0.5f;
				}
				if (col.isTrigger == false) {
					return;
				} else {
					EnableCollision ();
				}
			} else {
				angleTimer = 0;
				if (col.isTrigger == true) {
					return;
				} else {
					DisableCollision ();
					}
				}
			}
		}
		


	void EnableCollision(){
		col.isTrigger = false;
		Debug.Log ("col+");
	}
	void DisableCollision(){
		col.isTrigger = true;
		Debug.Log ("col-");
	}

	void CamToIdealAngle(){

		Debug.Log ("start ease");
		angleTimer = 0f;
		controller.CamLock = true;
		iTween.RotateTo (Camera.main.gameObject, iTween.Hash("y", IdealAngle, "time", 2f, "islocal", true, "easetype", "easeinoutQuart", "oncomplete", "UpdateRot", "oncompletetarget", gameObject, "onstart", "RotatePlayer", "onstarttarget", gameObject));
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