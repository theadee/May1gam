using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.name == "sword") {
			Destroy (gameObject);
			// TODO Score++
		}

		if (coll.gameObject.name == "player") {
			print ("GAME OVER");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
