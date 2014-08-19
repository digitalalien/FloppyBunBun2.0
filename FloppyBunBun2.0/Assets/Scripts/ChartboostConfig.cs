using UnityEngine;
using System.Collections;
using Chartboost;

public class ChartboostConfig : MonoBehaviour {

	public static bool wasShown = false;

	void Awake(){
		#if UNITY_ANDROID
		CBBinding.init("53f21e95c26ee458330317de", "9ab37c612b65f80243149d6fcebf64513792abe5");
		//#elif UNITY_IPHONE
		//CBBinding.init("3333", "4444");
		#endif
	}

	// Use this for initialization
	void Start () {
		CBBinding.cacheInterstitial ("Default");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
