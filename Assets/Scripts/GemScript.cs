﻿using UnityEngine;
using System.Collections;

public class GemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.name == "player") {
			Destroy (gameObject);
			// TODO Score++
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
