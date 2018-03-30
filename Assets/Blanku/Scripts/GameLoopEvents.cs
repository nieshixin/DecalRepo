using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLoopEvents : MonoBehaviour {
	
	public static GameLoopEvents instance;

	public GameObject spawnPoint;
	// Use this for initialization
	GameObject FadeObject;
	Image FadeImage;

	Text titleTxt;
	void Start () {
		instance = this;

		FadeObject = GameObject.Find ("FadePanel");
		if (FadeObject != null) {
			FadeImage = FadeObject.GetComponent<Image> ();
		}
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonCharacterController> ().PlayerDied.AddListener (ResetPlayerPosition);
		}

		titleTxt = GameObject.Find ("TitleTxt").GetComponent<Text>();
		iTween.ValueTo (titleTxt.gameObject,iTween.Hash("from", 1f, "to", 0f, "time", 8f, "onupdate", "TweenFadeTxt", "onupdatetarget", gameObject));

		FadeBack (3.7f);
	}
	
	// Update is called once per frame
	void Update () {

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;


	}
	 
	public void ResetPlayerPosition(){

		//FadeInOut (0.5f);
		if(FadeObject!= null)
		iTween.ValueTo (FadeObject,iTween.Hash("from", 0f, "to", 1f, "time", 0.5f, "onupdate", "TweenFadeValue", "onupdatetarget", gameObject, "oncomplete", "FadeBack", "oncompletetarget", gameObject));

		ResetPos ();
	}

	public void ResetPos(){
	//	if (GameObject.FindGameObjectWithTag ("Clone") != null) {
	//		Vector3 diff = spawnPoint.transform.position - GameObject.FindGameObjectWithTag ("Player").transform.position;
	//		GameObject.FindGameObjectWithTag ("Clone").transform.position += diff;
	//	}

		GameObject.FindGameObjectWithTag ("Player").transform.position = spawnPoint.transform.position;


		if (GameObject.FindGameObjectWithTag ("Clone") != null) {
			
			GameObject.FindGameObjectWithTag ("Clone").transform.localPosition = GameObject.FindGameObjectWithTag ("Player").transform.localPosition;
		}
	}



	public void FadeInOut(float time){
		iTween.ValueTo (FadeObject,iTween.Hash("from", 0f, "to", 1f, "time", time, "onupdate", "TweenFadeValue", "onupdatetarget", gameObject, "oncomplete", "FadeBack", "oncompletetarget", gameObject));
	}

	public void ChangeSpawnPoint(GameObject t){
		spawnPoint = t;
	}

	void TweenFadeValue(float value){
		FadeImage.color = new Color (0f,0f,0f,value);
	}

	void TweenFadeTxt(float value){
		titleTxt.color = new Color (0f,0f,0f,value);
	}

	void FadeBack(){
		iTween.ValueTo (FadeObject,iTween.Hash("from", 1f, "to", 0f, "time", 0.5f, "onupdate", "TweenFadeValue", "onupdatetarget", gameObject));
	}

	void FadeBack(float time){
		iTween.ValueTo (FadeObject,iTween.Hash("from", 1f, "to", 0f, "time", time, "onupdate", "TweenFadeValue", "onupdatetarget", gameObject));
	}

}
