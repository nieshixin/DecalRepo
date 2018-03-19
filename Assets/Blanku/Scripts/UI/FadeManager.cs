using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeManager : MonoBehaviour {
	public static FadeManager instance{get; set;}

	Image FadeImage;
	bool isInTransition;
	bool isShowing;
	float duration;
	float transition;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
