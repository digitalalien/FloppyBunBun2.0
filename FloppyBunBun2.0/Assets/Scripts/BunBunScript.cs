using UnityEngine;
using System.Collections;

public class BunBunScript : MonoBehaviour {

	public float upForce; //upward force of flapping
	public float forwardSpeed;
	public AudioClip flapSound;
	public bool isDead = false;
	private Vector2 bunbunPosition;

	Animator anim;
	bool flap = false;

	// Use this for initialization
	void Start () {
		//get reference to animator component
		anim = GetComponent<Animator> ();
		//set the bunny to move forward
		rigidbody2D.velocity = new Vector2 (forwardSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//Dont allow update if bunbun is dead
		if (isDead) {
			return;
		}
		//trigger flap
		if (Input.anyKeyDown) {
			flap = true;
		}

		//Determin where the bunny is in relation to the screen and if off screen out of bounds
		bunbunPosition = Camera.main.WorldToScreenPoint (transform.position);
		if (bunbunPosition.y > Screen.height || bunbunPosition.y < 0) {
			isDead = true;
			anim.SetTrigger ("Die");
			GameControlScript.current.BunBunDied ();
		}
	}

	void FixedUpdate(){
		//if flap is triggered
		if (flap) {
			flap = false;
			anim.SetTrigger("Flap");
			AudioSource.PlayClipAtPoint(flapSound, new Vector3(0,0,0), 1.0f);
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
			rigidbody2D.AddForce(new Vector2(0, upForce));
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//if bunbun hits something set to dead
		isDead = true;
		anim.SetTrigger ("Die");
		GameControlScript.current.BunBunDied ();
	}
}

