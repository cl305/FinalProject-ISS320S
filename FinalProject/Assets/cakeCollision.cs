using UnityEngine;
using System.Collections;

public class cakeCollision : MonoBehaviour {
	public AudioClip cakeSound;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = cakeSound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter() {
		print ("got cake");
		GetComponent<AudioSource> ().Play ();

	}
}
