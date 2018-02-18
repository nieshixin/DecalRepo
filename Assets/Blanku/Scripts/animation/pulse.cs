using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ScaleTo (gameObject, iTween.Hash ("x",1.1, "y",1.1,"z",1.1, "time", 1f, "easetype", "easeInQuad","looptype", "pingPong"));
	}

	// Update is called once per frame
	void Update () {
		
	}
}
