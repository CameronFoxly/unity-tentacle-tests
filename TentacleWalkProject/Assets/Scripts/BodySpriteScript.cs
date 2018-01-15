using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpriteScript : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody2D> ();
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
}
