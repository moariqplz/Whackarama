using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {
	private int points1 = 1;// Setting up the values for the three different types of objects
	private int points2 = 2;
	private int points3 = 3;
	private int totalPoints; // taking all the points together 
	private GameController gameController; //getting access to GameController Script
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController"); //Finding the tag with GameController to identify the object

		if (gameControllerObject != null) // checking if I found it if I did then get teh componets from it.
		{
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameControllerObject == null) // If i didnt find it throw an error.
		{
			Debug.LogError("Unable to find a GameObject named GameController");
		}
		totalPoints = 0; // setting points to zero just to be safe
	}

	void Update()
	{
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch (i).phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				RaycastHit hitInfo;
				if (Physics.Raycast (ray, out hitInfo))
				{
					if  (hitInfo.transform == gameObject.transform && gameObject.tag == "Cube1") //checking if it is cube 1, 2 or 3, as below
					{
						//gameController.AddScore (points1);
						totalPoints += points1; // Kind of redudent but I like to have my functions use one variable
					}
					if ( hitInfo.transform == gameObject.transform && gameObject.tag == "Cube2")
					{
						//gameController.AddScore (points2);
						totalPoints += points2;
					}
					if (hitInfo.transform == gameObject.transform && gameObject.tag == "Cube3")
					{

						totalPoints += points3;

					}
					Destroy (hitInfo.collider.gameObject); // Destroying the object when you mouse over it.
					gameController.AddScore (totalPoints); // calling the AddScore Function from game controller.

				}		
			}
			if (gameController.gameOver == true)
			{
				Destroy (gameObject);
			}
		}
	}

}
