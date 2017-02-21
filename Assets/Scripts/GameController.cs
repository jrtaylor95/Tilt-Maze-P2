using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int pickupsToWin;

	private Text pickupNum;
	private Text gameStatusMessage;

	private GameObject goal;
	void Start() {
		pickupNum = GameObject.Find ("PickupNumber").GetComponent<Text>();
		gameStatusMessage = GameObject.Find ("StatusMessage").GetComponent<Text> ();
		gameStatusMessage.text = "";
		goal = GameObject.Find ("Goal");
		goal.SetActive (false);
		updatePickupNumber ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Maze_0");
		} else if (Input.GetKeyUp (KeyCode.Q)) {
			Application.Quit ();
		}
	}

	void updatePickupNumber () {
			pickupNum.text = "Number of pickups left: " + pickupsToWin;
	}

	public void decreasePickupNumber() {
		if (pickupsToWin != 0) {
			pickupsToWin--;
			updatePickupNumber ();
		}

		if (pickupsToWin == 0) {
			pickupNum.text = "Done! Go to the Goal!";
			goal.SetActive(true);
		}
	}

	public void showWinningMessage() {
		gameStatusMessage.text = "Congratulations. You win!";
	}

	public void showLosingMessage() {
		gameStatusMessage.text = "Sorry. You lose!";
	}
}
