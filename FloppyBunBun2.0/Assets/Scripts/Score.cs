using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static float distance = 0;
	public static int totalScore = 0;
	public static bool isLocked = false;
	private int previousScore;

	// Use this for initialization
	void Start () {
		guiText.fontSize = Mathf.RoundToInt (Camera.main.pixelHeight / 17f);
		previousScore = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
