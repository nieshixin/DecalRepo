using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelDesignCamera : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void RotateLeft90(){
		transform.Rotate (Vector3.up*90f, Space.World);
	}
	public void RotateRight90(){
		transform.Rotate (Vector3.down*90f, Space.World);
	}
	public  void RotateLeft45(){
		transform.Rotate (Vector3.up*45f, Space.World);
	}
	public void RotateRight45(){
		transform.Rotate (Vector3.down*45f, Space.World);
	}

}


