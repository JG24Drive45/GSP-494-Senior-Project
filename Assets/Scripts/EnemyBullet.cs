﻿using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour 
{	
	private float direction;
	private float speed;
	private Vector3 distance;
	private Transform target;

	void Start () 
	{
		speed = Random.Range( 2.0f, 5.0f );
		direction = Random.Range( 1.0f, 3.0f );
		target = GameObject.Find("Player").transform;
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
}
