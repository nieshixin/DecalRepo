using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Transform[] destinations;

	private Vector3 initialPos;
	public float timePerStop;
	private float moveTime;
	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		moveTime = destinations.Length *timePerStop;
		if (destinations.Length > 1) {
			iTween.MoveTo (gameObject, iTween.Hash ("time", moveTime, "path", destinations, "easetype", iTween.EaseType.linear, "movetopath", false, "looptype", "pingPong", "delay", 1f));
		} else {
			iTween.MoveTo (gameObject, iTween.Hash ("time", moveTime, "position", destinations[0], "easetype", iTween.EaseType.easeInOutQuart, "movetopath", false, "looptype", "pingPong", "delay", 1f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
