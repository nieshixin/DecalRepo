using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehavior : MonoBehaviour {
	public float moveAmount = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnHoverMove(){
		iTween.MoveBy(gameObject, iTween.Hash("x", moveAmount, "time", 0.5f));

	}
	public void OnExitMove(){
		iTween.MoveBy(gameObject, iTween.Hash("x", -moveAmount, "time", 0.5f));

	}
}
