using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]

public class legDrawScript : MonoBehaviour {

	private LineRenderer lr;

	public GameObject node1;
	public GameObject node2;
	public GameObject node3;
	public GameObject node4;
	public GameObject node5;
	public GameObject foot;

	List<GameObject> objectList = new List<GameObject>();



	// Use this for initialization
	void Start () {
		lr = gameObject.GetComponent<LineRenderer> ();
		//int numPosition = lr.positionCount;
		objectList.Add(node1);
		objectList.Add(node2);
		objectList.Add(node3);
		objectList.Add(node4);
		objectList.Add(node5);
		objectList.Add(foot);
			
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < 6; i++){ 
			lr.SetPosition(i,  objectList[i].transform.position); 
		}

	}
}
