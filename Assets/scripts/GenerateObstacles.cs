using UnityEngine;
using System.Collections;

public class GenerateObstacles : MonoBehaviour {

	public GameObject rocks;
	//private int score = 0;
	
	// Use this for initialization
	void Start(){
		InvokeRepeating("CreateObstacle", 1f, 1.06f); // 2.1

	}
	
	void CreateObstacle(){
		Instantiate(rocks);
		//score++;
	}

	/*
	void OnGUI () 
	{
		GUI.color = Color.white;
		GUILayout.Label(" Score: " + score.ToString());
	}
	*/
}