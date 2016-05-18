using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour {
	// Update is called once per frame
	void Update()
	{
		for(int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch (i).phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				if (Physics.Raycast (ray))
				{
					SceneManager.LoadScene ("Game");
				}
		
			}
		}
	}
}
	