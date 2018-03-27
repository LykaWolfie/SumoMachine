using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	public int coinScore;
	public GameObject player;

	private FallingDown fd;
	private Collide cd;

	private TextMesh tm;
	private Transform coinIcon;
	private float unitCoinScale;


	void Start () {
		fd = player.GetComponent<FallingDown> ();
		cd = player.GetComponent<Collide> ();
		tm = GetComponent<TextMesh> ();
		coinIcon = transform.Find ("Coin Icon").transform;
		unitCoinScale = coinIcon.localScale.y;
		ResetCoinScore ();

		fd.resetScore += ResetCoinScore;
		cd.incrementScore += AddOneToScore;
	}

	public void ResetCoinScore(){
		SetCoinScore (0);
	}

	public void AddOneToScore(){
		coinScore++;
		SetCoinScore (coinScore);
	}

	public void SetCoinScore(int score){
		coinScore = score;
		tm.text = "" + score;
		Vector3 scale = coinIcon.localScale;
		scale.y = unitCoinScale * score;
		coinIcon.localScale = scale;
	}


}
