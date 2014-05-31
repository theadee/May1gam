using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	Transform _groundCheckLeft, _groundCheckRight;
	bool isFalling = true;
	bool isFaceLeft = true;
	GameObject sword;

	bool _isSwung = false;
	float _swordTick;


	void Awake () {
		_groundCheckLeft = transform.FindChild ("leftRay");
		_groundCheckRight = transform.FindChild ("rightRay");

	}

	void Start () {
		
			sword = GameObject.Find ("sword");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		isFalling = false;
	}

	void FixedUpdate() {


		float movementX = transform.position.x;


		float movementY = transform.position.y;
		if (isFalling) {
			movementY -= 0.15f;
		} else {

			// move left or right
			float direction = Input.GetAxisRaw ("Horizontal");
			if(!_isSwung){
				movementX = transform.position.x + (direction * 0.15f);
			}

			if (direction == -1) {
				isFaceLeft = true;
				transform.localScale = new Vector2(1, transform.localScale.y);
			} else if (direction == 1) {
				isFaceLeft = false;
				transform.localScale = new Vector2(-1, transform.localScale.y);
			}



			bool _isEmptySpace = Physics2D.Linecast(transform.position, _groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground")) || 
				Physics2D.Linecast(transform.position, _groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"));

			if (!_isEmptySpace) {
				isFalling = true;
			}
		}

		transform.position = new Vector2 (movementX, movementY);


		// get sword
		if (Input.GetKeyDown (KeyCode.Space) && !_isSwung) {
			_isSwung = true;
			_swordTick = (Time.time * 1000) + 50;
			if(isFaceLeft){
				sword.transform.position = new Vector3(transform.position.x - 1, transform.position.y, -10);
			} else {
				sword.transform.position = new Vector3(transform.position.x + 1, transform.position.y, -10);
			}
		}


		if (_isSwung) {
			if (_swordTick < Time.time * 1000) {
				_isSwung = false;
			}
		} else {
			sword.transform.position = new Vector3(-100, -100, -10);
		}
	}
}
