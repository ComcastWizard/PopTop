using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehavior : MonoBehaviour {

	public static bool spawnNext = false;
	public Sprite[] poppedBallons;
	public AudioClip[] audioClips;
	public AudioSource audioSource;
	public AudioClip playingClip;
	public bool passedHalfWay;
	public bool canMove = false;
	// Used to recognize balloon types
	public string balloonType;
	public GameObject dart;

	private Vector3 increment = new Vector3(0.9f,0,0);

	private bool hasPassed = false;

	// Use this for initialization
	void Start () {
		
		audioSource = GetComponent<AudioSource> ();
		StartCoroutine (CountDown ());
	}

	
	// Update is called once per frame
	void Update () {
		// So it can only move for a brief moment where canMove is set to true
		if (canMove == true) {
			this.transform.position += increment;
		}
		canMove = false;
	}

	void CheckToSpawnNextBalloon() {
		if(this.transform.position.x >= -1.1f && hasPassed == false) {
			// Signals the BalloonSpawner to spawn the next ball
			spawnNext = true;
			// So this balloon won't keep sending signals
			hasPassed = true;
		}
	}

	public IEnumerator CountDown() {
		// After a set amount of time, send signals to the spawner
		yield return new WaitForSeconds(BalloonSpawner.timeUntilNextPush);
		// So the balloons spawn and move for one brief moment
		canMove = true;
		StartCoroutine (CountDown ());
	}

	public IEnumerator PopBalloon() {
		
		// For displayhhing the popped balloon image and sound
		this.GetComponent<SpriteRenderer>().sprite = poppedBallons[0];
		yield return new WaitForSeconds(0.15f);
		Destroy(this.gameObject);
	}

	void PlaySound() {
		audioSource.volume = 1;
		int clipNum = Random.Range (0, 3);
		playingClip = audioClips [clipNum];
		audioSource.clip = playingClip;
		audioSource.Play ();
	}

	void PlayDamageSound() {
		audioSource.volume = 0.4f;
		playingClip = audioClips [3];
		audioSource.clip = playingClip;
		audioSource.Play ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Dart") {
			if (balloonType == BalloonTargeter.targetBalloon) {
				PointTracker.score += 100;
				BalloonSpawner.scoreForSpeedUp += 100;
				PlaySound();
			} else {
				PointTracker.life -= 0.1f;
				PlayDamageSound ();
			}
			Destroy(col.gameObject);
			Instantiate (dart, new Vector2 (0, -4), Quaternion.identity);
			StartCoroutine (PopBalloon ());
		}
	}
		
}