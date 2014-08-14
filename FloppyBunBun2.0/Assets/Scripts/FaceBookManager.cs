using UnityEngine;
using System.Collections;

public class FaceBookManager {
	public static bool IsInitialized = false;
	public static string Permissions;

	public static void Initialize()
	{
		if (!IsInitialized) {
			FB.Init(() => { IsInitialized = true; }, (bool IsGameShown) => {
				if(!IsGameShown) {
					Time.timeScale = 0;
				}
				else{
					Time.timeScale = 1;
				}
			});
		}
	}

	public static bool IsAuthenticated{
		get {
			return FB.IsLoggedIn;
		}
	}

	public static void Authenticate(){
		if (IsAuthenticated) {
			//Already Authenticated
			return;
		} 
		//Authenticate if not already
		FB.Login (Permissions, (FBResult result) => {
			if (result.Error != null) {
					//Login Error
			}
		});
	}

	public static void Invite(string inviteTitle, string inviteMessage){
		//if not yet authenticated try to authenticate
		if (!IsAuthenticated) {
			Authenticate();
		}
		if (IsAuthenticated) {
				FB.AppRequest (inviteMessage, null, "", null, null, "", inviteTitle, null);
		}
	}

	public static void Share(string name, string caption, string description, string image, string url){
		//if not yet authenticated try to authenticate
		if (!IsAuthenticated) {
			Authenticate();
		}
		if (IsAuthenticated) {
			FB.Feed ("", url, name, caption, description, image, "", "", "", "", null, null);
		}

	}
}
