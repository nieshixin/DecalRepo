using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Misc;
public class FootAnimSpeedUpdater : MonoBehaviour {

	Animator anim;
	float velocity;
	Rigidbody src;
	//where we get the speed from
		
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator> ();
		src = gameObject.GetComponentInChildren<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = src.velocity.magnitude;
		if (velocity > 0.1f) {
			anim.SetBool ("Walk", true);
			anim.SetFloat ("Speed", velocity);	
		} else {
			anim.SetBool ("Walk", false);
			anim.SetFloat ("Speed", 0f);	
		}
		Debug.Log (velocity);
	}
}
