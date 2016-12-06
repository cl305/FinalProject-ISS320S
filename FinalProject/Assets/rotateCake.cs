using UnityEngine;
using System.Collections;

public class rotateCake : MonoBehaviour {
//	public float translatePerSecond = 10.0f;
//	public float translateTime = 1.0f;
	public float rotatePerSecond = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		float wait = 0.0f;
//		wait += Time.deltaTime;
//		if (wait >= 1.0f) {
//			transform.Translate (0, translatePerSecond * Time.deltaTime, 0);
//		} else {
//			transform.Translate (0, -1*translatePerSecond * Time.deltaTime, 0);
//		}
		transform.Rotate(0, rotatePerSecond * Time.deltaTime, 0);
	}
}
