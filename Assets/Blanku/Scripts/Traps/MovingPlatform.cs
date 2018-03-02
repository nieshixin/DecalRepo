using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	[Header("level design")]
	public Transform destination;
	public float moveTime;
	public bool RegisterOnTriggers;

	public string channelReceive = "A"; //a,b,c channel this is on


	private Vector3 initialPos;
	private Vector3 exchange;

	private bool hasMoved = false;
	// Use this for initialization
	void Start () {
		
		initialPos = transform.position;

			if (!RegisterOnTriggers) {
				iTween.MoveTo (gameObject, iTween.Hash ("time", moveTime, "position", destination, "easetype", iTween.EaseType.easeInOutQuart,  "looptype", "pingPong", "delay", 1f));
			} if (RegisterOnTriggers) {
				switch(channelReceive){
				case "A":
					GameMechanicManager.Instance.MoveEvent_A.AddListener (ActionWhenPass);
					break;
				case "B":
					GameMechanicManager.Instance.MoveEvent_B.AddListener (ActionWhenPass);
					break;
				case "C":
					GameMechanicManager.Instance.MoveEvent_C.AddListener (ActionWhenPass);
					break;
				}
			}
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonCharacterController> ().PlayerDied.AddListener (DeadReset);
	}


	void Update () {
		
	}
	void ActionWhenPass(){
		
		hasMoved = !hasMoved;

		iTween.MoveTo (gameObject, iTween.Hash ("time", moveTime, "position", destination, "easetype", iTween.EaseType.linear));
		 exchange = initialPos;
		initialPos = destination.position;
		destination.position = exchange;

	}

	void DeadReset(){//if this has moved, run this when player died, this resets the platform
		if (hasMoved) {
			ActionWhenPass ();
		}
		
	}
}
