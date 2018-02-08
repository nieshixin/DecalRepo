using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	float yaw;
	float pitch;

	public float HrotateSpeed;
	public float VrotateSpeed;
	// Use this for initialization
	public Transform lookAt;
	Transform camTransform;
	Camera cam;

	private float distance = 3.0f;
	float currentX = 0f;
	float currentY = 0f;
	float sensivityX = 40f;
	float sensivityY = 40f;

	private Transform originalTrans;

	void Start () {
		camTransform = transform;
		cam = Camera.main;

		//camTransform.LookAt (lookAt);

		Cursor.visible = false;	
	}
	
	// Update is called once per frame
	void Update () {
		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");

		if (Input.GetKeyDown (KeyCode.Space)) {
			 originalTrans = Camera.main.transform;
			GameObject goal = GetGoalTarget ();
			iTween.LookTo (this.gameObject, goal.transform.position, 1f);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			iTween.LookTo (this.gameObject, player.transform.position, 0.5f);
			Debug.Log ("space up");
		}

	}

	void LateUpdate(){
	//	camTransform.position = new Vector3 (lookAt.position.x, lookAt.position.y, lookAt.position.z - distance);

		cam.transform.RotateAround (lookAt.position,Vector3.up, Input.GetAxis ("Mouse X"));
		//cam.transform.RotateAround (lookAt.position,Vector3.left, -Input.GetAxis ("Mouse Y"));

	}

	void FixedUpdate(){
		
	}


	void LookTarget(GameObject target){
		
		Camera.main.transform.LookAt (target.transform);
		
	}
	GameObject GetGoalTarget(){
		GameObject goal = GameObject.FindGameObjectWithTag ("Goal");
		return goal;

	}
}
