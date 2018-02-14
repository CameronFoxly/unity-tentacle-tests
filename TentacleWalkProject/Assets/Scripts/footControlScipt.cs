using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footControlScipt : MonoBehaviour {

	public float jumpPower;
	public GameObject BodySprite;
	public float maxDistance;
	public float stepDistance;
	public float maxSpeed;
	public float speed;
	public float stepHeight;
	public AudioClip footStepSound;
	public float footCallNumber;
	public float distanceThreshold;
	public float speedThreshold;
	public float defaultDistance;
	public float comfortWaitTime;

	private AudioSource source;
	private float stepSpeed;
private float v;
	private float h;
	private Rigidbody2D rb;
	private Rigidbody2D bodySpriteRB;
	private GameObject BodyController;
	private Rigidbody2D bodyControlRB;
	private float distanceFromCenter;
	private Vector3 footDestination;
	private int direction;
	private float moveAmount;
	private Vector3 startingPos;
	private float moveX;
	private float moveY;
	private float randomNum;
	private float centerMarkX;

	public bool isMoving;
	public bool onGround;

	private int waitCount;
	public int waitTotal;
	//private bool bodyOnGround;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();

		bodySpriteRB = BodySprite.GetComponent<Rigidbody2D>();
		onGround = false;
		isMoving = false;
		source = GetComponent<AudioSource> ();
		BodyController = GameObject.FindWithTag ("Player");
		bodyControlRB = BodyController.GetComponent<Rigidbody2D>(); 
		rb.drag = 15;
		rb.mass = 20;
		waitCount = 0;
		randomNum = Random.Range (.7f, 1.1f);
		//bodyOnGround = BodyController.GetComponent<PlayerControlScript>().onGround;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (onGround);
		//Debug.Log (isMoving);
		//Debug.Log (footCallNumber);

		maxDistance = 2.5f;
		stepDistance = 3;
		defaultDistance = .5f;
		//h = Input.acceleration.x*5f;
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis ("Vertical");
			

		//if you are in the air;
		if (onGround == false) {
			isMoving = false;
			rb.drag = 0;
			rb.velocity = bodyControlRB.velocity; 
			//rb.AddForce (new Vector2 (h * speed, 0));
	

		}

		//WHAT HAPPENS ONCE FOOT TOUCHES THE GROUND. First check from jump button.

		if (onGround == true) {

			//What to do if you hit jump.
			//if (Input.touchCount == 2) {
			if (Input.GetKey(KeyCode.UpArrow) || Input.touchCount == 2) {
				onGround = false;
				isMoving = false;
				//rb.drag = 0;
				rb.velocity = bodyControlRB.velocity;
				rb.AddForce (new Vector2 (h * speed*40, jumpPower));
			}

			//if (Input.touchCount == 1) {
			if (Input.GetKey (KeyCode.DownArrow) || Input.touchCount == 1) {
				maxDistance = 2.5f;
				stepDistance = 4;
				defaultDistance = .8f;

			}



		}
			


		if (onGround == true) {
				rb.drag = 0;
				rb.mass = 20;
				distanceFromCenter = Vector3.Distance (gameObject.transform.position, bodyControlRB.transform.position);

				//What to do once the foot is flat on the ground. These things set once for the begenning of the step.
	
				if (isMoving == false) {
					//distanceFromCenter = Vector3.Distance (gameObject.transform.position, bodyControlRB.transform.position);  
					
					//What to do if the current foot is too far center and needs to adjust.
					if (distanceFromCenter > maxDistance) {

						isMoving = true;
						startingPos = rb.transform.position;
						stepSpeed = Mathf.Abs (bodySpriteRB.velocity.x);

						
						if (stepSpeed < 1f) {
							stepSpeed = 4f;
						}
						
						//Debug.Log (stepSpeed);

						if (rb.transform.position.x > BodySprite.transform.position.x) {
							direction = -1;
						} else {
							direction = 1;
						}

						footDestination = new Vector3 (rb.transform.position.x + stepDistance * direction, rb.transform.position.y, 0);
						//Debug.DrawLine (rb.transform.position, footDestination);

					}
					

					//What to do if the current foot is on the ground, and within the bounds, but the guy comes to a full stop. Resetting the feet positions to comfortable.
					if (Mathf.Abs(bodyControlRB.velocity.x) < speedThreshold) {
					
						if (waitCount > waitTotal*footCallNumber){
						isMoving = true;
						startingPos = rb.transform.position;
						centerMarkX = bodyControlRB.position.x;
						//stepSpeed = Random.Range (1f, 4f);
						
						footDestination = new Vector3 ((centerMarkX - (defaultDistance * 2)) + (defaultDistance * footCallNumber), rb.transform.position.y, 0);
						waitCount = 0;
						}
						waitCount++;
						
						

					}

						

				}

				//This is the behavior that happens while the foot is Stepping.
				if (isMoving == true) {
					distanceFromCenter = Mathf.Abs (rb.transform.position.x - footDestination.x);
					if (footCallNumber ==2) {
						//Debug.Log(distanceFromCenter);
						Debug.DrawLine (rb.position, footDestination);
					}
					
					//Resetting things once the foot reaches it's destination.
					if (distanceFromCenter < distanceThreshold) {
						
						isMoving = false;
						//moveAmount = 0;
						waitCount = 0;

					}
					
					if (isMoving == true) {

					//Here is the actual movement function on the step. 
					if (distanceFromCenter >= distanceThreshold) { 
							
					
							moveX = Mathf.Lerp (startingPos.x, footDestination.x, moveAmount);
							moveY = startingPos.y + (stepSpeed/ 5f) * stepHeight * Mathf.Sin (moveAmount * Mathf.PI) * randomNum;
							
							rb.transform.position = new Vector3 (moveX, moveY, 0);
							
							if (footCallNumber ==2) {
							Debug.Log(moveAmount + "moveamount");
							Debug.Log ("Hey!");
							}

							moveAmount += .01f * maxSpeed * stepSpeed;
						}
					}
					
				}

		}

	}
		

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Ground"){
			rb.velocity = new Vector2 (0, 0);
			onGround = true;
			isMoving = false;
			moveAmount = 0;
			if (footCallNumber ==2) {
				Debug.Log ("Hit Ground!");
			}

		}
		randomNum = Random.Range (.7f, 1f);
		float vol = Random.Range (.05f, .2f);
		source.PlayOneShot (footStepSound, vol);
	}

}

