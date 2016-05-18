using UnityEngine;
using System.Collections;

public class Rarity : MonoBehaviour {
	public Color[] color;
	public float despawnOne;
	public float despawnFive;
	public float despawnTen;
	private int randomNumber;
	private int colorNumber;
	private GameController gameController; //getting access to GameController Script
	// Use this for initialization
	void Start () 
	{
		randomNumber = Random.Range (1, 100);

	}
	
	// Update is called once per frame
	void Update () {
		if (randomNumber < 40)
		{
			Renderer r = this.GetComponent<Renderer> ();
			r.material.SetColor ("_Color", color [0]);
			transform.gameObject.tag = "Cube1";
			Destroy (gameObject, despawnOne);
		}
		else if ((randomNumber > 41) && (randomNumber < 80))
		{
			Renderer r = this.GetComponent<Renderer> ();
			r.material.SetColor ("_Color", color [1]);
			transform.gameObject.tag = "Cube2";
			Destroy (gameObject, despawnFive);
		}
		else
		{
			Renderer r = this.GetComponent<Renderer> ();
			r.material.SetColor ("_Color", color [2]);
			transform.gameObject.tag = "Cube3";
			Destroy (gameObject, despawnTen);
		}

	}
}
