using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootageRotate : MonoBehaviour {

	// Use this for initialization

	Vector3 cameraRot;
	void Start () {
		
		cameraRot = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		
		cameraRot.y += 3f;
	}
}
