using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	[Header("level design")]
	public Transform destination;
	public bool RegisterOnTriggers = false;

	private Vector3 initialPos;
	private Vector3 exchange;

	public float moveTime;


	// Use this for initialization
	void Start () {
		
		initialPos = transform.position;

			if (!RegisterOnTriggers) {
				iTween.MoveTo (gameObject, iTween.Hash ("time", moveTime, "position", destination, "easetype", iTween.EaseType.easeInOutQuart,  "looptype", "pingPong", "delay", 1f));
			} if (RegisterOnTriggers) {
				GameMechanicManager.Instance.passingEvent.AddListener (MoveOnTrigger);
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void MoveOnTrigger(){
		iTween.MoveTo (gameObject, iTween.Hash ("time", moveTime, "position", destination, "easetype", iTween.EaseType.linear));
		 exchange = initialPos;
		initialPos = destination.position;
		destination.position = exchange;

	}
}
