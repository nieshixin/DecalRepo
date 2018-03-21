﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLoopEvents : MonoBehaviour {
	
	public static GameLoopEvents instance;

	public GameObject spawnPoint;
	// Use this for initialization
	GameObject FadeObject;
	Image FadeImage;

	void Start () {
		instance = this;

		FadeObject = GameObject.Find ("FadePanel");
		FadeImage = FadeObject.GetComponent<Image> ();
		GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonCharacterController> ().PlayerDied.AddListener (ResetPlayerPosition);

	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButtonDown(0)){
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		//}
	}
	 
	public void ResetPlayerPosition(){
		
		iTween.ValueTo (FadeObject,iTween.Hash("from", 0f, "to", 1f, "time", 0.5f, "onupdate", "TweenFadeValue", "onupdatetarget", gameObject, "oncomplete", "FadeBack", "oncompletetarget", gameObject));

		if (GameObject.FindGameObjectWithTag ("Clone") != null) {
			Vector3 diff = spawnPoint.transform.position - GameObject.FindGameObjectWithTag ("Player").transform.position;
			GameObject.FindGameObjectWithTag ("Clone").transform.position += diff;
		}
		GameObject.FindGameObjectWithTag ("Player").transform.position = spawnPoint.transform.position;

	}

	public void ChangeSpawnPoint(GameObject t){
		spawnPoint = t;
	}

	void TweenFadeValue(float value){
		FadeImage.color = new Color (0f,0f,0f,value);
	}

	void FadeBack(){
		iTween.ValueTo (FadeObject,iTween.Hash("from", 1f, "to", 0f, "time", 0.5f, "onupdate", "TweenFadeValue", "onupdatetarget", gameObject));
	}
}
