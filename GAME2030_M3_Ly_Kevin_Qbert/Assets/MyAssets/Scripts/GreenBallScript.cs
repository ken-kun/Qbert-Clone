using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallScript : MonoBehaviour {

	MovementScript move;
	[SerializeField] AudioSource greenBall;

	// Use this for initialization
	void Awake () {
		move = GetComponent<MovementScript> ();

	}

	void Start () {
		InvokeRepeating ("EnemyMovement", 0, 1);
		move.offset = new Vector3 (0.0f, 1.0f, 0.0f);

	}

	// Update is called once per frame
	void Update () {

	}

	void EnemyMovement() {
		if (Random.Range (0, 2) == 0) {
			move.jump (1);
		} else
			move.jump (3);


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Feet") {
			GameObject.FindWithTag ("Score").GetComponent<HighScore> ().increaseScore (100);
		}



		if (other.transform.parent.tag == "Player") {
			GameObject.FindWithTag ("GreenSound").GetComponent<AudioSource> ().Play ();
			List<GameObject> AllEnemies = new List<GameObject> ();
			AllEnemies.AddRange (GameObject.FindGameObjectsWithTag ("RedBall"));
			Debug.Log ("Enemy array size: " + AllEnemies.Count);
			foreach (GameObject enemy in AllEnemies) {
				enemy.GetComponent<BallEnemy> ().StartFreeze ();

			}
			CoilyScript coilyScript = GameObject.FindGameObjectWithTag ("Coily").GetComponent<CoilyScript> ();
			if (coilyScript != null) {
				coilyScript.StartFreeze ();
			}
			Destroy (gameObject);
				
		}
	}


}
