﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public delegate void Debris( int debrisValue );
	public static event Debris OnDebrisCollected;

	public delegate void EnemyCollision( float damageVal );
	public static event EnemyCollision OnEnemyCollision;

	public delegate void KeyPress();
	public static event KeyPress OnPlayerShooting;

	public delegate void LevelBeaten( int levelNum );
	public static event LevelBeaten OnLevelBeaten;

	public delegate int GetPoints();
	public static event GetPoints OnGetPointsVal;
	public static event GetPoints OnGetDebrisVal;

	public float hSpeed;
	public float vSpeed;

	public int health	= 100;					// DON"T NEED THESE
	public int shield	= 100;					// DON'T NEED THESE

	public GameObject bullet1;

	void Start () 
	{
		hSpeed = vSpeed = PlayerSettingsScript.GetInstance.shipSpeed;
	}

	void Update () {
		// Update rotation
		transform.rotation = Quaternion.Euler( new Vector3( 0.0f, -Input.GetAxis( "Horizontal" ) * 20.0f, 0.0f ) );
		
		// Update position
		transform.position += new Vector3( Input.GetAxis( "Horizontal" ) * hSpeed * Time.deltaTime,
		                                   Input.GetAxis( "Vertical"   ) * vSpeed * Time.deltaTime, 0.0f );

		// Bounds Checking
		if( transform.position.x < -6.0f )
			transform.position = new Vector3( -6.0f, transform.position.y, 0.0f );
		else if( transform.position.x > 6.0f )
			transform.position = new Vector3( 6.0f, transform.position.y, 0.0f );
		else if( transform.position.y < -4.3f )
			transform.position = new Vector3( transform.position.x, -4.3f, 0.0f );
		else if( transform.position.y > 2.0f )
			transform.position = new Vector3( transform.position.x, 2.0f, 0.0f );

		// Did the player shoot?
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			if( OnPlayerShooting != null )
				OnPlayerShooting();
			Instantiate( bullet1, GameObject.Find( "PlayerMuzzle" ).transform.position, Quaternion.identity );
		}

		// Count down level time
		if( PlayerSettingsScript.GetInstance.levelTime <= 0.0f )
		{
			// Set the current level to beaten
			if( OnLevelBeaten != null )
				OnLevelBeaten( PlayerSettingsScript.GetInstance.levelNum );
			// Add the player points and debris values to the player settings
			if( OnGetPointsVal != null )
				PlayerSettingsScript.GetInstance.totalScore += OnGetPointsVal();
			if( OnGetDebrisVal != null )
				PlayerSettingsScript.GetInstance.totalDebris += OnGetDebrisVal();
			// Increment the current level in player settings
			PlayerSettingsScript.GetInstance.levelNum++;
			// Go back to the main menu
			Application.LoadLevel( "MainMenu" );
		}
		else
		{
			PlayerSettingsScript.GetInstance.levelTime -= Time.deltaTime;
		}
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		switch( other.gameObject.tag )
		{
		case "Enemy":
			Debug.Log( "Collided " + other.gameObject.name );
			Destroy( other.gameObject );

			// Take Damage
			if( OnEnemyCollision != null )
				OnEnemyCollision( 0.5f );

			break;
		case "Debris":
			if( OnDebrisCollected != null )
				OnDebrisCollected( other.gameObject.GetComponent<DebrisScript>().GetDebrisPointValue() );
			Debug.Log( "Debris Collected" );
			Destroy( other.gameObject );
			break;
		}
	}
}
