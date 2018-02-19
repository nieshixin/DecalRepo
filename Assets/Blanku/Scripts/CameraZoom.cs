using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	Camera cam; 
	public float speed = 0.2f;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel")>0) {
			cam.orthographicSize -= speed;
			if (cam.orthographicSize < 1)
				cam.orthographicSize = 1;
		}
		if(Input.GetAxis ("Mouse ScrollWheel")<0)
			cam.orthographicSize += speed;
		
	}
}
