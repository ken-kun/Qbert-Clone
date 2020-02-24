 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
	[SerializeField] GameObject elevator1;
	[SerializeField] GameObject elevator2;
	[SerializeField] GameObject toDie;
	[SerializeField] GameObject speech;

	GameObject[,] cubeLayout = new GameObject[7,7];

	public int currRow;
	public int currCol;
	public int nextRow;
	public int nextCol;
	float elapsedTime = 0.0f;
	Vector3 startpoint;
	Vector3 midpoint;
	Vector3 endpoint;
	public Vector3 offset = new Vector3 (0.0f, 0.80f, 0.0f);

	bool isMoving = false;
	bool jumpingOff = false;
	public bool onElevator = false;
	public float speed = 1.5f;

	// Use this for initialization
	void Start () {



		for (int row = 0; row < 7; row++) {
			for (int col = 0; col < row + 1; col++) {
				cubeLayout [row, col] = GameObject.Find ("Level").transform.GetChild(row).GetChild(col).gameObject;
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
		if (isMoving == true) {
			elapsedTime += Time.deltaTime * speed;
			float timeToEnd = 1.0f - elapsedTime;
			transform.position = timeToEnd * (timeToEnd * startpoint + elapsedTime * midpoint) + 
				elapsedTime * (timeToEnd * midpoint + elapsedTime * endpoint);
			if (elapsedTime > 1.0f) {
				currRow = nextRow;
				currCol = nextCol;
				elapsedTime = 0.0f;
				isMoving = false;
				if (jumpingOff && toDie.tag == "Player") {
					transform.position = startpoint;
					speech.SetActive (false);
					GameObject.FindWithTag ("Lives").GetComponent<LifeCounterScipt> ().DecreaseLives ();
				} else if (jumpingOff) {
					Destroy (toDie);
				}
			}
		}
	}

	public void jump(int direction)
	{
		if (isMoving == false && onElevator == false) {
		switch (direction) {
		case 1: 
			if (currRow < 6) {
				nextRow = currRow + 1;
				nextCol = currCol;
				isMoving = true;
				GetComponent<AudioSource> ().Play ();
			} else {
				jumpingOff = true;
					startpoint = cubeLayout [currRow, currCol].transform.position + offset;
					endpoint = startpoint + new Vector3(-0.7f, 0.0f, -0.7f);
				if (toDie.tag == "Player") {
					GameObject.FindWithTag ("Death").GetComponent<AudioSource> ().Play ();
					speech.SetActive (true);
				}
					isMoving = true;
			}
			break;


		case 3: 
			if (currRow < 6) {
				nextRow = currRow + 1;
				nextCol = currCol + 1;
				isMoving = true;
				GetComponent<AudioSource> ().Play ();
			} else {
					jumpingOff = true;
					startpoint = cubeLayout [currRow, currCol].transform.position + offset;
					endpoint = startpoint + new Vector3(0.7f, 0.0f, -0.7f);
				if (toDie.tag == "Player") {
					GameObject.FindWithTag ("Death").GetComponent<AudioSource> ().Play ();
					speech.SetActive (true);
				}
					isMoving = true;
			}
			break;

		case 7: 
			if (currRow > 0 && currCol != 0) {
			nextRow = currRow - 1;
			nextCol = currCol -1;
			isMoving = true;
					GetComponent<AudioSource> ().Play ();
			} else if(currCol == 0 && currRow == 4)
			{
				Debug.Log ("Jump to right elevator");
				onElevator = true;
				elevator2.GetComponent<ElevatorScript> ().JumpOnElevator();
			}
			else{
					jumpingOff = true;
					startpoint = cubeLayout [currRow, currCol].transform.position + offset;
					endpoint = startpoint + new Vector3(-0.7f, 0.0f, 0.7f);
				if (toDie.tag == "Player") {
					GameObject.FindWithTag ("Death").GetComponent<AudioSource> ().Play ();;
					speech.SetActive (true);
				}
					isMoving = true;
			}
			break;

		case 9: 
			if (currRow > 0 && currCol != currRow ){
					
			nextRow = currRow - 1;
			nextCol = currCol;
			isMoving = true;
					GetComponent<AudioSource> ().Play ();
			}
			else if(currCol == 4 && currRow == 4)
			{
					Debug.Log ("Jump to right elevator");
					onElevator = true;
					elevator1.GetComponent<ElevatorScript> ().JumpOnElevator();
			}
			else{
					jumpingOff = true;
					startpoint = cubeLayout [currRow, currCol].transform.position + offset;
					endpoint = startpoint + new Vector3(0.7f, 0.0f, 0.7f);
				if (toDie.tag == "Player") {
					GameObject.FindWithTag ("Death").GetComponent<AudioSource> ().Play ();
					speech.SetActive (true);

				}
					isMoving = true;
			}
			break;

		default:
			return;


		}

		if (!jumpingOff) {
			startpoint = cubeLayout [currRow, currCol].transform.position + offset;
			endpoint = cubeLayout [nextRow, nextCol].transform.position + offset;
		}

			midpoint = (startpoint + endpoint) / 2;
			midpoint += new Vector3 (0.0f, 1.0f, 0.0f);
		}
	}

	public void setRowSetCol(int r, int c)
	{
		currRow = r;
		currCol = c;
	}
}
