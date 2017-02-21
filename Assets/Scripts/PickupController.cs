using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.Rotate (Vector3.one * 45 * Time.deltaTime);
	}

	public void removePickup() {
		this.gameObject.SetActive (false);
	}
}
