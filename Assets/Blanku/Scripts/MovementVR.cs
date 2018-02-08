using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVR : MonoBehaviour {
	
	public float speed = 10f;


	private Vector3 movement;


	private Animator anim;

	void Start(){
		anim = gameObject.GetComponentInChildren<Animator> ();
		Debug.Log (anim);
	}
	void Update ()
	{
		if (Input.GetAxis ("Vertical") != 0) {
			movement = Camera.main.transform.forward * speed * Time.deltaTime;

			transform.Translate(movement, Space.Self);
		} 
		anim.SetFloat ("Speed", Input.GetAxis("Vertical"));
	}

	void FixedUpdate ()
	{
		
	}
}
