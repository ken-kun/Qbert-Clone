using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {

	MovementScript move;

	// Use this for initialization
	void Awake () {
		move = GetComponent<MovementScript> ();

	}

	void Start () {
		move.setRowSetCol (0,0);
		move.offset = new Vector3 (0.0f, 0.7f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown ("[1]")) {
			move.jump (1);
		}
		if (Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown ("[3]")) {
			move.jump (3);
		}
		if (Input.GetKeyDown (KeyCode.Q) || Input.GetKeyDown ("[7]")) {
			move.jump (7);
		}
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown ("[9]") ) {
			move.jump (9);
		}
	}
}
