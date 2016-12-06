using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour {

	public GameObject gameModeObject; 
	private GameMode gm; 
	public GameObject guiObject;
	private GUIScript gs;
	public Texture2D caekSplash; 

	//Display variables
	bool changeDifficulty = false; 
	bool displayTitle = true; 

	// Use this for initialization
	void Start () {
		gm = (GameMode)gameModeObject.GetComponent (typeof(GameMode));
		gs = (GUIScript)guiObject.GetComponent (typeof(GUIScript));
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (displayTitle) {
			displayTitleScreen ();
		}

		if (changeDifficulty) {
			displayChangeDifficulty ();
		}
	}

	public void displayTitleScreen(){
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "");
		GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 190, 400, 400), caekSplash);
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50), "Instructions: \nArrow Keys for Movement\nMouse to control the Camera");
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 25, 200, 25), "Start Game")){
			changeDifficulty = true;
			displayTitle = false;
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2  + 75, 200, 25), "Exit Game")){
			Application.Quit ();
		}
	}

	public void displayChangeDifficulty(){
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "Choose your difficulty");
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 25), "Easy")) {
			gm.changeDifficulty ("Easy");
			changeDifficulty = false;
			gs.setStarted (true);
			print (gs.getStart ());
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 25), "Medium")) {
			gm.changeDifficulty ("Medium");
			changeDifficulty = false;
			gs.setStarted (true);

		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 25), "Hard")){
			gm.changeDifficulty ("Hard");
			changeDifficulty = false; 
			gs.setStarted (true);
		}
	}
}
