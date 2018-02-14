using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFrameControl : MonoBehaviour {

	public Animation anim;
	public float frameNumber;
	public GameObject bodySprite;
	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = bodySprite.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		frameNumber = rb.velocity.x + 2;

		GetComponent<Animation>()["Turn"].time = 2f;
	}
}
