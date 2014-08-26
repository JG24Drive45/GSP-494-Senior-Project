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
		StartCoroutine("SpawnEnemies");
	}

	void Update ()
	{
		if(_PlayerScript.health <= 0)   // If the player has died stop spawners
		{
			spawnEnemies = false;
			enemyToSpawn = -1;
		}
	}

	public IEnumerator SpawnEnemies()
	{
		while(spawnEnemies)
		{
			//enemyToSpawn = Random.Range(0,6);		// Select which enemy to create
			enemyToSpawn = 2;						// Uncomment to test a specific enemy

			switch(enemyToSpawn)
			{
			case 5:
				GameObject enemyObject1 = ( GameObject )Instantiate( Enemy5, new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range( xMin, xMax ), 0f, 0f ) ).x, 
				                                                                       myCamera.ScreenToWorldPoint( new Vector3 (0f, Screen.height, 0f ) ).y,
				                                                                       0.0f ), Quaternion.identity );
				break;
			case 4:
				GameObject enemyObject2 = ( GameObject )Instantiate( Enemy4, new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range( xMin, xMax ), 0f, 0f ) ).x, 
				                                                                       myCamera.ScreenToWorldPoint( new Vector3 (0f, Screen.height, 0f ) ).y,
				                                                                       0.0f ), Quaternion.identity );
				break;
			case 3:
				GameObject enemyObject3 = ( GameObject )Instantiate( Enemy3, new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range( xMin, xMax ), 0f, 0f ) ).x, 
				                                                                       myCamera.ScreenToWorldPoint( new Vector3 (0f, Screen.height, 0f ) ).y,
				                                                                       0.0f ), Quaternion.identity );
				break;
			case 2:
				GameObject enemyObject4 = ( GameObject )Instantiate( Enemy2, new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range( xMin, xMax ), 0f, 0f ) ).x, 
				                                                                       myCamera.ScreenToWorldPoint( new Vector3 (0f, Screen.height, 0f ) ).y,
				                                                                       0.0f ), Quaternion.identity );
				break;
			case 1:
				GameObject enemyObject5 = ( GameObject )Instantiate( Enemy1, new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range( xMin, xMax ), 0f, 0f ) ).x, 
				                                                                       myCamera.ScreenToWorldPoint( new Vector3 (0f, Screen.height, 0f ) ).y,
				                                                                       0.0f ), Quaternion.identity );
				break;
			default:
				break;
			}
			yield return new WaitForSeconds(1.5f);
		}
	}
}
