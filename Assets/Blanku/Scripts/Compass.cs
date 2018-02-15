using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compass : MonoBehaviour {
	public Transform player;
	public Transform Goal;

	public Vector3 northDirection;
	public Quaternion missionDirection;

	public RectTransform northLayer;
	public RectTransform missionLayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateNorthDirection ();
		UpdateMissionCompass ();
		
	}
	public void UpdateNorthDirection(){
		northDirection.z = player.eulerAngles.y;
		northLayer.eulerAngles = northDirection;
	}

	public void UpdateMissionCompass(){
		Vector3 dir = player.position - Goal.position;
		Vector2 dir2 = new Vector2 (dir.x, dir.z);
		float angle = Vector2.Angle (Vector2.down , dir2 );
		//missionDirection = Quaternion.LookRotation (dir);

		//missionDirection.z = -missionDirection.y;
	//	missionDirection.x = 0;
	//	missionDirection.y = 0;
		//missionLayer.localRotation.z *= angle;
		missionLayer.eulerAngles = new Vector3 (0f, 0f, angle);
	}
}
