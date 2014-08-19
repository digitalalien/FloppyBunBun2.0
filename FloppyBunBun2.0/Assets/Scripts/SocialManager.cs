using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using System.Collections.Generic;

public class SocialManager {

	private static bool mWaitingForAuth = false;

	#if UNITY_ANDROID
		public static string leaderboardId = "CgkIs6X734cSEAIQBg";
	#else
		public static string leaderboardId = "";
	#endif

	public static Dictionary<string, bool> MyAchievements = new Dictionary<string, bool>();

	public static bool IsAuthenticated{
		get {
			return Social.localUser.authenticated;
		}
	}

	public static void Authenticate(){
		if (IsAuthenticated) {
			return;
		}

		//If Android Activate Google Play service
		//if (Application.platform == RuntimePlatform.Android) {
			GooglePlayGames.PlayGamesPlatform.Activate();
		//}

		// Authenticate
		mWaitingForAuth = true;
		Social.localUser.Authenticate((bool success) => {
			mWaitingForAuth = false;
			if(success){
				//Authentication Successful
				PlayerPrefs.SetInt("use_game_services", 1);
				LoadAchievements();
			}else{
				//Authentication failed
				PlayerPrefs.SetInt("use_game_services", 0);
			}
		});
	}

	public static void UnlockAchievement(string id){
		if (IsAuthenticated && !MyAchievements.ContainsKey (id)) {
			Social.ReportProgress(id, 100.0f, (bool success) => {});
			MyAchievements[id] = true;
		}
	}

	public static void PostToLeaderboard(int score){
		if (IsAuthenticated) {
			Social.ReportScore((long)score, leaderboardId, (bool success) => {});
		}
	}

	public static void ShowLeaderboardUI(){
		if (!IsAuthenticated) {
			Authenticate();		
		}
		if (IsAuthenticated) {
			Social.ShowLeaderboardUI();		
		}
	}

	public static void ShowAchievementsUI(){
		if (IsAuthenticated) {
			Social.ShowAchievementsUI();		
		}
	}

	public static void LoadAchievements(){
		if (IsAuthenticated) {
			Social.LoadAchievements((IAchievement[] achievements) =>{
				foreach(IAchievement achievement in achievements){
					MyAchievements[achievement.id] = achievement.completed;
				}
			});		
		}
	}
}
