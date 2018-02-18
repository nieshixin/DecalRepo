using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionPositioner : MonoBehaviour {
	GameObject playerRef;
	FirstPersonCharacterController controller;

	public Vector3 angle_1_pos;
	public Vector3 angle_2_pos;
	public Vector3 angle_3_pos;
	public Vector3 angle_4_pos;

	BoxCollider playerInsideCheck;
	[SerializeField]
	bool playerInside = false;
	Vector3 previousPos;
	Vector3 playertravelDis;
	Vector3 expectedPos;
	// Use this for initialization
	void Start () {

		playerRef = GameObject.FindGameObjectWithTag("Player");
		controller = playerRef.GetComponent<FirstPersonCharacterController> ();
		//register the check function to the player, so everytime the player rotates the camera, this checks the illusion
		controller.m_lookAngleChangeEvent.AddListener (CheckIllusion);

		playerInsideCheck = GetComponent<BoxCollider> ();

		ProcessNoninputPos ();
	}

	// Update is called once per frame
	void Update () {
		
	}
	//very important everytime player rotate the camera, run this func
	public void CheckIllusion(int lookAngle){
		previousPos = transform.parent.position; 

		switch (lookAngle) {
		case 1:
			
			iTween.MoveTo (transform.parent.gameObject, iTween.Hash ("position", angle_1_pos, "islocal", true, "time", 0.5f)); 
			expectedPos = angle_1_pos;
			break;
		case 2:
			iTween.MoveTo (transform.parent.gameObject, iTween.Hash ("position", angle_2_pos, "islocal", true, "time", 0.5f)); 
			expectedPos = angle_2_pos;
			break;
		case 3:
			iTween.MoveTo (transform.parent.gameObject, iTween.Hash ("position", angle_3_pos, "islocal", true, "time", 0.5f)); 
			expectedPos = angle_3_pos;
			break;
		case 4:
			iTween.MoveTo (transform.parent.gameObject, iTween.Hash ("position", angle_4_pos, "islocal", true, "time", 0.5f)); 
			expectedPos = angle_4_pos;
			break;
		}
		if (playerInside) {
			GrabPlayer();
		}
	}

	void GrabPlayer(){
		Debug.Log ("player grabbed");
		//Vector3 diff = transform.parent.position - previousPos ;
		//playerRef.transform.position += diff;
		playertravelDis =  expectedPos - previousPos;
		Debug.Log (playertravelDis);
		iTween.MoveBy(playerRef, playertravelDis, 0.5f);
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("player entered this block");
			playerInside = true;
			//playerRef.transform.parent.parent = transform;
			playerRef.transform.SetParent(transform);
		}
	}
	public void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("player exits this block");
			playerInside = false;
			//playerRef.transform.parent.parent = null;
		}
	}

	void ProcessNoninputPos(){
		if (angle_1_pos == Vector3.zero) {
			angle_1_pos = transform.parent.localPosition;
		}
		if (angle_2_pos == Vector3.zero) {
			angle_2_pos = transform.parent.localPosition;
		}
		if (angle_3_pos == Vector3.zero) {
			angle_3_pos = transform.parent.localPosition;
		}
		if (angle_4_pos == Vector3.zero) {
			angle_4_pos = transform.parent.localPosition;
		}
	}
}
