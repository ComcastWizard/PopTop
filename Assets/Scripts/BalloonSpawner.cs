using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour {

	public GameObject balloonRed;
	public GameObject balloonBlue;
	public GameObject balloonYellow;
	public GameObject balloonWhite;
	public GameObject balloonGreen;
	public GameObject balloonHome;
	public float spawnY = 2.5f;
	public static bool canSpawn = false;
	public static float timeUntilNextPush = 0.7f;
	public static int scoreForSpeedUp = 0;


	// Use this for initialization
	void Start () {
		balloonHome = GameObject.Find("Balloons");
		StartCoroutine (SpawnCountDown ());
	}
	
	// Update is called once per frame
	void Update () {
		if(canSpawn == true) {
			SpawnBalloon();
		}
		// For conditions where a boolean needs to return true for an instant moment
		// Just keep a false in the code at the end and have outside code set it to true
		canSpawn = false;
		SpeedUp ();
	}
		
	void SpawnBalloon () {
		int balloonType = Random.Range (0, 3);

		switch(balloonType) {
		case 0:
			GameObject redSpawn = Instantiate (balloonBlue, new Vector2 (-2.7f, spawnY), Quaternion.identity);
			redSpawn.transform.parent = balloonHome.transform;
			break;
		case 1:
			GameObject blueSpawn = Instantiate (balloonGreen, new Vector2 (-2.7f, spawnY), Quaternion.identity);
			blueSpawn.transform.parent = balloonHome.transform;
			break;
		case 2:
			GameObject yellowSpawn = Instantiate (balloonRed, new Vector2 (-2.7f, spawnY), Quaternion.identity);
			yellowSpawn.transform.parent = balloonHome.transform;
			break;
		case 3:
			GameObject greenSpawn = Instantiate (balloonYellow, new Vector2 (-2.7f, 2f), Quaternion.identity);
			greenSpawn.transform.parent = balloonHome.transform;
			break;
		case 4:
			Instantiate (balloonGreen, new Vector2 (-2.5f, 1.5f), Quaternion.identity);
			break;
		}
	}

	public IEnumerator SpawnCountDown() {
		yield return new WaitForSeconds(timeUntilNextPush);
		// So the balloons spawn and move for one brief moment
		canSpawn = true;
		StartCoroutine(SpawnCountDown ());
	}

	void SpeedUp() {
		if (scoreForSpeedUp >= 500) {
			if (timeUntilNextPush >= 0.35f) {
				Debug.Log ("dip dip");
				timeUntilNextPush -= 0.05f;
			}
			scoreForSpeedUp = 0;
		}
			
	}
		
}