using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 4.0f;
	public float aerialMovementSpeed = 2.0f;
	public float mouseSensitivity = 3.0f;
	public bool invertYAxis = false;
	public float YAxisViewLimit = 60.0f;
	public float jumpSpeed = 4.0f;

	CharacterController characterController;
	float velocityY = 0.0f;
	float rotationY = 0.0f;

	string key = "";
	


	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// Movement

		float speedMultiplier = (characterController.isGrounded) ? movementSpeed : aerialMovementSpeed;

		float forwardSpeed =  Input.GetAxis("Vertical") * speedMultiplier;
		float rightSpeed = Input.GetAxis("Horizontal") * speedMultiplier;

		velocityY += Physics.gravity.y * Time.deltaTime;
		if (Input.GetButtonDown("Jump") && characterController.isGrounded) {
			velocityY = jumpSpeed;
		}
		Vector3 velocity = new Vector3(rightSpeed, velocityY, forwardSpeed);

		// Rotation
		float rotationX = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotationX, 0);

		if (invertYAxis) {
			rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
		}
		else {
			rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		}

		rotationY = Mathf.Clamp(rotationY, -YAxisViewLimit, YAxisViewLimit);
		Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

		// Move player
		characterController.Move(transform.rotation * velocity * Time.deltaTime);

		//Spell Creation


		if(Input.GetKeyDown("z") || Input.GetKeyDown("x") || Input.GetKeyDown("c")
		 || Input.GetKeyDown("v") || Input.GetKeyDown("b")){
			
			if(Input.GetKeyDown("z")){
				key = "z";
			}
			else if(Input.GetKeyDown("x")){
				key = "x";
			}
			else if(Input.GetKeyDown("c")){
				key = "c";
			}			
			else if(Input.GetKeyDown("v")){
				key = "v";
			}			
			else{
				key = "b";
			}
			//player.spellString.push(key);
			//player.restartTimer(spellExhaustTimer);
		}
		if(Input.GetKeyDown("mouse 0")){
			Debug.Log("Firing Spell " + key);
		}
	}
}
