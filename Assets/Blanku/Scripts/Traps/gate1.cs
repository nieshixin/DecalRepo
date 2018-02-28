using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class gate1 : MonoBehaviour {
	public Gate boss;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		boss.trigger1 = true;
	}

	void OnTriggerExit(){
		if (boss.trigger1 && boss.trigger2 && boss.gateDisabled == false) {
			BroadCastToRightChannel ();
			boss.trigger1 = false;
			boss.trigger2 = false;
		}
	}
	void BroadCastToRightChannel(){
		if (boss.gateType == GATETYPE.Moving) {
			switch (boss.gateChannel) {
			case "A":
				GameMechanicManager.Instance.MoveEvent_A.Invoke ();
				break;
			case "B":
				GameMechanicManager.Instance.MoveEvent_B.Invoke ();
				break;
			case "C":
				GameMechanicManager.Instance.MoveEvent_C.Invoke ();
				break;
			}
		}
		else if (boss.gateType == GATETYPE.Rotating) {
			switch (boss.gateChannel) {
			case "A":
				GameMechanicManager.Instance.RotEvent_A.Invoke ();
				break;
			case "B":
				GameMechanicManager.Instance.RotEvent_B.Invoke ();
				break;
			case "C":
				GameMechanicManager.Instance.RotEvent_C.Invoke ();
				break;
			}
		}
	}
}
