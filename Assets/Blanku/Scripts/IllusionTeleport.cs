using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionTeleport : MonoBehaviour {

	GameObject playerRef;
	FirstPersonCharacterController controller;
	BoxCollider thisCol;
	MeshRenderer mesh;
	[Header("Available angle")][Range(1,4)]
	public List<int> availableAngles;


	// Use this for initialization
	void Start () {
		thisCol = GetComponent<BoxCollider> ();
		mesh = GetComponent<MeshRenderer> ();
		playerRef = GameObject.FindGameObjectWithTag("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
		//register the check function to the player, so everytime the player rotates the camera, this checks the illusion
		controller.m_lookAngleChangeEvent.AddListener (CheckIllusion);
	}

	// Update is called once per frame
	void Update () {

	}

	public void CheckIllusion(int lookAngle){
		Debug.Log (lookAngle);
		thisCol.isTrigger = true;
		mesh.enabled = false;
		for (int i = 0; i < availableAngles.Count; i++) {
			if (availableAngles [i] == lookAngle) {
				thisCol.isTrigger = false;
				mesh.enabled = true;
			}
		}

	}
}
