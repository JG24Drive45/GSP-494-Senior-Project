using UnityEngine;
using System.Collections;

public class MenuEnemyScript : MonoBehaviour 
{
	public float speed = 0.05f;
	public float dir;

	void Start()
	{
		switch( gameObject.name )
		{
		case "MenuEnemy1":
			SetRandomX();
			break;
		case "MenuEnemy2":
			SetRandomX();
			break;
		case "MenuEnemy3":
			SetRandomX();
			break;
		}
	}

	void Update()
	{
		switch( gameObject.name )
		{
		case "MenuEnemy1":
			transform.position += new Vector3( 0.0f, -speed, 0.0f );
			if( transform.position.y <= -5.5f )
				SetRandomX();
			break;
		case "MenuEnemy2":
			transform.position += new Vector3( dir, -speed, 0.0f );
			if( transform.position.y <= -5.5f || transform.position.x <= -5.5f || transform.position.x >= 5.5f )
				SetRandomX();
			break;
		case "MenuEnemy3":
			transform.position += new Vector3( dir, -speed, 0.0f );
			if( transform.position.x <= -5.5f || transform.position.x >= 5.5f )
				dir *= -1;
			if( transform.position.y <= -5.5f )
				SetRandomX();
			break;
		}
	}

	void SetRandomX()
	{
		float x = Random.Range( -5.5f, 5.5f );

		switch( gameObject.name )
		{
		case "MenuEnemy1":
			transform.position = new Vector3 ( x, 5.5f, 0.0f );
			break;
		case "MenuEnemy2":
			dir = Random.Range( 0, 2 );
			if( dir == 0 )
				dir = -0.03f;
			else
				dir = 0.03f;
			transform.position = new Vector3( x, 5.5f, 0.0f );
			break;
		case "MenuEnemy3":
			transform.position = new Vector3( x, 5.5f, 0.0f );
			dir = Random.Range( 0, 2);
			if( dir == 0 )
				dir = 0.05f;
			else
				dir = -0.05f;
			speed = 0.03f;
			break;
		}
	}
}