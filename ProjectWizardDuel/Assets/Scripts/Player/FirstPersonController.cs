using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class FirstPersonController : NetworkBehaviour {

	public float movementSpeed = 4.0f;
	public float aerialMovementSpeed = 2.0f;
	public float mouseSensitivity = 3.0f;
	public bool invertYAxis = false;
	public float YAxisViewLimit = 60.0f;
	public float jumpSpeed = 4.0f;

	CharacterController characterController;
	GameObject playerCamera;
	float velocityY = 0.0f;
	float rotationY = 0.0f;
	

	// Use this for initialization
	void Start () {
		characterController = this.GetComponent<CharacterController>();
		playerCamera = this.transform.Find("Camera").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) { return; }

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
		playerCamera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

		// Move player
		characterController.Move(transform.rotation * velocity * Time.deltaTime);

	}
}
