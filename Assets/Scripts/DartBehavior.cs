using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehavior : MonoBehaviour {

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
		// Shoot the dart
		if (Input.GetMouseButtonDown(0)) {
			rb.AddForce(transform.up * 900);
		}
	}

	void RespawnDart() {

	}

}