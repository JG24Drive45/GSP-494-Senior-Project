using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public delegate void Destroyed( int points );
	public static event Destroyed OnEnemyDestroyed;

	public delegate void Debris( int debrisValue );
	public static event Debris OnDebrisCollected;

	public float hSpeed = 5.0f;
	public float vSpeed = 3.0f;

	public int health	= 100;
	public int shield	= 100;

	public GameObject bullet1;

	void Start () 
	{
		
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
		if( transform.position.x > 6.0f )
			transform.position = new Vector3( 6.0f, transform.position.y, 0.0f );
		if( transform.position.y < -4.3f )
			transform.position = new Vector3( transform.position.x, -4.3f, 0.0f );
		if( transform.position.y > 2.0f )
			transform.position = new Vector3( transform.position.x, 2.0f, 0.0f );

		// Did the player shoot?
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			Instantiate( bullet1, GameObject.Find( "PlayerMuzzle" ).transform.position, Quaternion.identity );
		}
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		switch( other.gameObject.tag )
		{
		case "Enemy":
			if( OnEnemyDestroyed != null )
				OnEnemyDestroyed( 50 );
			Debug.Log( "Destroyed " + other.gameObject.name );
			Destroy( other.gameObject );
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
