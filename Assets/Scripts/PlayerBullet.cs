using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
	protected Vector3 	velocity;
	protected float		speed;
	protected int		damage;

	// Use this for initialization
	public virtual void Start () 
	{
	
	}

	public virtual void Update () 
	{
		transform.position += ( velocity * speed * Time.deltaTime );
		
		// Destroy the bullet if it is off screen
		if( transform.position.y >= 5.0f )
		{
			Destroy( this.gameObject );
			Debug.Log( "Bullet Destroyed" );
		}
	}

	public virtual void OnCollisionEnter2D( Collision2D other )
	{
		switch( other.gameObject.tag )
		{
		case "Enemy":
			Destroy( this.gameObject );
			Debug.Log( "Shot Enemy" );
			// TODO: Deal hit points to enemy
			break;
		}
	}
}
