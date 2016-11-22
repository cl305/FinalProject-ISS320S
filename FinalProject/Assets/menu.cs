//using UnityEngine;
//using System.Collections;
//using UnityEngine.SceneManagement;
//
//public class menu : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if (Input.GetKeyDown (KeyCode.Escape)) {
//			if (showMain == true) {
//				showMain = false;
//			} else {
//				showMain = true;
//			}
//		}
//
//		// for this example, the bar display is linked to the current time,
//		// however you would set this value based on your desired display
//		// eg, the loading progress, the player's health, or whatever.
//		barDisplay = Time.time * 0.05;
//	}
//
//	bool showMain = true;
//	bool showSettings = false;
//	private int toolbarInt = 0;
//	float sliderValue = 5.0f;
//
//	//	void Awake() {
//	//		toolbarPics = new Texture2D[] {elliot, mrrobot, friend};
//	//
//	//		DontDestroyOnLoad(transform.gameObject);
//	//
//	//	}
//
//	var barDisplay : float = 0;
//	var pos : Vector2 = new Vector2(20,40);
//	var size : Vector2 = new Vector2(60,20);
//	var progressBarEmpty : Texture2D;
//	var progressBarFull : Texture2D;
//
//	void OnGUI() {
//
//		if (showMain == true) {
//
//			GUI.Box (new Rect (100, 50, Screen.width - 200, Screen.height - 100), "Main Menu");
//			GUI.Label (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 130, 300, 300), "Your goal is to navigate the maze and find the target object. Beware of the monster chasing you!!");
//
//
//			if (GUI.RepeatButton (new Rect (Screen.width / 2 - 50, Screen.height - 125, 100, 25), "Exit Game")) {
//				Application.Quit ();
//			}
//				
//
//		}
//
//		// draw the background:
//		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
//		GUI.Box (Rect (0,0, size.x, size.y),progressBarEmpty);
//
//		// draw the filled-in part:
//		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
//		GUI.Box (Rect (0,0, size.x, size.y),progressBarFull);
//		GUI.EndGroup ();
//
//		GUI.EndGroup ();
//
//
//	}
//
//
//}
