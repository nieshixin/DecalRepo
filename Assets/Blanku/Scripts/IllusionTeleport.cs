using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionTeleport : MonoBehaviour {

	GameObject playerRef;
	FirstPersonCharacterController controller;
	public TeleportChild A; //A is the gate
	public Transform B; //B is the target point

	[Header("Available angle")][Range(1,4)]
	public List<int> availableAngles;

	public bool portalOn = false;


	// Use this for initialization
	void Start () {

		playerRef = GameObject.FindGameObjectWithTag("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
		//register the check function to the player, so everytime the player rotates the camera, this checks the illusion
		controller.m_lookAngleChangeEvent.AddListener (CheckIllusion);

		A.OnCameraRotateCheck ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void CheckIllusion(float lookAngle){
		Debug.Log (lookAngle);
		portalOn = false;

		for (int i = 0; i < availableAngles.Count; i++) {
			if (availableAngles [i] == lookAngle) {
				portalOn = true;
				//just incase player is in any of them
				A.OnCameraRotateCheck();
			}
		}

	}
}
