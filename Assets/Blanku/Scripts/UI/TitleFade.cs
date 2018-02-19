using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFade : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		iTween.FadeTo (gameObject,iTween.Hash("amount", "255", "time", 2f));
		Debug.Log ("fade");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UIFadeto(){
	//	iTween.FadeTo(this.gameObject,iTween.Hash())
	}
}
