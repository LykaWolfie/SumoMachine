using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour {

	public float roundDuration;
	public Text timeText;

	private float timeStarted;
	private float timeOfLastUpdate;
	private int timeLeft;

	private bool gameEnded;

	void Start () {
		StartTimer ();
	}
	

	void Update () {
		if (!gameEnded) {
			if (Time.time - timeOfLastUpdate > 1f) {
				UpdateTimeText ();
			}
			if (Time.time - timeStarted > roundDuration) {
				TriggerEndGame ();
			}
		}
	}

	void StartTimer(){
		timeStarted = Time.time;
		gameEnded = false;
	}

	void UpdateTimeText(){
		timeLeft = Mathf.RoundToInt (roundDuration - (Time.time - timeStarted));
		timeText.text = "Time Left: " + timeLeft + "s";
	}

	void TriggerEndGame(){
		gameEnded = true;
		timeText.text = "ASTA LAVISTA BABY!!!";
	}
}
