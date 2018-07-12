using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void LoadLevel(int levelName) {
		// To reset the time each game
		BalloonSpawner.timeUntilNextPush = 0.9f;
		Application.LoadLevel (levelName);
	}
}