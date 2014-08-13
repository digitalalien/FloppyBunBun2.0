using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {

	public float amount = 54.6f; //amount to move the scenery

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Scenery") {
			//get objects position
			Vector3 pos = other.transform.position;
			//add amount to move on x axis
			pos.x += amount;
			//apply to objects position
			other.transform.position = pos;
		}
	}
}
