using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounterScipt : MonoBehaviour {


	[SerializeField] GameObject life1, life2, life3;
	[SerializeField]GameObject gameOver;
	public int lives;

	// Use this for initialization
	void Start () {
		lives = 3;
		life1.gameObject.SetActive (true);
		life2.gameObject.SetActive (true);
		life3.gameObject.SetActive (true);
		gameOver.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	public void DecreaseLives () {
		lives--;
		switch (lives) {
		case 3: 
			life1.gameObject.SetActive (true);
			life2.gameObject.SetActive (true);
			life3.gameObject.SetActive (false);
			break;

		case 2: 
			life1.gameObject.SetActive (true);
			life2.gameObject.SetActive (false);
			life3.gameObject.SetActive (false);
			Respawn ();
			break;

		case 1: 
			life1.gameObject.SetActive (false);
			life2.gameObject.SetActive (false);
			life3.gameObject.SetActive (false);
			Respawn ();
			break;

		case 0:  
			gameOver.gameObject.SetActive (true);
			//Time.timeScale = 0;
			SceneManager.LoadScene ("MainMenu");
			break;
		}
			
	}

	public void Respawn()
	{
		Destroy (GameObject.FindWithTag ("Coily"));
		List<GameObject> AllEnemies = new List<GameObject> ();
		AllEnemies.AddRange (GameObject.FindGameObjectsWithTag ("RedBall"));
		//Debug.Log ("Enemy array size: " + AllEnemies.Count);
		foreach (GameObject enemy in AllEnemies) {
			Destroy (enemy);

		}

		GameObject.FindWithTag ("CoilySpawn").GetComponent<CoilySpawn> ().SpawnEnemy ();
	}
}
