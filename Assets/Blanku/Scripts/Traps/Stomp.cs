using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour {

	// Use this for initialization
	public float StompHeight;

	void Start () {
		
		iTween.MoveBy(gameObject, iTween.Hash("y", -(StompHeight + 0.1f), "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}



}
