using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Misc;
public class FootAnimSpeedUpdater : MonoBehaviour {

	Animator anim;
	float speed;
	FirstPersonCharacterController src;
	//where we get the speed from
		
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator> ();
		src = gameObject.GetComponentInChildren<FirstPersonCharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		speed = src.moveSpeed;
		anim.SetFloat ("Speed", speed);	
	}
}
