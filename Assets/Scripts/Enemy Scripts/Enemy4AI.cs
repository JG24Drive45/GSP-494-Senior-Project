﻿using UnityEngine;
using System.Collections;

public class Enemy4AI : MonoBehaviour {

	public delegate void EnemyFire();
	public static event EnemyFire OnEnemyFire;
	
	public int health;					// health of AI
	
	public int xMin;					// minimum width boundary
	public int xMax;					// maximum width boundary
	public float yMin;					// minimum height boundary
	public float yMax;					// maximum height boundary
	
	public float speed;					// how fast the ship moves
	
	public bool moving;					// if the ship is moving
	public bool inPosition;				// if the ship is in position to start moving
	
	public Vector3 destination;			// destination of ship
	public Vector3 distance;			// distance to the destination
	public Vector3 startPosition;		// the starting position of the ship
	public Transform target;			// the target of the AI destination
	public int pointValue;
	
	public GameObject debris;			// debri game object
	public GameObject bullet;			// enemy bullet game object
	
	public Camera myCamera;				// main camera
	
	void Start () 
	{
		pointValue = 400;
		target = GameObject.Find("Player").transform;
		health = 5;
		speed = 2.5f;
		myCamera = Camera.main;
		
		xMin = 25;
		xMax = Screen.width - 25;
		yMin = Screen.height * .80f;
		yMax = Screen.height * .90f;
		
		SetStartPosition();
		StartCoroutine( "Attack" );
		StartCoroutine( "Movement" );
	}
	
	void Update () 
	{
		Movement();			// start the Movement function
	}
	
	#region AI Movement
	IEnumerator Movement()
	{
		while( health > 0 )
		{
			yield return new WaitForSeconds( Random.Range( 2.0f, 3.0f ) );
			transform.position = new Vector3( Random.Range( xMin, xMax ), Random.Range( yMin, yMax ), 0.0f );
		}

	}
	// Sets the start position of the AI
	void SetStartPosition()
	{
		startPosition = new Vector3( myCamera.ScreenToWorldPoint( new Vector3( xMin, 0f, 0f ) ).x, 
		                            myCamera.ScreenToWorldPoint( new Vector3 (0f, Random.Range(yMin, yMax), 0f ) ).y,
		                            0.0f);
		transform.position = startPosition;
		moving = true;
	}	
	#endregion
	
	#region Attack()
	IEnumerator Attack()
	{
		while( health > 0 )
		{
			yield return new WaitForSeconds( Random.Range( 1.0f, 1.75f ) );
			GameObject bulletObject = ( GameObject )Instantiate( bullet, transform.position, Quaternion.identity );
			if( OnEnemyFire != null )
				OnEnemyFire();
		}
	}
	#endregion
	
	#region DMG and Collision
	void TakeDamage()
	{
		health -= PlayerSettingsScript.GetInstance.weaponStrength;			// get the weapon dmg and subtract from health
		
		if( health >= 0 )
		{
			Death();
		}
	}
	
	void Death()
	{
		GameObject.Find( "HUD" ).GetComponent<HUDScript>().UpdateScore( pointValue );
		GameObject debrisObject = ( GameObject )Instantiate( debris, transform.position, Quaternion.identity );
		Destroy( gameObject );
	}
	
	void OnCollisionEnter2D( Collision2D other )
	{
		switch( other.gameObject.tag )
		{
		case "PlayerBullet":
			Destroy( other.gameObject );
			TakeDamage();
			break;
		}
	}
	#endregion

}
