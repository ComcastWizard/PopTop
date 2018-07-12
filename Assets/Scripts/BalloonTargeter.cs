using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonTargeter : MonoBehaviour {

	public AudioClip[] audioClips;
	public AudioSource audioSource;
	public AudioClip playingClip;
	public GameObject balloonHome;
	public static string targetBalloon;
	public static string previousBalloon = "a";
	public Sprite[] balloonImages;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		balloonHome = GameObject.Find ("Balloons");
		balloonImages = Resources.LoadAll<Sprite> ("Balloons");
		StartCoroutine (ChooseTargetBalloon ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Change target ballon for random increments of time 
	public IEnumerator ChooseTargetBalloon() {
		//int targetDuration = Random.Range (10, 21);
		int targetNum = Random.Range(0,3);

		switch (targetNum) {
		case 0: 
			targetBalloon = "blue";

			audioSource.volume = 0.3f;
			audioSource.clip = audioClips [0];
			audioSource.Play();

			// Destroy all instances of targetBalloon past the halfway point
			foreach(Transform child in balloonHome.transform) {
				if(child.gameObject.GetComponent<BalloonBehavior>().passedHalfWay == true && child.gameObject.GetComponent<BalloonBehavior>().balloonType == targetBalloon) {
					Destroy(child.gameObject);
				}
			}
			GameObject.Find ("TargetBalloonPanel").GetComponent<Image>().sprite = balloonImages [0];
			// play sound to indicate change
			break;
		case 1:
			targetBalloon = "green";

			audioSource.volume = 0.3f;
			audioSource.clip = audioClips [1];
			audioSource.Play();

			foreach(Transform child in balloonHome.transform) {
				if(child.gameObject.GetComponent<BalloonBehavior>().passedHalfWay == true && child.gameObject.GetComponent<BalloonBehavior>().balloonType == targetBalloon) {
					Destroy(child.gameObject);
				}
			}
			GameObject.Find ("TargetBalloonPanel").GetComponent<Image>().sprite = balloonImages [1];
			break;
		case 2:
			targetBalloon = "red";

			audioSource.volume = 0.3f;
			audioSource.clip = audioClips [2];
			audioSource.Play();

			foreach(Transform child in balloonHome.transform) {
				if(child.gameObject.GetComponent<BalloonBehavior>().passedHalfWay == true && child.gameObject.GetComponent<BalloonBehavior>().balloonType == targetBalloon) {
					Destroy(child.gameObject);
				}
			}
			GameObject.Find ("TargetBalloonPanel").GetComponent<Image>().sprite = balloonImages [2];
			break;
		case 3:
			targetBalloon = "yellow";
			foreach(Transform child in balloonHome.transform) {
				if(child.gameObject.GetComponent<BalloonBehavior>().passedHalfWay == true && child.gameObject.GetComponent<BalloonBehavior>().balloonType == targetBalloon) {
					Destroy(child.gameObject);
				}
			}
			GameObject.Find ("TargetBalloonPanel").GetComponent<Image>().sprite = balloonImages [3];
			break;
		case 4:
			previousBalloon = targetBalloon;
			foreach(Transform child in balloonHome.transform) {
				if(child.gameObject.GetComponent<BalloonBehavior>().passedHalfWay == true && child.gameObject.GetComponent<BalloonBehavior>().balloonType == targetBalloon) {
					Destroy(child.gameObject);
				}
			}
			targetBalloon = "yellow";
			GameObject.Find ("TargetBalloonPanel").GetComponent<Image>().sprite = balloonImages [4];
			break;
		}

		yield return new WaitForSeconds (15);
		StartCoroutine (ChooseTargetBalloon());
	}
}