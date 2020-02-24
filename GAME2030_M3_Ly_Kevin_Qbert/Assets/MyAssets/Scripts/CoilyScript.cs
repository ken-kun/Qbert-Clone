using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : MonoBehaviour {

	MovementScript cMove;
	LifeCounterScipt qlife;

	[SerializeField] GameObject qbert;
	MovementScript qMove;
	[SerializeField] GameObject speech;
	bool doOnce = true;

	int qRow;
	int qCol;
	public int cRow;
	public int cCol;


	void Awake () {
		cMove = GetComponent<MovementScript> ();
		qlife = GameObject.FindWithTag ("Lives").GetComponent<LifeCounterScipt> ();

	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CoilyMovement", 0, 1);
		cMove.setRowSetCol (cRow, cCol);
		qbert = GameObject.FindWithTag ("Player");
		qMove = qbert.GetComponent<MovementScript> ();
		cMove.offset = new Vector3 (0.0f, 0.8f, 0.0f);
		speech = qbert.transform.GetChild (2).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CoilyMovement() {
		qRow = qMove.currRow;
		qCol = qMove.currCol;
		cRow = cMove.currRow;
		cCol = cMove.currCol;

		if (qRow < cRow && qCol > cCol) {
			cMove.jump (9);

		} else if (qRow < cRow && qCol < cCol) {
			cMove.jump (7);

		} else if (qRow > cRow && qCol < cCol) {
			cMove.jump (1);

		} else if (qRow > cRow && qCol > cCol) {
			cMove.jump (3);

		} else if (qRow > cRow && qCol == cCol) {
			cMove.jump (1);

		} else if (qRow < cRow && qCol == cCol) {
			cMove.jump (9);

		} else if (qRow == cRow && qCol > cCol) {
			if (cRow != 6) {
				if (Random.Range (0, 2) == 0) {
					cMove.jump (3);
				} else
					cMove.jump (9);
			} else
				cMove.jump (9);

		} else if (qRow == cRow && qCol < cCol) {
			if (cRow != 6) {
				if (Random.Range (0, 2) == 0) {
					cMove.jump (1);
				} else
					cMove.jump (7);
			} else
				cMove.jump (7);

		} 

	}
	public IEnumerator Freeze() {
		Debug.Log ("Freeze redball");
		CancelInvoke ();
		yield return new WaitForSeconds(4);
		InvokeRepeating ("CoilyMovement", 0, 2);
	}
	public void StartFreeze() {
		StartCoroutine ("Freeze");

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Feet" && doOnce) {
			StartCoroutine ("DeathScene");
		}
	}

	IEnumerator DeathScene() {
		doOnce = false;
		speech.SetActive (true);
		GameObject.FindWithTag ("Death").GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(0.5f);
		speech.SetActive (false);
		qlife.DecreaseLives ();
		doOnce = true;
	}
}
