using UnityEngine;
using System.Collections;

using UnityEngine.Events;

[ExecuteInEditMode]
public class CloneMovement : MonoBehaviour
{	
	Rigidbody PlayerRigi;
	Rigidbody cloneRigi;

	void Start(){
		//velocity
		PlayerRigi = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<Rigidbody> ();
		cloneRigi = GetComponent<Rigidbody> ();

	}
	void LateUpdate(){
		cloneRigi.velocity = PlayerRigi.velocity;
		//rotation
		//transform.position = PlayerRigi.transform.position;
		transform.rotation = PlayerRigi.transform.rotation;
	}
}

