using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	[SerializeField] GameObject redBall;
	[SerializeField] GameObject greenBall;
	[SerializeField] GameObject spawn1;
	[SerializeField] GameObject spawn2;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 3, 4);
		
	}

	void SpawnEnemy() {
		GameObject ball;

		if (Random.Range (0, 2) == 0) {
			ball = Instantiate (redBall);

		} else {
			ball = Instantiate (greenBall);
		}
			
		if (Random.Range (0, 2) == 0) {
			
			ball.transform.position = spawn1.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
			ball.GetComponent<MovementScript> ().setRowSetCol (1, 0);

		} else {
			ball.transform.position = spawn2.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
			ball.GetComponent<MovementScript> ().setRowSetCol (1, 1);
		}
			
	}

}
