using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBallScript : MonoBehaviour {

	[SerializeField] GameObject qbert;
	[SerializeField] GameObject speech;
	LifeCounterScipt qlife;

	PurpleBallMovementScript pMove;
	[SerializeField] GameObject coily;
	bool doOnce = true;

	// Use this for initialization
	void Awake () {
		pMove = GetComponent<PurpleBallMovementScript> ();
		qlife = GameObject.FindWithTag ("Lives").GetComponent<LifeCounterScipt> ();

	}

	void Start () {
		qbert = GameObject.FindWithTag ("Player");
		InvokeRepeating ("EnemyMovement", 0, 1);
		pMove.offset = new Vector3 (0.0f, 1.0f, 0.0f);
		speech = qbert.transform.GetChild (2).gameObject;

	}

	// Update is called once per frame
	void Update () {

	}

	void EnemyMovement() {
		if (Random.Range (0, 2) == 0) {
			pMove.jump (1);
		} else
			pMove.jump (3);
		


	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Feet" && doOnce) {
			StartCoroutine ("DeathScene");
		}
	}

	public IEnumerator DeathScene() {
		doOnce = false;
		speech.SetActive (true);
		GameObject.FindWithTag ("Death").GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.5f);
		speech.SetActive (false);
		qlife.DecreaseLives ();
		doOnce = true;
	}


		
}
