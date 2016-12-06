using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	GUIStyle guiStyle;
	bool guiStyleSetup=false;

	//Constants for HUD
	float BOX_LENGTH = 300; 
	float BOX_WIDTH = 250; 
	float LABEL_X_OFFSET = 0;
	float TIME_Y_OFFSET = 40;
	float DISTANCE_Y_OFFSET = 80;
	float DIFFICULTY_Y_OFFSET = 120;
	float SCORE_Y_OFFSET = 160;
	float WHACKED_Y_OFFSET = 200;
	float BOX_X = 0;
	float BOX_Y = 0;
	int FONT_SIZE = 25; 

	//Game variables
	string difficulty; 
	int gameScore;
	float timeLeft;
	float distanceFromGoal;
	bool whacked; 
	//Game Objects
	public GameObject camera; 
	public GameObject testGoal; 
	public GameObject gameModeObject; 
	private GameMode gm;

	//Pictures
	public Texture2D goodCake;
	public Texture2D ewCake; 

	//GUI Controls
	bool helpMenu = false; 
	bool changeDifficulty = false;  
	bool started = false; 
	bool victory = false;
	bool loss = false; 

	//Public variables
	public GameObject bumpObject; 
	private bumpCollision bc; 

	void OnGUI() {
		if (!helpMenu && started) {
			displayStats ();
		} 
		if (helpMenu && started) {
			displayHelpMenu ();
		}
		if (victory){
			started = false;
			displayVictory ();
		}
		if (loss) {
			started = false;
		}
	}

	private void displayVictory(){
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 350), "Victory!");
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 180, 200, 50), "Congratulations!\nHere's another piece of caek to take home!");
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 50), "Your score: " + (int) gameScore);

		GUI.Label (new Rect (Screen.width / 2 - 60, Screen.height / 2 - 80, 100, 100), goodCake);

		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 25 , 200, 25), "Play again?")){
			Application.LoadLevel (0);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 70, 200, 25), "Exit Game")){
			Application.Quit ();
		}
	}

	private void displayLoss(){
	}

	public void displayStats(){
		if (guiStyleSetup == false) {
			guiStyle = new GUIStyle (GUI.skin.label); 
			guiStyle.fontSize = FONT_SIZE;
//			guiStyle.font = new Font ("Liberation Serif");
			guiStyleSetup = true;
		}

		GUI.Box (new Rect (BOX_X, BOX_Y, BOX_LENGTH, BOX_WIDTH), "Player Stats");
		GUI.color = Color.white;
		GUI.Label (new Rect (LABEL_X_OFFSET, TIME_Y_OFFSET, 200, 200), "Time: " + (int) timeLeft, guiStyle);
		GUI.color = Color.red;
		GUI.Label (new Rect (LABEL_X_OFFSET, DISTANCE_Y_OFFSET, 250, 250), "Distance: " + distanceFromGoal, guiStyle); 
		GUI.color = Color.green;
		GUI.Label (new Rect (LABEL_X_OFFSET, DIFFICULTY_Y_OFFSET, 250, 250), "Difficulty: " + difficulty, guiStyle); 
		GUI.color = Color.blue; 
		GUI.Label (new Rect (LABEL_X_OFFSET, SCORE_Y_OFFSET, 250, 250), "Score: " + gameScore, guiStyle); 
		GUI.color = Color.cyan; 
		string whackedMessage = whacked ? "whacked!" : "";
		GUI.Label (new Rect (LABEL_X_OFFSET, WHACKED_Y_OFFSET, 250, 250), whackedMessage, guiStyle);
	}

	public void displayHelpMenu(){
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "CAEK!");
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "Arrow Keys for Movement and Mouse to move the Camera");
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 25 , 200, 25), "Restart")){
			Application.LoadLevel (0);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 25), "Exit Game")){
			Application.Quit ();
		}
	}

	public void updateDistance(){
		distanceFromGoal = Vector3.Distance (camera.transform.position, testGoal.transform.position);

	}

	public bool getStart(){
		return started;
	}

	public void setStarted(bool s){
		started = s; 
	}

	public void setWhacked(bool w){
		whacked = w;
	}

	// Use this for initialization
	void Start () {	
		gm = (GameMode)gameModeObject.GetComponent(typeof(GameMode));
		bc = (bumpCollision)bumpObject.GetComponent (typeof(bumpCollision));
		timeLeft = gm.getTime();
		updateDistance ();
		gameScore = gm.getScore();
		difficulty = gm.getDifficulity();
		whacked = false; 
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			helpMenu = !helpMenu;
		}
		updateDistance ();
		timeLeft = gm.getTime ();
		gameScore = gm.getScore (); 
		difficulty = gm.getDifficulity ();
		victory = bc.getWin ();
		loss = gm.getTime() == 0;
	}
		
}