using UnityEngine;
using System.Collections;

public class FaceBookShare : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (isTouched ()) {
			FaceBookManager.Share("Check out my Floppy BunBun Awesomeness!", 
			                      "I have a high score of "+(PlayerPrefs.GetInt("high_score", 0)).ToString()+" points. Bet you can't beat me!",
			                      "Floppy BunBun - How far can you flap those ears?",
			                      "https://lh3.ggpht.com/Y5OIYKyPVD_qckNURsIaLc38dt5_gJaMWUYgitBENlx1QtD2v9fg3KV_ZXc8BIViyevq=w300-rw",
			                      "https://play.google.com/store/apps/details?id=com.digitalalien.floppybunbun");
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
