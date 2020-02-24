using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : MonoBehaviour {

	[SerializeField] GameObject qbert;
	[SerializeField] GameObject speech;

	MovementScript move;
	LifeCounterScipt qlife;

	bool doOnce = true;


	// Use this for initialization
	void Awake () {
		move = GetComponent<MovementScript> ();
		qlife = GameObject.FindWithTag ("Lives").GetComponent<LifeCounterScipt> ();

	}

	void Start () {
		qbert = GameObject.FindWithTag ("Player");
		InvokeRepeating ("EnemyMovement", 0, 1);
		move.offset = new Vector3 (0.0f, 1.0f, 0.0f);
		speech = qbert.transform.GetChild (2).gameObject;

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
	public IEnumerator Freeze() {
		Debug.Log ("Freeze redball");
		CancelInvoke ();
		yield return new WaitForSeconds(4);
		InvokeRepeating ("EnemyMovement", 0, 2);
	}
	public void StartFreeze() {
		StartCoroutine ("Freeze");

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.parent.tag == "Player") {
			GameObject.FindWithTag ("Death").GetComponent<AudioSource> ().Play ();

		}
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
