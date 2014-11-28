using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// The force which is added when the player jumps
	private Vector2 _jumpForce;
	private Score _myScore;
	private bool _die;

	public AudioClip jumpSound;
	public AudioClip hitSound;
	public AudioClip increaseScoreSound;

	private void Start() {
		_jumpForce = new Vector2( 0, 275 );
		_myScore = gameObject.GetComponent<Score>();
		_die = false;
	}

	// Update is called once per frame
	private void Update() {

		#if UNITY_ANDROID
		foreach( Touch touch in Input.touches ){
			if( touch.phase == TouchPhase.Began ){
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
		Vector2 screenPosition = Camera.main.WorldToScreenPoint( transform.position );
		if( ( screenPosition.y > Screen.height || screenPosition.y < 0 ) && !_die ){
			Die();
		}

	}

	private void Jump(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce( _jumpForce );
		//jumpSound.Play();
		if( !_die ) { 
			audio.clip = jumpSound;
			audio.Play();
		}
	}

	// Die by collision
	private void OnCollisionEnter2D( Collision2D other ){
		Die();
	}

	private void OnTriggerEnter2D( Collider2D other ) {
		_myScore.IncreaseScore();
		audio.clip = increaseScoreSound;
		audio.Play();
	}
	
	private void Die(){
		_die = true;
		_myScore.GameOver();
		audio.clip = hitSound;
		audio.Play();
		//Camera.main.audio.Stop();
		//Application.LoadLevel( Application.loadedLevel );
	}
}
