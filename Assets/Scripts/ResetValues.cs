using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValues : MonoBehaviour {

	public void ResetAll() {
		PointTracker.life = 1;
		PointTracker.score = 0;
		BalloonTargeter.previousBalloon = "a";
	}
}
