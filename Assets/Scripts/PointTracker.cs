using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTracker : MonoBehaviour {
	public LevelManager levelManager;
	public static int highscore;
	public static float life = 1;
	public static int score = 0;
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			// Put levelManager prefab in the inspector
			levelManager.LoadNextLevel ();
		}

		if (score >= PlayerPrefs.GetInt ("highscore")) {
			highscore = score;
			PlayerPrefs.SetInt ("highscore", highscore);
		}
	}
}