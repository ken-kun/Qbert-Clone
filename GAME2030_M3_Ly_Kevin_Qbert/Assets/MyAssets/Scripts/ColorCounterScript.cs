using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorCounterScript : MonoBehaviour {

	 int score = 0;
	[SerializeField] Text colorCounter;


	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		colorCounter.text = score.ToString();
	}

	public void increaseCounter(int number)
	{
		score += number;
		if(score == 28 )
			SceneManager.LoadScene ("YouWin");
	}




}
