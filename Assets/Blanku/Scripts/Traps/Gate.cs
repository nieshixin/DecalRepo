using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GATETYPE{Moving, Rotating};

public class Gate : MonoBehaviour {
	[HideInInspector]
	public bool trigger1;
	[HideInInspector]
	public bool trigger2;

	public bool gateDisabled = false;

	public bool canBeDisabled;

	public GATETYPE gateType;
	public string gateChannel;


	[SerializeField]
	float angle;

	GameObject playerRef;
	FirstPersonCharacterController controller;

	public bool LookHelper;
	[Header("Disabled angles")]
	public float MinAngle;//minimum y angle for camera to enable this portal
	public float MaxAngle;
	public float IdealAngle;

	public bool ReverseCase;

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
		if (angleTimer >= 1f && !controller.CamLock && LookHelper) {
			CamToIdealAngle ();
		}
	}

	public void CheckIllusion(float lookAngle){
		//Debug.Log (lookAngle);
		angle = lookAngle;

		if (canBeDisabled) {
			if (ReverseCase) {
			//	float angle = lookAngle;
			//	if (angle > MinAngle) {
			//		angle += 360;
			//	}
				if (lookAngle < MaxAngle  || lookAngle > MinAngle) {
					//if angle is correct, add to timer, 0.5 value/sec
					if (angleTimer < 1) {
						angleTimer += Time.deltaTime * 0.5f;
					}
					if (gateDisabled == true) {
						return;
					} else {//disable gate
						gateDisabled = true;
					
					}
				}
				else {
					angleTimer = 0;
					if (gateDisabled == false) {
						return;
					} else {//enable gate
						gateDisabled = false;
					}
				}
			} else {//normal case
				if (lookAngle < MaxAngle && lookAngle > MinAngle) {
					//if angle is correct, add to timer, 0.5 value/sec
					if (angleTimer < 1) {
						angleTimer += Time.deltaTime * 0.5f;
					}
					if (gateDisabled == true) {
						return;
					} else {//disable gate
						gateDisabled = true;
					}
				} else {
				
					angleTimer = 0;
					if (gateDisabled == false) {
						return;
					} else {//enable gate
						gateDisabled = false;
					}
				}
			}
		}

		else {//if it's can't be disabled, enable the gate, very simple
				angleTimer = 0;
				if (gateDisabled == false) {
					return;
				} else {//enable gate
					gateDisabled = false;
				}
			}
		
	}


	void CamToIdealAngle(){

		Debug.Log ("start ease");
		angleTimer = 0f;
		controller.CamLock = true;
		iTween.RotateTo (Camera.main.gameObject, iTween.Hash("y", IdealAngle, "time", 1f, "islocal", true, "easetype", "easeinoutQuart", "oncomplete", "UpdateRot", "oncompletetarget", gameObject, "onstart", "RotatePlayer", "onstarttarget", gameObject));
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