using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour {
	public bool RegisteredToGate;

	public float time;
	public float ActionDelay;
	public string loopType;
	// Use this for initialization
	void Start () {
		if (!RegisteredToGate) {
			iTween.RotateAdd (gameObject, iTween.Hash ("z", 90f, "time", 2.5f, "looptype", iTween.LoopType.pingPong, "delay", 3f));	
		} else {
			GameMechanicManager.Instance.passingEvent.AddListener (ActionWhenPass);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActionWhenPass(){
		iTween.RotateAdd (gameObject, iTween.Hash ("z", 90f, "time", 2.5f, "looptype", iTween.LoopType.pingPong, "delay", 3f));	
	}
}
