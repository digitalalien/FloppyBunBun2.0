using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {

	public AudioClip scoreSound;

	void OnTriggerEnter2D(Collider2D other)
	{
		//if the triggering object is the player
		if (other != null && other.CompareTag ("Player")) {
			//if the bunbun hits the trigger collider in between the columns
			//then tell the game the bunbun scored
			GameControlScript.current.BunBunScored ();
			//play score sound
			AudioSource.PlayClipAtPoint(scoreSound, new Vector3 (0, 0, 0), 1.0f);
		}

	}
}