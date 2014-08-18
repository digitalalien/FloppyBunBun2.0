using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Chartboost;

public class Setup : MonoBehaviour {

	void Awake(){
		useGUILayout = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Application.targetFrameRate = 60;
		}
		AudioListener.volume = PlayerPrefs.GetInt ("volume", 50);
		FaceBookManager.Initialize ();
		//Gameservice init here
		if (PlayerPrefs.GetInt ("use_game_services", 0) < 0 ? true : false) {
			SocialManager.Authenticate();		
		}
	}

	// Use this for initialization
	void Start () {
		if(System.String.Compare(Application.loadedLevelName, "GameOver") == 0){
			if(ChartboostConfig.wasShown == false){
				CBBinding.showInterstitial(null);
				CBBinding.cacheInterstitial(null);
				ChartboostConfig.wasShown = true;
			} else{
				if(Random.Range(0,3) == 1){
					CBBinding.showInterstitial(null);
					CBBinding.cacheInterstitial(null);
				}
			}
		}
	}
	
	void OnApplicationQuit(){
		#if UNITY_ANDROID 
			CBBinding.destroy();
		#endif
	}

	void OnApplicationPause(bool paused){
		#if UNITY_ANDROID
			CBBinding.pause(paused);
		#endif
	}
}
