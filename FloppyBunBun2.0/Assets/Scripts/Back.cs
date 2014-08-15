﻿using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (isTouched ()) {
			Application.LoadLevel("Title");		
		}
	}

	public bool isTouched() {
		bool result = false;
		if(Input.touchCount == 1) {
			if(Input.touches[0].phase == TouchPhase.Ended) {
				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				if (collider2D == Physics2D.OverlapPoint(touchPos)) {
					result = true;
				}
			}
		}
		if(Input.GetMouseButtonUp(0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos = new Vector2(wp.x, wp.y);
			if (collider2D == Physics2D.OverlapPoint(mousePos)) {
				result = true;
			}
		}
		return result;
	}
}