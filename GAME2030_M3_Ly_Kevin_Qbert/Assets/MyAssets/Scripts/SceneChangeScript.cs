using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour {

	[SerializeField] string LevelToLoad;


	public void DoSceneChange () {
		SceneManager.LoadScene (LevelToLoad);
	}
	

}
