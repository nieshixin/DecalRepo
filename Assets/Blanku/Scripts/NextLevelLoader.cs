using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelLoader : MonoBehaviour {
	public string NextLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			LoadNextScene ();
		}
	}
	public void LoadNextScene(){
		//GameObject.Destroy(GameObject.Find ("Orange Goo Pool").gameObject);
		SceneManager.LoadScene (NextLevel);

	}
}
