using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 2f;
	public float sensitivity = 4f;
	public GameObject FPCam;
	public float jump = 0f;
	float moveFB;
	float moveLR;
	float rotX;
	float rotY;

	CharacterController player;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
		 

	}
	
	// Update is called once per frame
	void Update () {
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;

		rotX = Input.GetAxis("Mouse X")*sensitivity;
		rotY = Input.GetAxis("Mouse Y")*sensitivity;

		Vector3 movement = new Vector3 (moveLR,0,moveFB);

		transform.Rotate (0, rotX, 0);
		FPCam.transform.Rotate (-rotY, 0, 0);

		movement = transform.rotation * movement;

		player.Move (movement*Time.deltaTime);

	}
}
