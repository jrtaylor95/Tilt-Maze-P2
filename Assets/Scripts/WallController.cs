using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	private bool isRotating;
	private float rot;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rot = 0.0f;
		isRotating = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isRotating && Random.Range (0.0f, 10.0f) < Time.deltaTime / 10) {
			rot = 90;
			isRotating = true;
		}
			
		if (isRotating) {
			Vector3 v = Vector3.up * rot * Time.deltaTime;

			rb.transform.Rotate (v);

			if (Mathf.Abs(v.y) <= 0)
				isRotating = false;
			else
				rot -= v.y;
		}
	}
}
