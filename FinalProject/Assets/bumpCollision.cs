using UnityEngine;
using System.Collections;

public class bumpCollision : MonoBehaviour {

	public AudioClip bumpSound;
	public AudioClip cakeSound;
	public AudioClip cakeSound2;
	public AudioClip winSound;
	public GameObject gameModeObject; 
	private GameMode gm;

	bool win = false;
	float score;
	int yayRange;
	int yayCount;

	public bool getWin(){
		//print (win);
		return win;
	}

	public float getScore() {
		return score;
	}
	// Use this for initialization
	void Start () {
		gm = (GameMode)gameModeObject.GetComponent (typeof(GameMode));
		yayRange = Random.Range (0, 6);
		yayCount = 0;

	}
	float wait = 0.0f;
	//float cakeWait = 0.0f;
	float greatJobWait = 0.0f;
	// Update is called once per frame
	void Update () {
		wait += Time.deltaTime;
		//cakeWait += Time.deltaTime;
		greatJobWait += Time.deltaTime;
		//print (win);
		//print (wait);
		//print ("range" + yayRange);
		//print ("count" + yayCount);

	}


	//AudioSource audio;
	void OnCollisionEnter(Collision col) {
		AudioSource audio = GetComponent<AudioSource>();
		//		if (!audio.isPlaying) {
		//			audio.volume = col.relativeVelocity.magnitude / 20;
		//		if (col.gameObject.tag == "Wall") {
		//			//Debug.Log (AudioSource);
		//			GetComponent<AudioSource> ().Play ();
		//		}
		if (col.gameObject.tag == "Wall" && wait >= 2.5f) {
			print ("hit wall");
			//			AudioSource audio = GetComponent<AudioSource> ();
			//			audio.Play ();
			Vector3 currentPos = transform.position;
			AudioSource.PlayClipAtPoint (bumpSound, currentPos);
			wait = 0.0f;
		}
		if (col.gameObject.tag == "Cake" ) {
			gm.updateScore ();
			score += 100.0f;
			print ("got cake, score: "+ score);

			//			Vector3 currentPos = transform.position;

			//			AudioSource.PlayClipAtPoint (cakeSound, currentPos);
			Transform cakeChild = col.gameObject.transform.GetChild(0);
			cakeChild.gameObject.SetActive(false);
			col.gameObject.SetActive (false);


			if (yayCount < yayRange) {
				yayCount++;
				audio.clip = cakeSound;
			} else {
				audio.clip = cakeSound2;
				yayCount = 0;
				yayRange = Random.Range (0, 6);
			}
			audio.Play();



			//cakeWait = 0.0f;

		}
		if(col.gameObject.tag == "Goal" && greatJobWait >= 5.0f) {

			print ("you win!!");
			win = true;
			//print (win);
			audio.clip = winSound;
			audio.Play();
			greatJobWait = 0.0f;
		}
		//		}
	}



}