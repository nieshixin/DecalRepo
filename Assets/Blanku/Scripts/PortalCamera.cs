using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform PortalPlane;
	public Transform otherPortal; //ther portal which player is close to
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = PortalPlane.position + playerOffsetFromPortal;
		float angleDiff = Quaternion.Angle (PortalPlane.rotation, otherPortal.rotation);
		Quaternion rotationDiff = Quaternion.AngleAxis (angleDiff, Vector3.up);
		Vector3 newCamDirection = rotationDiff * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation (newCamDirection, Vector3.up);
	}
}
