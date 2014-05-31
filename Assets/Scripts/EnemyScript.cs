using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int rand = Random.Range (1, 10);
		if (rand < 5) {
			transform.localScale = new Vector2(-1, transform.localScale.y);
		} else {
			transform.localScale = new Vector2(1, transform.localScale.y);
		}
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
