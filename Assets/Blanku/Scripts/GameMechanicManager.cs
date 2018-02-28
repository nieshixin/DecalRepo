using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameMechanicManager : MonoBehaviour {
	public static GameMechanicManager Instance { 
		get{ 
				return _instance;
			}
		}

	public UnityEvent passingEvent;
	static GameMechanicManager _instance;

	public UnityEvent MoveEvent_A;
	public UnityEvent MoveEvent_B;
	public UnityEvent MoveEvent_C;

	public UnityEvent RotEvent_A;
	public UnityEvent RotEvent_B;
	public UnityEvent RotEvent_C;

	void Awake(){
		_instance = this;
	}
	void Start () {


		if (passingEvent == null) {
			passingEvent = new UnityEvent ();
		}

		if (MoveEvent_A == null) {
			MoveEvent_A = new UnityEvent ();
		}
		if (MoveEvent_B == null) {
			MoveEvent_B = new UnityEvent ();
		}
		if (MoveEvent_C == null) {
			MoveEvent_C = new UnityEvent ();
		}

		if (RotEvent_A == null) {
			RotEvent_A = new UnityEvent ();
		}
		if (RotEvent_B == null) {
			RotEvent_B = new UnityEvent ();
		}
		if (RotEvent_C == null) {
			RotEvent_C = new UnityEvent ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown (KeyCode.Q)){
			passingEvent.Invoke ();
		};

	}
}
