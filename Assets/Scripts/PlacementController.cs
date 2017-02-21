using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour {

	public GameObject pickup;
	public GameObject wall;

	private GameObject maze;
	private readonly float OFFSET = 5;
	private readonly float SCALEX;
	private readonly float SCALEZ;
	// Use this for initialization
	void Start () {
		maze = GameObject.Find ("Maze");

		PlaceWalls ();
		PlacePickups ();
	}

	void place(GameObject prefab, Vector3 position, Quaternion rotation) {
		position.x -= OFFSET;
		position.z -= OFFSET;

		GameObject child = Instantiate (prefab, position, rotation);
		child.transform.parent = maze.transform;
	}

	void PlaceWalls() {
		for (int x = 1; x < 10; x++) {
			for (int z = 1; z < 10; z++) {
				if ((x != 5 || z != 5) && (x + z) % 2 == 0) {
					float orientation = Random.Range (0, 4);
					place (wall, new Vector3 (x, 0.5f, z), Quaternion.Euler(0.0f, 90 * orientation, 0.0f));
				}
			}
		}
	}

	void PlacePickups() {
		for (int i = 0; i < 10; i++) {
			float x = Random.Range (0, 10) + 0.5f;
			float z = Random.Range (0, 10) + 0.5f;

			place (pickup, new Vector3 (x, 0.5f, z), pickup.transform.rotation);
		}
	}
}
