	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	public float speed;
	public float jumpPower;
	public AudioClip jumpSound;
	public GameObject sprite;
	public float spriteScalar;

	private Rigidbody2D rb;
	private float h;
	private float v;
	public bool onGround;
	private AudioSource source;
	private Rigidbody2D spriteRB;
	private SpringJoint2D spriteSpring;


	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		onGround = false;
		source = GetComponent<AudioSource> ();
		spriteRB = sprite.GetComponent<Rigidbody2D> ();
		spriteSpring = sprite.GetComponent<SpringJoint2D> ();
	}
		


	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (onGround);

		h = Input.GetAxis ("Horizontal");
		//h = Input.acceleration.x*5f;
		v = Input.GetAxis ("Vertical");

		rb.AddForce (new Vector2 (h * speed, 0));

		if (onGround == true) {

			spriteRB.drag = 1;
			spriteRB.mass = .03f;
			spriteSpring.frequency = 1;
			
			//if (Input.touchCount == 2) {
			if (Input.GetKey(KeyCode.UpArrow)) {
				onGround = false;
				float vol2 = Random.Range (.5f, 1f);
				source.PlayOneShot (jumpSound, vol2);
				spriteRB.drag = 0;
				spriteRB.mass = .001f;
				spriteSpring.frequency = 3;
				rb.AddForce (new Vector2 (h* speed, jumpPower));
				spriteRB.AddForce(new Vector2(h* speed / spriteScalar, jumpPower/ spriteScalar));

			}
		}

		//if (onGround == false) {

			//spriteRB.drag = 0;
		//	spriteRB.mass = .001f;

	//	}

	}


	void OnCollisionEnter2D(Collision2D coll) {
		//if (coll.gameObject.tag == "Ground") {
			
			onGround = true;
	

		//}

	}




}
