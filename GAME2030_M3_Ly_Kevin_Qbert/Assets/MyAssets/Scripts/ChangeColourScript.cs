using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourScript : MonoBehaviour {

	[SerializeField] Material colour;
	[SerializeField] GameObject cube;
	bool colorScore = false;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other) {

		if (other.tag == "Feet" && colorScore == false) {
			colorScore = true;
			cube.GetComponent<Renderer> ().material = colour;
			GameObject.FindWithTag ("Score").GetComponent<HighScore> ().increaseScore (25);
			GameObject.FindWithTag ("ColorCounter").GetComponent<ColorCounterScript> ().increaseCounter (1);
		}
	}


}
