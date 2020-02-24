using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {
	[SerializeField] GameObject qbert;
	[SerializeField] GameObject topCube;
	[SerializeField] Animator animn;

	float elapsedTime = 0.0f;
	Vector3 startpoint;
	Vector3 midpoint;
	Vector3 endpoint;
	Vector3 offset = new Vector3 (0.0f, 0.25f, 0.0f);

	bool isMoving = false;
	bool atTop = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving == true) {
			elapsedTime += Time.deltaTime;
			float timeToEnd = 1.0f - elapsedTime;
			qbert.transform.position = timeToEnd * (timeToEnd * startpoint + elapsedTime * midpoint) + 
				elapsedTime * (timeToEnd * midpoint + elapsedTime * endpoint);
			if (elapsedTime > 1.0f) {
				if (atTop == false) {
					elapsedTime = 0.0f;
					animn.enabled = true;
					GetComponent<AudioSource> ().Play ();
					qbert.transform.parent = transform;
					isMoving = false;
				} else {
					qbert.GetComponent<MovementScript> ().onElevator = false;
					qbert.GetComponent<MovementScript> ().currRow = 0;
						qbert.GetComponent<MovementScript> ().currCol = 0;	
					Destroy (gameObject);
				}
					
			}
		}
	}

	public void JumpOnElevator() {
		startpoint = qbert.transform.position;
		endpoint = transform.position + offset;
		midpoint = (startpoint + endpoint) / 2;
		midpoint += new Vector3 (0.0f, 1.0f, 0.0f);
		isMoving = true;
	}

	public void JumpOffElevator() {
		offset = new Vector3 (0.0f, 0.5f, 0.0f);
		atTop = true;
		qbert.transform.parent = null;
		startpoint = qbert.transform.position;
		endpoint = topCube.transform.position + new Vector3(0.0f,0.7f, 0.0f);
		midpoint = (startpoint + endpoint) / 2;
		midpoint += new Vector3 (0.0f, 1.0f, 0.0f);
		isMoving = true;

	}
}
