using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpriteScript : MonoBehaviour {


	public AudioClip bumpSound;

	private Rigidbody2D rb;
	private AudioSource source;

	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody2D> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (rb.velocity);
		rb.rotation =  -rb.velocity.x * 4f;

		//if (Input.GetKey (KeyCode.DownArrow)) {
		if (Input.touchCount == 2) {
			rb.AddForce (new Vector2 (0, -1f));
		}
			

	}

	void OnCollisionEnter2D (Collision2D coll){
		float vol = Random.Range (.5f, 1f);
		source.PlayOneShot (bumpSound, vol);

	}

}
