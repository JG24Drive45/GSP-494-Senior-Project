using UnityEngine;
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

	public delegate void ShotByEnemy( float damage );
	public static event ShotByEnemy OnTakeDamage;

	public float hSpeed;
	public float vSpeed;

	//public int health	= 100;					// DON"T NEED THESE
	//public int shield	= 100;					// DON'T NEED THESE

	public GameObject bullet1;

	public GameObject endMenu;

	private bool bLevelOver = false;

	#region void Start()
	void Start () 
	{
		Time.timeScale = 1.0f;

		hSpeed = vSpeed = PlayerSettingsScript.GetInstance.shipSpeed;
	}
	#endregion

	#region void Update()
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
		if( bLevelOver == false )
		{
			if( PlayerSettingsScript.GetInstance.levelTime <= 0.0f )
			{
				bLevelOver = true;
				// Set the current level to beaten
				if( OnLevelBeaten != null )
					OnLevelBeaten( PlayerSettingsScript.GetInstance.levelNum );
				// Add the player points and debris values to the player settings
				if( OnGetPointsVal != null )
					PlayerSettingsScript.GetInstance.totalScore += OnGetPointsVal();
				if( OnGetDebrisVal != null )
					PlayerSettingsScript.GetInstance.totalDebris += OnGetDebrisVal();
				// Pause the game
				Time.timeScale = 0.0f;			
				// Bring up the end level menu
				Instantiate( endMenu, new Vector3( 0, 0, 0 ), Quaternion.identity );
				// Update scene number
				PlayerSettingsScript.GetInstance.sceneNum = PlayerSettingsScript.GetInstance.levelNum * 2;
				// Increment the current level in player settings
				PlayerSettingsScript.GetInstance.levelNum++;			
			}
			else
			{
				PlayerSettingsScript.GetInstance.levelTime -= Time.deltaTime;
			}
		}
	}
	#endregion

	#region void OnCollisionEnter2D( Collision2D other )
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

		case "EnemyBullet1":
			if( OnTakeDamage != null )
				OnTakeDamage( other.gameObject.GetComponent<EnemyBullet1>().damage / 100.0f );
			Debug.Log( "Took " + other.gameObject.GetComponent<EnemyBullet1>().damage.ToString() + " damage" );
			break;

		case "EnemyBullet2":
			if( OnTakeDamage != null )
				OnTakeDamage( other.gameObject.GetComponent<EnemyBullet2>().damage / 100.0f );
			Debug.Log( "Took " + other.gameObject.GetComponent<EnemyBullet2>().damage.ToString() + " damage" );
			break;

		case "EnemyBullet3":
			if( OnTakeDamage != null )
				OnTakeDamage( other.gameObject.GetComponent<EnemyBullet3>().damage / 100.0f );
			Debug.Log( "Took " + other.gameObject.GetComponent<EnemyBullet3>().damage.ToString() + " damage" );
			break;
		}
	}
	#endregion
}
