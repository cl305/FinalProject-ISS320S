using UnityEngine;
using System.Collections;

public class bgAudio : bumpCollision {
	
	public GameObject camera; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		bumpCollision bc = (bumpCollision)camera.GetComponent (typeof(bumpCollision));
		bool won = bc.getWin();
		//print (won);
		//print ("bgaudioscript" + won);
		if (won == true) {
			//print ("win audio");
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Stop ();
		}
	
	}
}
