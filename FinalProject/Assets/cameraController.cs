using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	float rotationPitch=0.0f;
	float rotationYaw=0.0f;
	public bool reverseMouse = false;
	public bool reverseKeys = false;
	float varMouse = 1.0f;
	float varKeys = 1.0f;
	//	int reverseMouseMod = 1200;
	//	int[] reverseKeysMod = {500, 600, 700};

	public bool doPitch=false;
	public bool doYaw=true;

	public GameObject camera; 
	public GameObject gameModeObject; 
	private GameMode gm; 
	public GameObject guiObject; 
	private GUIScript gs; 

	//public CharacterController charController;

	// Use this for initialization
	void Start () {
		gm = (GameMode)gameModeObject.GetComponent (typeof(GameMode));
		gs = (GUIScript)guiObject.GetComponent (typeof(GUIScript));
		//		GetComponent<AudioSource> ().playOnAwake = false;
		//		GetComponent<AudioSource> ().clip = bump;

	}

	// Update is called once per frame
	void Update () {
//		bumpCollision bc = (bumpCollision)camera.GetComponent (typeof(bumpCollision));
		int score = gm.getScore();
//		print (score);
		if ((score % 1200 == 0 || score % 1300 == 0 || score % 4300 == 0) && score != 0) {
			//if ((score % 200==0) && score != 0) {
			reverseMouse = true;
			gs.setWhacked (true);
		} else {
			reverseMouse = false;
			gs.setWhacked (false);
		}
		if ((score % 500 == 0 || score % 600 == 0 || score % 700 == 0) && score != 0) {
			//if ((score % 500 == 0) && score != 0) {
			reverseKeys = true;
			gs.setWhacked (true);
		} else {
			reverseKeys = false;
			gs.setWhacked (false);
		}
	if (reverseMouse) {
			varMouse = -1.0f;
			gs.setWhacked (true);
		} else {
			varMouse = 1.0f;
			gs.setWhacked (false);
		}
		if (reverseKeys) {
			varKeys = -1.0f;
			gs.setWhacked (true);
		} else {
			varKeys = 1.0f;
			gs.setWhacked (false);
		}

		CharacterController charController = GetComponent<CharacterController>();

		bool gameStart = gs.getStart ();

		if (doPitch && gameStart)
		{
			rotationPitch += Input.GetAxis ("Mouse Y") * -5.0f*varMouse;
			rotationPitch = Mathf.Clamp (rotationPitch, -45.0f, 45.0f);
		}
		if(doYaw && gameStart)
			rotationYaw += Input.GetAxis ("Mouse X") * 5.0f*varMouse;
		transform.localEulerAngles = new Vector3 (rotationPitch, rotationYaw, 0);

		float deltaX = Input.GetAxis ("Horizontal") * 20.0f*varKeys;
		float deltaZ = Input.GetAxis ("Vertical") * 20.0f*varKeys;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		//movement.y = -9.81f;

		movement = transform.TransformDirection (movement*Time.deltaTime);
		if (gameStart) {
			charController.Move (movement);
		}

	}
	//	public AudioClip bump; 
	//
	//	void OnCollisionEnter(Collision collision) {
	//		GetComponent<AudioSource> ().Play ();
	//	}
}