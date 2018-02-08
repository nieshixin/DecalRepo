using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 10f;
	public float rotateSpeed = 10f;

	private Vector3 movement;
	private float rotation;

	private Animator anim;

	void Start(){
		anim = gameObject.GetComponentInChildren<Animator> ();
		Debug.Log (anim);
	}
	void Update ()
	{
		//get camera horizontal Y rotation, set rotation on this
		//float Yrot = Camera.main.transform.rotation.y;
		//rotation = Yrot;
		//transform.rotation.eulerAngles.y = Camera.main.transform.rotation.eulerAngles.y;



		movement.z = Input.GetAxis("Vertical") * speed ;
		//rotation
		rotation = Input.GetAxis("Horizontal") * rotateSpeed ;

		anim.SetFloat ("Speed", Input.GetAxis("Vertical"));


		transform.Translate(movement* Time.deltaTime, Space.Self);
		//rotation
		transform.Rotate(0f, rotation* Time.deltaTime, 0f);
	}

	void FixedUpdate ()
	{
			
	}
	
}
