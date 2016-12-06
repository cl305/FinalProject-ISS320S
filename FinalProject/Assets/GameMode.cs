using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {

	float gameTime; 
	string currentDifficulty; 
	bool didChangeDifficulty; 
	int scoreMultiplier; 
	int score; 

	// Use this for initialization
	void Start () {
		currentDifficulty = "Easy"; 
		gameTime = 600f; 
		scoreMultiplier = 1; 
		score = 0; 
	}

	public void changeDifficulty(string difficulty){
		if (difficulty.Equals ("Easy") && !currentDifficulty.Equals ("Easy")) {
			currentDifficulty = "Easy";
			gameTime = 600f; 
			scoreMultiplier = 1;
			print (currentDifficulty);
		} else if (difficulty.Equals ("Medium") && !currentDifficulty.Equals ("Medium")) {
			currentDifficulty = "Medium";
			gameTime = 400f;
			scoreMultiplier = 2;
			print (currentDifficulty);
		} else if (difficulty.Equals ("Hard") && !currentDifficulty.Equals ("Hard")) {
			currentDifficulty = "Hard";
			gameTime = 200f;
			scoreMultiplier = 3; 
			print (currentDifficulty);
		}
	}

	public float getTime(){
		return gameTime; 
	}

	public string getDifficulity(){
		return currentDifficulty;
	}

	public int getMultiplier(){
		return scoreMultiplier;
	}

	public int getScore(){
		return score; 
	}

	public void updateScore(){
		score += scoreMultiplier * 100;
	}

	public void updateTime(){
		gameTime -= Time.deltaTime; 
		if (gameTime <= 0) {
			gameTime = 0f; 
		}
	}

	// Update is called once per frame
	void Update () {
		updateTime ();
		if (gameTime <= 0) {

		}
	}
}
