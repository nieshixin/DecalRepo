using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(levelDesignCamera))]
public class levelDesignCameraEditor : Editor {
	
	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		levelDesignCamera myscript = (levelDesignCamera)target;
		if (GUILayout.Button ("Left 90")) {
			myscript.RotateLeft90 ();
		}
		if (GUILayout.Button ("Right 90")) {
			myscript.RotateRight90 ();
		}
	}

}
