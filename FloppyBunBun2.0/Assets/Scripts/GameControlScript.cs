using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	public static GameControlScript current; //a reference to the GameControl so we can access it statically
	public TreeSpawnScript treeSpawner;
	public GUIText scoreText;
	public GameObject gameOverText; 

	int score = 0;
	bool isGameOver = false;

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
		//if the game is over and the user presses something
		if (isGameOver && Input.anyKey) {
			//start a new game
			Application.LoadLevel(Application.loadedLevel);
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
		//show game over
		gameOverText.SetActive (true);
		//set game to be over
		isGameOver = true;
	}

}
