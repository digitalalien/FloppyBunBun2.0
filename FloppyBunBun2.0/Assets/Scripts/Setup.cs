using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Setup : MonoBehaviour {

	void Awake(){
		useGUILayout = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Application.targetFrameRate = 60;
		}
		AudioListener.volume = PlayerPrefs.GetInt ("volume", 50);
		FaceBookManager.Initialize ();
		//Gameservice init here
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
