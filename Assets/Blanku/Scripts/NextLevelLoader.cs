using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelLoader : MonoBehaviour {
	public string NextLevel;
	AudioSource levelClearSound;
	// Use this for initialization
	void Start () {
		levelClearSound = GameObject.Find ("LevelClearSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown( KeyCode.Equals) ){
			Debug.Log ("load next level");

			LoadNextScene ();
		}
		
	}

	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			LoadNextScene ();
		}
	}
	public void LoadNextScene(){
		//GameObject.Destroy(GameObject.Find ("Orange Goo Pool").gameObject);
		//GameLoopEvents.instance.FadeInOut (1f);
		if(levelClearSound != null){
			levelClearSound.Play ();
		}
		SceneManager.LoadScene (NextLevel);

	}
}
