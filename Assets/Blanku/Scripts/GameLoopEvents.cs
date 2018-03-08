﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopEvents : MonoBehaviour {
	
	public static GameLoopEvents instance;

	public GameObject spawnPoint;
	// Use this for initialization
	void Start () {
		instance = this;


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
	 
	public void ResetPlayer(){
		
		iTween.CameraFadeTo (1f, 2f);
		GameObject.FindGameObjectWithTag ("Player").transform.position = spawnPoint.transform.position;
	}
}
