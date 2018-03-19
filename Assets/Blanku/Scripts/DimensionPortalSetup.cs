using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionPortalSetup : MonoBehaviour {
	public Camera camera_B;
	public Material CamMat_B;
	// Use this for initialization
	void Start () {
		if (camera_B.targetTexture != null) {
			camera_B.targetTexture.Release ();
		}
		camera_B.targetTexture = new RenderTexture  (Screen.width, Screen.height, 24);
		CamMat_B.mainTexture = camera_B.targetTexture;
	}
	

}
