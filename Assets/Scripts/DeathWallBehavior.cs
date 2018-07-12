using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallBehavior : MonoBehaviour {

	public GameObject dart;
	public AudioSource audioSource;
	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Dart") {
			// Spawn the new dart from the deathwall when it reaches the end
			Destroy(col.gameObject);
			PointTracker.life -= 0.05f;
			Instantiate (dart, new Vector2 (0, -4), Quaternion.identity);
		} else if (col.gameObject.tag == BalloonTargeter.targetBalloon){
			// Play damage sound
			audioSource.volume = 0.3f;
			audioSource.Play();
			PointTracker.life -= 0.2f;
			Destroy(col.gameObject);
		} else {
			Destroy(col.gameObject);
		}
	}
}