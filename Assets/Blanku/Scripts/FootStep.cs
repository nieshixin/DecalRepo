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


	void Start () {
		printer = GetComponent<Printer> ();
		ground = GameObject.FindGameObjectWithTag ("Ground");
		runAfterInitializeLock = false;
		//playerRef = GameObject.FindGameObjectWithTag("Player");
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
	}

	void OnEnable(){
		//Debug.Log (gameObject.name);
		if (runAfterInitializeLock == false) {
			MakeFootStep ();
		}
	}

}
