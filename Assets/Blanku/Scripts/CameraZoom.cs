using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	Camera cam; 	
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel")>0) {
			cam.orthographicSize -= 0.2f;
		}
		if(Input.GetAxis ("Mouse ScrollWheel")<0)
			cam.orthographicSize += 0.2f;
	}
}
