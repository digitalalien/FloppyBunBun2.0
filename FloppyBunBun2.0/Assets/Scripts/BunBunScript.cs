using UnityEngine;
using System.Collections;

public class BunBunScript : MonoBehaviour {

	public float upForce; //upward force of flapping
	public float forwardSpeed;
	public AudioClip jumpSound;
	public bool isDead = false;

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
	}

	void FixedUpdate(){
		//if flap is triggered
		if (flap) {
			flap = false;
			anim.SetTrigger("Flap");
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

