using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBlockRise : MonoBehaviour {
	public float amount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RandomMove(){
		amount = Random.Range (3f,10f);
		iTween.MoveTo (gameObject,iTween.Hash("y",amount, "time", 0.2f));
		Debug.Log ("1");
	}
}
