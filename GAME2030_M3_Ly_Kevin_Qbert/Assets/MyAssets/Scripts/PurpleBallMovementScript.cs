using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBallMovementScript : MonoBehaviour {
	[SerializeField] GameObject elevator1;
	[SerializeField] GameObject elevator2;
	[SerializeField] GameObject toDie;
	[SerializeField] GameObject coily;

	PurpleBallScript spawn;

	GameObject[,] cubeLayout = new GameObject[7,7];

	public int currRow;
	public int currCol;
	public int nextRow;
	public int nextCol;
	float elapsedTime = 0.0f;
	public float speed = 1.5f; 



	Vector3 startpoint;
	Vector3 midpoint;
	Vector3 endpoint;
	public Vector3 offset = new Vector3 (0.0f, 0.5f, 0.0f);

	bool isMoving = false;
	public bool onElevator = false;

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
				} else {
					
					GameObject snake = Instantiate (coily);
					snake.GetComponent<CoilyScript> ().cRow = currRow;
					snake.GetComponent<CoilyScript> ().cCol = currCol;
					snake.GetComponent<MovementScript> ().setRowSetCol (currRow, currCol);
					Destroy (gameObject);
				}
				break;


			case 3: 
				if (currRow < 6) {
					nextRow = currRow + 1;
					nextCol = currCol + 1;
					isMoving = true;
				} else {
					
					GameObject snake = Instantiate (coily);
					snake.GetComponent<CoilyScript> ().cRow = currRow;
					snake.GetComponent<CoilyScript> ().cCol = currCol;
					snake.GetComponent<MovementScript> ().setRowSetCol (currRow, currCol);
					Destroy (gameObject);
				}
				break;

			case 7: 
				if (currRow > 0 && currCol != 0) {
					nextRow = currRow - 1;
					nextCol = currCol -1;
					isMoving = true;
				}else if(currCol == 0 && currRow == 4)
				{
					Debug.Log ("Jump to right elevator");
					onElevator = true;
					elevator2.GetComponent<ElevatorScript> ().JumpOnElevator();
				}
				else{
					

					GameObject snake = Instantiate (coily);
					snake.GetComponent<CoilyScript> ().cRow = currRow;
					snake.GetComponent<CoilyScript> ().cCol = currCol;
					snake.GetComponent<MovementScript> ().setRowSetCol (currRow, currCol);
					Destroy (gameObject);

				}
				break;

			case 9: 
				if (currRow > 0 && currCol != currRow ){

					nextRow = currRow - 1;
					nextCol = currCol;
					isMoving = true;
				}
				else if(currCol == 4 && currRow == 4)
				{
					Debug.Log ("Jump to right elevator");
					onElevator = true;
					elevator1.GetComponent<ElevatorScript> ().JumpOnElevator();
				}
				else{
					

					GameObject snake = Instantiate (coily);
					snake.GetComponent<CoilyScript> ().cRow = currRow;
					snake.GetComponent<CoilyScript> ().cCol = currCol;
					snake.GetComponent<MovementScript> ().setRowSetCol (currRow, currCol);
					Destroy (gameObject);

				}
				break;

			default:
				return;


			}

			startpoint = cubeLayout [currRow, currCol].transform.position + offset;
			endpoint = cubeLayout [nextRow, nextCol].transform.position + offset;
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