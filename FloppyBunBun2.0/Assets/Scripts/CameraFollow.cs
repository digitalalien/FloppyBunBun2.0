using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target; //target for the camera to follow
	public float xOffset; //how much x-axis space should be between the camera and target
	
	// Update is called once per frame
	void Update () {
		//follow the target, x-axis only
		transform.position = new Vector3 (target.position.x + xOffset, transform.position.y, transform.position.z);
	}
}
