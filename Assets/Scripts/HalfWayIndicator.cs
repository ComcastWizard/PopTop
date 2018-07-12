using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfWayIndicator : MonoBehaviour {

	// Checks when the balloon reached the halfway point
	void OnTriggerEnter2D(Collider2D col) { 
		// Get the script of collider
		if (col.gameObject.tag != "Dart") {
			col.gameObject.GetComponent<BalloonBehavior>().passedHalfWay = true;	
		}
	}
}