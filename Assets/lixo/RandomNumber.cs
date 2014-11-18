using UnityEngine;
using System.Collections;

public class RandomNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log( System.Math.Round( Random.Range( 7.0f,13.0f ) ,2) ); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
