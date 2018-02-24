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
	void Awake(){
		_instance = this;
	}
	void Start () {


		if (passingEvent == null) {
			passingEvent = new UnityEvent ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown (KeyCode.Q)){
			passingEvent.Invoke ();
		};

	}
}
