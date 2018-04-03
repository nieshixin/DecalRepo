using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Decals;

[RequireComponent(typeof(Printer))]
public class FootStep : MonoBehaviour {

	// Use this for initialization
	private Printer printer;
	private Quaternion rot;
	private GameObject ground;

	private bool runAfterInitializeLock = true;
	public GameObject playerRef;

	Rigidbody rigi;

	AudioSource Foot_sound;

	void Start () {
		printer = GetComponent<Printer> ();
		ground = GameObject.FindGameObjectWithTag ("Ground");
		runAfterInitializeLock = false;
		//playerRef = GameObject.FindGameObjectWithTag("Player");
		rigi = playerRef.GetComponentInChildren<Rigidbody>();

		if (gameObject.name == "left Foot") {
			Foot_sound = GameObject.Find ("footstep_L").GetComponent<AudioSource>();
		} else if(gameObject.name == "right Foot"){
			Foot_sound = GameObject.Find ("footstep_R").GetComponent<AudioSource>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void MakeFootStep(){
		if (printer == null) {
			printer = GetComponent<Printer> ();;
		}



		rot = playerRef.transform.rotation;
		rot *= Quaternion.Euler (90,0,0);

		//Calculate our rotation
		//else rot = Vector3.up;


		//raycast check perpendicular

		Ray r;
		RaycastHit hit;
		Physics.Raycast (playerRef.transform.position, Vector3.down, out hit );


		if (hit.normal != Vector3.up) {
		//	Debug.Log ("on slope");


			//overwrite all
			//rot.SetLookRotation(-hit.normal);

			//算playerY rotation & footprint Z的偏差

			rot.SetLookRotation (playerRef.transform.forward);

			float agl = Vector3.Angle (hit.normal, Vector3.up);
			//Vector3 cross = Vector3.Cross (hit.normal,Vector3.up);
			rot *= Quaternion.Euler (3f * agl, 0, 0);

		}

		printer.Print (transform.position, rot, ground.transform);

		if (Foot_sound != null) {
			Foot_sound.Play ();
		}
	}

	void OnEnable(){
		//Debug.Log (gameObject.name);
		if (runAfterInitializeLock == false) {
			MakeFootStep ();
		}
	}

}
