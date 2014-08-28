using UnityEngine;
using System.Collections;

public class DebrisScript : MonoBehaviour 
{
	public int pointValue;

	public Vector3 velocity;
	public float rotationSpeed;

	#region void Start()
	void Start () 
	{
		pointValue = Random.Range( 100, 1001 );
		int randX, randY;
		randX = Random.Range( 0, 2 );
		randY = Random.Range( 0, 2 );
		float x, y;
		if( randX == 0 )
			x = -1.0f;
		else
			x = 1.0f;
		if( randY == 0 )
			y = -1.0f;
		else
			y = 1.0f;
		velocity = new Vector3( Random.Range( 0.1f, 0.5f ) * x, Random.Range( 0.1f, 0.5f ) * y, 0.0f );

		rotationSpeed = Random.Range( 50.0f, 100.0f );
	}
	#endregion
	
	#region void Update()
	void Update () 
	{
		transform.position += ( velocity * Time.deltaTime );
		transform.Rotate( Vector3.forward, rotationSpeed * Time.deltaTime );

		// Destroy the debris if it goes off screen
		if( transform.position.x <= -7.0f || transform.position.x >= 7.0f || transform.position.y >= 5.0f || transform.position.y <= -5.0f )
		{
			Debug.Log( "Debris off screen, destroying" );
			Destroy( this.gameObject );
		}
	}
	#endregion

	#region public int GetDebrisPointValue()
	public int GetDebrisPointValue()
	{
		return pointValue;
	}
	#endregion
}
