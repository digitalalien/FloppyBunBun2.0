using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		//if the bunbun hits the trigger collider in between the columns
		//then tell the game the bunbun scored
		GameControlScript.current.BunBunScored ();
	}
}