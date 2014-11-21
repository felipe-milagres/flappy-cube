using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int _score;
	private int _bestScore;
	public GUISkin customSkin;
	private bool _gameOver;

	private void Start(){
		_score = 0;
		_bestScore = 0;
		_gameOver = false;

		ParseXML database = new ParseXML("data");
		_bestScore = int.Parse( database.getElementXML( "best_score" ) );
	}

	private void OnGUI(){
		// custon skin { font-family , font-size }
		GUI.skin = customSkin;
		// score
		GUI.Label( new Rect( 10,0,100,30 ), _score+"" );

		GUI.Label(new Rect(20,Screen.height-30,250,100), _bestScore+" BS");
		GUI.Label(new Rect(Screen.width-80,Screen.height-30,250,100), _score+" S");

		// if games over, "GAME OVER ModalWindow" show up
		if( _gameOver ){
			GUI.Box (new Rect (0,0,Screen.width,Screen.height ), "");
			GUI.ModalWindow( 0, new Rect( Screen.width/2 - 115, Screen.height/2 - 75,230 , 150), DoMyModalWindow, "Game Over" );
		}
	}

	// GAME OVER ModalWindow
	private void DoMyModalWindow( int windowID ){
		
		// current time
		GUI.BeginGroup (new Rect (10,33, 100, 70));
			GUI.Box (new Rect (0,0,100,70), "Your Score:");
			GUI.Label(new Rect(10,40,250,100), _score+"");
		GUI.EndGroup ();
		
		// best time
		GUI.BeginGroup (new Rect (120, 33, 100, 70));
			GUI.Box (new Rect (0,0,100,70), "Best Score:");
			GUI.Label(new Rect(10,40,250,100), _bestScore+"");
		GUI.EndGroup ();

		// restart the game 
		if (GUI.Button(new Rect(55, 110, 120, 30), "Play again")){
			Application.LoadLevel( Application.loadedLevel ); // reload the level
			Time.timeScale = 1; // unpause game
		}

	}

	public void GameOver(){
		SaveData();
		_gameOver = true;
		Time.timeScale = 0; // pause game
	}

	public void IncreaseScore(){
		_score++;
	}

	private void SaveData(){
		// get my database ( it's a XML file )
		ParseXML database = new ParseXML("data");

		if( _score > int.Parse( database.getElementXML( "best_score" ) ) ){
			database.changeValueOf( "best_score", _score+"" );
		}

		_bestScore = int.Parse( database.getElementXML( "best_score" ) );

	}

}
