using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	Camera cam; 
	public float speed = 0.2f;
	// Use this for initialization

	float scrollDelta;
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			cam.orthographicSize -= speed;
			if (cam.orthographicSize < 1)
				cam.orthographicSize = 1;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0)
			cam.orthographicSize += speed;
		if (cam.orthographicSize > 13)
			cam.orthographicSize = 13;
	}
		/*
		if (Input.GetAxis ("Mouse ScrollWheel")  >0) {
			scrollDelta += Input.GetAxis ("Mouse ScrollWheel");
			cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, 1f, speed*Time.deltaTime);
		}
		if (Input.GetAxis ("Mouse ScrollWheel")  < 0) {
			scrollDelta -= Input.GetAxis ("Mouse ScrollWheel");
			cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, 15f, speed*Time.deltaTime);
		}
	}
	*/

	
}
