using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour {
	
	public int scoreType;

	private Text scoreValue;
	private string currentScore;
	private PointTracker pointTracker;
	// Use this for initialization
	void Start () {
		scoreValue = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreType == 0) {
			currentScore = PointTracker.score.ToString();
			scoreValue.text = currentScore;	
		}
			
		if (scoreType == 1) {
			string currentHighScore = PlayerPrefs.GetInt ("highscore").ToString();
			scoreValue.text = currentHighScore;
		}
	}
}