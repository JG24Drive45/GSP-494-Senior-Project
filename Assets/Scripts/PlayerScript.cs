using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public float hSpeed = 5.0f;
	public float vSpeed = 3.0f;

	void Start () {
		
	}

	void Update () {
		// Update rotation
		transform.rotation = Quaternion.Euler( new Vector3( 0.0f, -Input.GetAxis( "Horizontal" ) * 20.0f, 0.0f ) );
		
		// Update position
		transform.position += new Vector3( Input.GetAxis( "Horizontal" ) * hSpeed * Time.deltaTime,
		                                   Input.GetAxis( "Vertical"   ) * vSpeed * Time.deltaTime, 0.0f );
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		if( other.gameObject.tag == "Enemy" )
		{
			Debug.Log( "Destroyed " + other.gameObject.name );
			Destroy( other.gameObject );
		}
	}
}
