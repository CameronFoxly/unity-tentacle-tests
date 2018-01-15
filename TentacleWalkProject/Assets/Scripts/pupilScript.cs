using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pupilScript : MonoBehaviour {

	public GameObject BodyController;
	public float moveFactor;

	private Rigidbody2D bodyRB;
	private Vector2 eyeMoveAmount;

	// Use this for initialization
	void Start () {
		bodyRB = BodyController.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		eyeMoveAmount = bodyRB.velocity;
		transform.localPosition = (eyeMoveAmount * moveFactor);
	}
}
