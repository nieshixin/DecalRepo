using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Decals;
public class KillPlayerOnEnter : MonoBehaviour {

	//Printer printer;
	//GameObject ground;
	// Use this for initialization
	void Start () {
		//printer = GetComponent<Printer> ();
		//ground = GameObject.FindGameObjectWithTag ("Ground");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter(Collider colli){
		Splash (colli);
	}

	public void Splash(Collider co){

		if (co.gameObject.CompareTag ("Player")) {//when collider with player
			Debug.Log ("collid player, destroy: " + co.gameObject.name);
		//	var splashLocation = co.gameObject.transform.position;
			//splashLocation.y = ground.transform.positio n.y;
			//var splashRotation = Quaternion.identity * Quaternion.Euler(90,0,0);

			//printer.Print (splashLocation, splashRotation, ground.transform);

			//destroy player
			//GameLoopEvents.instance.ResetPlayer();
			//
			co.gameObject.GetComponent<FirstPersonCharacterController>().PlayerDied.Invoke();

			//GetComponent<BoxCollider> ().isTrigger = false;


		}

	}

}
