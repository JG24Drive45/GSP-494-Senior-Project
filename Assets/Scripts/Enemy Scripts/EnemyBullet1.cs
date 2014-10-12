﻿using UnityEngine;
using System.Collections;

public class EnemyBullet1 : MonoBehaviour 
{	
	private float direction;
	private float speed;
	private Vector3 distance;
	private Transform target;

	public int damage;

	void Start () 
	{
		speed = Random.Range( 2.0f, 5.0f );
		direction = Random.Range( 1.0f, 3.0f );
		target = GameObject.Find("Player").transform;
		damage = 1;
		transform.rotation = Quaternion.Euler(0, 0, -90);
		SetDestination();
	}

	void Update () 
	{
		Movement();
	}	

	#region Movement
	void Movement()
	{
		if( direction > 1.5f )
		{
			transform.position += Vector3.down * Time.deltaTime * speed;
		}
		else
		{
			transform.Translate(distance * speed * Time.deltaTime, Space.World);
		}
		if( transform.position.x >= 7.0f || transform.position.x <= -5.0f || transform.position.y >= 4.0f || transform.position.y <= -5.0f)
		{
			Destroy( gameObject );
		}
	}

	void SetDestination()
	{
		distance = target.position - transform.position;
		distance.Normalize();
	}
	#endregion

	#region DMG and Collision
	void OnBecameInvisible()
	{
		Destroy( gameObject );
	}
	#endregion

	#region void OnCollisionEnter2D( Collision2D other )
	void OnCollisionEnter2D( Collision2D other )
	{
		switch( other.gameObject.name )
		{
		case "Player":
			Destroy( this.gameObject );
			break;
		}
	}
	#endregion
}
