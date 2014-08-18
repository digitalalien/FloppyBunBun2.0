using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	public static GameControlScript current; //a reference to the GameControl so we can access it statically
	public TreeSpawnScript treeSpawner;
	public GUIText scoreText;
	public GameObject gameOverText; 
	private int previousScore;

	public static int score = 0;
	bool isGameOver = false;

	void Start(){
		previousScore = 0;
	}

	void Awake()
	{
		//if we dont have a game control
		if (current == null) {
				//set this one to be it
				current = this;
		} else if (current != this) {
			//destroy this one because it is a duplicate
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (score >= 1000) {
			#if UNITY_ANDROID			
			SocialManager.UnlockAchievement("CgkIs6X734cSEAIQBQ");
			#endif
		}
		else if (score >= 250) {
			#if UNITY_ANDROID			
			SocialManager.UnlockAchievement("CgkIs6X734cSEAIQBA");
			#endif
		}
		else if (score >= 100) {
			#if UNITY_ANDROID			
			SocialManager.UnlockAchievement("CgkIs6X734cSEAIQAw");
			#endif
		}
		else if (score >= 10) {
			#if UNITY_ANDROID			
			SocialManager.UnlockAchievement("CgkIs6X734cSEAIQAg");
			#endif
		}
	}

	public void BunBunScored()
	{
		//the bird cant score if the game is over
		if (isGameOver) {
			return;		
		}
		//increase the score
		score++;
		//adjust the score text
		scoreText.text = "Score: " + score;
	}

	public void BunBunDied()
	{
		//stop spawning trees
		treeSpawner.StopSpawn ();
		//Unlock GameOver Acheivement
		#if UNITY_ANDROID
			SocialManager.UnlockAchievement("CgkIs6X734cSEAIQAQ");
		//#elif UNITY_IPHONE
		//	SocialManager.UnlockAchievement();
		#endif
		//set game to be over
		isGameOver = true;

		//show Game Over scene
		Application.LoadLevel ("GameOver");
	}

}
