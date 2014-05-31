using UnityEngine;
using System.Collections;

public class DiePlatformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.y + 9 < transform.position.y) {
			Destroy(gameObject);
		}
	}
}
