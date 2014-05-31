using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	int nextplatform = 5;
	int wallplatform = 11;
	
	private GameObject _platformPrefab, _platform;
	private GameObject _wallPrefab, _wall;
	private GameObject _enemyPrefab, _enemy;
	private GameObject _gemPrefab, _gem;


	void Awake () {
		_platformPrefab = Resources.Load("platform") as GameObject;
		_enemyPrefab = Resources.Load("enemy") as GameObject;
		_gemPrefab = Resources.Load("gem") as GameObject;
		_wallPrefab = Resources.Load("wall") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y -  (3.5f * Time.deltaTime), -10);

		// wall
		if(transform.position.y < wallplatform){
			wallplatform--;
			_wall = GameObject.Instantiate(_wallPrefab, new Vector2(-6, wallplatform - 11), Quaternion.Euler(Vector2.zero)) as GameObject;
			_wall = GameObject.Instantiate(_wallPrefab, new Vector2(6, wallplatform - 11), Quaternion.Euler(Vector2.zero)) as GameObject;
		}

		// platform
		if(transform.position.y < nextplatform){
			nextplatform -= 3;


			int rand1 = 0;
			int rand2 = 16;
			if(Random.Range(1,10) > 4){
				rand1 = Random.Range(1,11);
				rand2 = Random.Range(1,11);
			} else {
				rand1 = Random.Range(1,11);
			}

			// enemy or gem;
			int engem = Random.Range(1,50);
			int engemrand = Random.Range(1,11);
			while(engemrand == rand1 || engemrand == rand2){
				engemrand = Random.Range(1,11);
			}

			bool hasEnemy = false;
			bool hasGem = false;
			if(engem < 10){
				hasEnemy = true;
			} else if(engem > 10 && engem < 20) {
				hasGem = true;
			}

			for(int i=1; i<12; i++){
				if(i != rand1 && i != rand2){
					_platform = GameObject.Instantiate(_platformPrefab, new Vector2(transform.position.x + (-6 + i), nextplatform - 10), Quaternion.Euler(Vector2.zero)) as GameObject;

					if(i == engemrand){
						if(hasEnemy){
							_enemy = GameObject.Instantiate(_enemyPrefab, new Vector2(transform.position.x + (-6 + i), nextplatform - 12), Quaternion.Euler(Vector2.zero)) as GameObject;
						}
						if(hasGem){
							_gem = GameObject.Instantiate(_gemPrefab, new Vector2(transform.position.x + (-6 + i), nextplatform - 12), Quaternion.Euler(Vector2.zero)) as GameObject;
						}
					}
				}
			}
		}
	}
}
