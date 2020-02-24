using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilySpawn : MonoBehaviour {
	[SerializeField] GameObject purpleBall;
	[SerializeField] GameObject spawn1;


	// Use this for initialization
	void Start () {
		SpawnEnemy ();

	}

	public void SpawnEnemy() {
		GameObject ball;
		ball = Instantiate (purpleBall);
		ball.transform.position = spawn1.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
		ball.GetComponent<PurpleBallMovementScript> ().setRowSetCol (1, 1);
	}

}

