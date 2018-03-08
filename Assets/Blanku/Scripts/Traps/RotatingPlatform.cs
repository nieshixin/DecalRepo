using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour {
	public bool RegisteredToGate;

	public float time;
	public string axis;
	public float degrees;
	// Use this for initialization

	private bool hasRotated = false;

	public string channelReceive;


	void Start () {
		if (!RegisteredToGate) {
			iTween.RotateAdd (gameObject, iTween.Hash (axis, degrees, "time", time, "looptype", iTween.LoopType.pingPong, "delay", 2f, "space", Space.Self));	
		} else {
			switch(channelReceive){
			case "A":
				GameMechanicManager.Instance.RotEvent_A.AddListener (ActionWhenPass);
				break;
			case "B":
				GameMechanicManager.Instance.RotEvent_B.AddListener (ActionWhenPass);
				break;
			case "C":
				GameMechanicManager.Instance.RotEvent_C.AddListener (ActionWhenPass);
				break;
			}
		}

		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonCharacterController> ().PlayerDied.AddListener (DeadReset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActionWhenPass(){
		
		if (hasRotated) {
			degrees = -degrees;
			Debug.Log (degrees);
			iTween.RotateAdd (gameObject, iTween.Hash (axis, degrees, "time", time));	
			hasRotated = false;
			degrees = -degrees;
			return;
		}
		else if (!hasRotated) {
			Debug.Log (degrees);
			iTween.RotateAdd (gameObject, iTween.Hash (axis, degrees, "time", time));	
			hasRotated = true;
			return;
		}
	}

	void DeadReset(){
		if (hasRotated) {
			ActionWhenPass ();
		}
	}
}
