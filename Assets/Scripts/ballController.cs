using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour {

	public float jumpSensitivity;

	private Rigidbody rb;
	private bool isGrounded;

	private GameController gameController;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		isGrounded = false;
		gameController = GameObject.Find ("KeyListener").GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Goal") {
			gameController.showWinningMessage ();
			rb.AddForce (Vector3.up * 1000f);
			Destroy (gameObject, .5f);
		} else if (other.name == "DeathPlane") {
			gameController.showLosingMessage ();
			Destroy (gameObject);
		} else if (other.gameObject.CompareTag("Pickup")) {
			gameController.decreasePickupNumber ();
			other.gameObject.SetActive (false);
		}
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			jump ();
		}
	}

	void jump() {
		rb.AddForce (Vector3.up * jumpSensitivity);
	}

	void OnCollisionStay(Collision collisionInfo) {
		isGrounded = true;
	}

	void OnCollisionExit(Collision collisionInfo) {
		isGrounded = false;
	}
}
