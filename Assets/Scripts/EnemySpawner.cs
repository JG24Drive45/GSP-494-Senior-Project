using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
	public int xMin;
	public int xMax;
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	public GameObject Enemy5;

	public int enemyToSpawn;
	public bool spawnEnemies;

	public PlayerScript _PlayerScript;
	public Camera myCamera;

	void Start () 
	{
		_PlayerScript = GameObject.Find("Player").GetComponent<PlayerScript>();		// Get the player script to check the health of player
		spawnEnemies = true;
		enemyToSpawn = 0;
		xMin = 25;
		xMax = Screen.width;
		SpawnEnemies();
	}

	void Update ()
	{
		if(_PlayerScript.health <= 0)   // If the player has died stop spawners
		{
			spawnEnemies = false;
			enemyToSpawn = -1;
		}
	}

	public void SpawnEnemies()
	{
		while(spawnEnemies)
		{
			enemyToSpawn = Random.Range(0,6);		// Select which enemy to create

			switch(enemyToSpawn)
			{
			case 5:
				CreateEnemy(Enemy5);
				break;
			case 4:
				CreateEnemy(Enemy4);
				break;
			case 3:
				CreateEnemy(Enemy3);
				break;
			case 2:
				CreateEnemy(Enemy2);
				break;
			case 1:
				CreateEnemy(Enemy1);
				break;
			default:
				break;
			}
			StartCoroutine("CreateEnemy");
		}
	}

	public IEnumerator CreateEnemy(GameObject enemy)
	{
		Debug.Log("Enemy Created");
		GameObject enemyObject = ( GameObject )Instantiate( enemy, new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range( xMin, xMax ), 0f, 0f ) ).x, 
		                                                                             myCamera.ScreenToWorldPoint( new Vector3 (0f, Screen.height, 0f ) ).y,
		                                                                             -1.0f ), Quaternion.identity );
		yield return new WaitForSeconds(1.5f);
	}

}
