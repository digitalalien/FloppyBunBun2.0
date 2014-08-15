using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = @"Created by: Digital Alien

		Music:
		Monkey Island Band
		by Eric Matyas
		www.soundimage.org";
		guiText.fontSize = Mathf.RoundToInt(Camera.main.pixelHeight / 30f);
	}

}
