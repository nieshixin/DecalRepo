using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float cameraSize = Camera.main.orthographicSize;
		float lerp1 = Mathf.Lerp (2f,30f, cameraSize);

		float iconScale = Mathf.Lerp (0.8f, 1.6f,lerp1);

		transform.localScale = new Vector3 (iconScale, iconScale, 1);
	}
}
