using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate2 : MonoBehaviour {

	public Gate boss;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(){
		boss.trigger2 = true;
	}

	void OnTriggerExit(){
		if (boss.trigger1 && boss.trigger2) {
			GameMechanicManager.Instance.passingEvent.Invoke ();
			boss.trigger1 = false;
			boss.trigger2 = false;
		}
	}
}
