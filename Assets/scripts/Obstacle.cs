using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private Vector2 _velocity = new Vector2(-3, 0);
	
	void Start () {
		rigidbody2D.velocity = _velocity;
		transform.position = new Vector3( transform.position.x, NewYPosition(), transform.position.z );
	}

	void Update () {

		// Remove Obstacle by being off screen
		/*Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.x < -200 ){
			DestroyObstacle();
		}*/

		if( transform.position.x < -6 ) DestroyObstacle();

	}

	void DestroyObstacle() {
		transform.position = new Vector3(6, NewYPosition(), transform.position.z );
	}

	private float NewYPosition(){
		return (float) System.Math.Round( Random.Range (7.0f, 13.0f), 2 );
	}
}
