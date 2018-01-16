using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class EyelashScript : MonoBehaviour {

	public Rigidbody2D connectingBall;
	public Vector3 pushBack;

	private LineRenderer lr;
	private Rigidbody2D rb;
	private Vector3 startPoint;
	private Vector3 endPoint;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		lr = GetComponent<LineRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		startPoint = connectingBall.position;
		endPoint = rb.position;

		startPoint += pushBack;
		endPoint += pushBack;


		lr.SetPosition (0, startPoint);
		lr.SetPosition (1, endPoint);


		
	}
}
