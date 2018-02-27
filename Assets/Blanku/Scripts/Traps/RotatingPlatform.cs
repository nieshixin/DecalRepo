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
	void Start () {
		if (!RegisteredToGate) {
			iTween.RotateAdd (gameObject, iTween.Hash (axis, degrees, "time", time, "looptype", iTween.LoopType.pingPong, "delay", 3f));	
		} else {
			GameMechanicManager.Instance.passingEvent.AddListener (ActionWhenPass);
		}
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
}
