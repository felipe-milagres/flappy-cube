using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	private Vector2 _jumpForce = new Vector2(0, 275);

	void onStart(){
	}
	
	// Update is called once per frame
	void Update() {

		#if UNITY_ANDROID
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began){
				Jump();
			}
		}
		#endif

		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0)){
			Jump();
		}
		#endif

		// Die by being off screen
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0){
			Die();
		}

	}

	void Jump(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce(_jumpForce);
	}

	// Die by collision
	void OnCollisionEnter2D(Collision2D other){
		Die();
	}

	void OnTriggerEnter2D(Collider2D other) {

	}
	
	void Die(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
