using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
	//Public Variables
	public int numberOfCubes; // So I can create a base spawn of cubes
	public GameObject cube; //Creating the object for the prefab
	public Text scoreText; //Creating text for the object
	public Text gameOverText; //Creating text for the object
	public Text restartText; //Creating text for the object
	public Text finalScoreText; //Creating text for the object
	public bool gameOver = false; // creating a ending
	public int timeLeft; // checking for the time
	//Private Variables
	private int score; // Setting score to go into update score so people can keep track of the score
	private int totalCubes; // adding more prefabs add  everytime the update runs untill 20
	private bool restart;
	// Use this for initialization
	void Start() {
		gameOver = false;// being safe setting to false.
		restart = false;
		totalCubes = 0; //being safe setting cubes to zero
		score = 0; // being safe setting score to zero
		UpdateScore (); // making sure the update score runs at the start 
		StartCoroutine (Spawn(.1F)); // setting the spawn rate for the cubes
		StartCoroutine (TimeLimit()); //setting the time limit for the game
	}

	void Update()
	{
		if (numberOfCubes > totalCubes) // this spawns the cubes in the range of the Camera
		{
			Vector2 position = new Vector2 (Random.Range (-5.0F, 5.0F), Random.Range (-4.5F, 4.5F)); // the camera is actually 5.5 by 5.5 but I will create a edge to make it look nice
			Instantiate (cube, position, Quaternion.identity); //spawning the cubes
			totalCubes++; // adding to keep track
		}
		if (timeLeft == 0) // setting the time limit for the game
		{
			gameOver = true;
			restart = true;
			gameOverText.text = "Game Over!";
			finalScoreText.text = "Final Score: " + score;
			restartText.text = "If you would like to play again press R";
		}
		if ((restart == true) && Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene ("Game");
		}

		//Debug.Log (amountOfPoints.ToString ());

	}
	IEnumerator Spawn (float waitTime)
	{
		while (gameOver != true)//checking if it should still spawn cubes
		{
			yield return new WaitForSeconds (waitTime); // wait times for the cubes and its .1 
			Vector2 position = new Vector2 (Random.Range (-5.0F, 5.0F), Random.Range (-4.5F, 4.5F)); // creating the range like above for spawning
			Instantiate (cube, position, Quaternion.identity); // actually spawning them

		}
	}
	IEnumerator TimeLimit() // creating a time limit for the game
	{

		while(gameOver == false) // checking if the timelimit has been reached if so it stops
		{
		yield return new WaitForSeconds (1); //waiting a second of time
		timeLeft -= 1; // adding to the time limit
		}
	}


	public void AddScore(int newScoreValue) // the add score function
	{
		score += newScoreValue; // adding the new score from the mouse over script into the score to track
		UpdateScore (); // calling this function to update the score
	}
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

}