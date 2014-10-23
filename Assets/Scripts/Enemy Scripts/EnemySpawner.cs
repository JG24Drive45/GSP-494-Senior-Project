using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
	public int xMin;
	public int xMax;

	public int eMin;		// min enemies purpose used for deciding which enemies to spawn
	public int eMax;		// max enemies purpose used for deciding which enemies to spawn

	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	public GameObject Enemy5;

	public int enemyToSpawn;
	public bool spawnEnemies;

	public HUDScript _HUDScript;
	public PlayerSettingsScript _PlayerSettingsScript;
	public Camera myCamera;

	void Start () 
	{
		_HUDScript = GameObject.Find( "HUD" ).GetComponent< HUDScript >();		// Get the player script to check the health of player
		_PlayerSettingsScript = GameObject.Find( "PlayerSettings" ).GetComponent< PlayerSettingsScript >();
		spawnEnemies = true;
		xMin = 25;
		xMax = Screen.width;
		GetEnemiesToSpawn();
		StartCoroutine( "SpawnEnemies" );
	}

	void Update ()
	{
		if( _HUDScript.health <= 0 )   // If the player has died stop spawners
		{
			spawnEnemies = false;
			enemyToSpawn = -1;
		}
	}

	private void GetEnemiesToSpawn()
	{
		int currentLevel = _PlayerSettingsScript.levelNum;
		eMin = 1;

		switch( currentLevel )
		{
		case 1:
			eMax = 1;
			break;

		case 2:
			eMax = 2;
			break;

		case 3:
			eMax = 3;
			break;

		case 4:
			eMax = 4;
			break;

		default:
			break;
		}
	}

	public IEnumerator SpawnEnemies()
	{
		while( spawnEnemies )
		{
			enemyToSpawn = Random.Range( eMin, eMax);		// Select which enemy to create
			//enemyToSpawn = 2;						// Uncomment to test a specific enemy

			switch( enemyToSpawn )
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
			yield return new WaitForSeconds( 1.5f );
		}
	}
}
