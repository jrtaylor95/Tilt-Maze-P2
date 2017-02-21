using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour {

	public float tiltSensitivity;
	public float tiltLimit;
	private Rigidbody rb;
	private Transform trans;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		trans = GetComponent<Transform> ();
	}
	
	void Update() {
		float tiltAmount = Time.deltaTime * tiltSensitivity;
		float hTilt = Input.GetAxis ("Horizontal");
		float vTilt = Input.GetAxis ("Vertical");
		Vector3 currentRotation = trans.eulerAngles;
		normalizeEuler (ref currentRotation);

		if (hTilt > 0 && currentRotation.z >= -tiltLimit) {
			rb.transform.Rotate(Vector3.back * tiltAmount);
		} else if (hTilt < 0 && currentRotation.z <= tiltLimit) {
			rb.transform.Rotate(Vector3.forward * tiltAmount);
		}

		if (vTilt > 0 && currentRotation.x <= tiltLimit) {
			rb.transform.Rotate(Vector3.right * tiltAmount);
		} else if (vTilt < 0 && currentRotation.x >= -tiltLimit) {
			rb.transform.Rotate(Vector3.left * tiltAmount);
		}

	}

	void normalizeEuler(ref Vector3 euler) {
		euler.x = euler.x < 180 ? euler.x : euler.x - 360;
		euler.y = euler.y < 180 ? euler.y : euler.y - 360;
		euler.z = euler.z < 180 ? euler.z : euler.z - 360;
	}
}
