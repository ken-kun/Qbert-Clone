using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	int score = 0;
	[SerializeField] Text scoreCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreCounter.text = score.ToString();
	}

	public void increaseScore(int number)
	{
		score += number;
	}
}
