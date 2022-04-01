using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController_Motor : MonoBehaviour
{
	public static CharController_Motor instance;

	private float speed = 10.0f;
	public float walkSpeed;
	public float sprintSpeed;
	public float crouchSpeed;
	public float crouchYScale;
	private float startYscale;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	public GameObject cam;
	public KeyCode sprintKey = KeyCode.LeftShift;
	public KeyCode crouchKey = KeyCode.C;
	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;

	public MovementState state;

	Rigidbody rb;

	public enum MovementState
	{
		walking,
		sprinting,
		crouching,
		air
	}

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		//LockCursor ();
		character = GetComponent<CharacterController>();
		if (Application.isEditor)
		{
			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		}

		startYscale = transform.localScale.y;
	}

	private void MyInput()
	{
		if (Input.GetKeyDown(crouchKey))
		{
			transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
			rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
		}

		if (Input.GetKeyUp(crouchKey))
		{
			transform.localScale = new Vector3(transform.localScale.x, startYscale, transform.localScale.z);
		}
	}

	private void StateHandler()
	{
		if (Input.GetKey(crouchKey))
		{
			state = MovementState.crouching;
			speed = crouchSpeed;
		}

		if (Input.GetKey(sprintKey))
		{
			state = MovementState.sprinting;
			speed = sprintSpeed;
		}

		else
		{
			state = MovementState.walking;
			speed = walkSpeed;
		}


	}

	void CheckForWaterHeight()
	{
		if (transform.position.y < WaterHeight)
		{
			gravity = 0f;
		}
		else
		{
			gravity = -9.8f;
		}
	}



	void Update()
	{
		moveFB = Input.GetAxis("Horizontal") * speed;
		moveLR = Input.GetAxis("Vertical") * speed;

		rotX = Input.GetAxis("Mouse X") * sensitivity;
		rotY = Input.GetAxis("Mouse Y") * sensitivity;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		MyInput();
		CheckForWaterHeight();
		StateHandler();


		Vector3 movement = new Vector3(moveFB, gravity, moveLR);



		if (webGLRightClickRotation)
		{
			if (Input.GetKey(KeyCode.Mouse0))
			{
				CameraRotation(cam, rotX, rotY);
			}
		}
		else if (!webGLRightClickRotation)
		{
			CameraRotation(cam, rotX, rotY);
		}

		movement = transform.rotation * movement;
		character.Move(movement * Time.deltaTime);
	}


	void CameraRotation(GameObject cam, float rotX, float rotY)
	{
		transform.Rotate(0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
	}

	public void KillPlayer()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}