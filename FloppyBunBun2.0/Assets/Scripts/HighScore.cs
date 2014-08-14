using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.fontSize = Mathf.RoundToInt (Camera.main.pixelHeight / 17f);
		guiText.text = System.String.Concat ("Best Score\n", CalculateHighScore (GameControlScript.score).ToString ());
	}

	int CalculateHighScore (int score) {
		int PreviousHighScore = PlayerPrefs.GetInt ("high_score", 0);
		if (score > PreviousHighScore) {
			PlayerPrefs.SetInt("high_score", score);
			//SocialManager.PostToLeaderBoard((int)score);
		}
		return PlayerPrefs.GetInt ("high_score", 0);
	}
}
