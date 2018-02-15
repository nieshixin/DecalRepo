using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlockhamIndustries.Decals;

[RequireComponent(typeof(Printer))]
public class PrintOnFall : MonoBehaviour {
	Rigidbody rigi;
	public float thresholdVelocity = 3f;
	// Use this for initialization
	void Start () {
		rigi = gameObject.GetComponentInChildren<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigi.velocity.magnitude >= thresholdVelocity) {
		}
		
	}
}
