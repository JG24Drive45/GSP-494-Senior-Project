﻿using UnityEngine;
using System.Collections;

public class Enemy3AI : MonoBehaviour 
{

	public int health;					// health of AI
	
	public int xMin;					// minimum width boundary
	public int xMax;					// maximum width boundary
	public float yMin;					// minimum height boundary
	public float yMax;					// maximum height boundary
	
	public float speed;					// how fast the ship moves
	
	public bool moving;					// if the ship is moving
	public bool inPosition;				// if the ship is in position to start moving
	public bool moveUp;					// move ship up
	public bool moveDown;				// move ship down
	
	public Vector3 destination;			// destination of ship
	public Vector3 distance;			// distance to the destination
	public Vector3 startPosition;		// the starting position of the ship
	public Transform target;			// the target of the AI destination
	
	public GameObject debris;			// debri game object
	
	public Camera myCamera;				// main camera
	
	void Start () 
	{
		target = GameObject.Find("Player").transform;
		health = 5;
		speed = 2.5f;
		myCamera = Camera.main;
		
		xMin = 25;
		xMax = Screen.width - 25;
		yMin = Screen.height * .20f;
		yMax = Screen.height - 75;
		
		moveUp = false;
		moveDown = true;
		
		SetStartPosition();
	}
	
	void Update () 
	{
		Movement();			// start the Movement function
	}

	void Movement()
	{
		if(moving)
		{
			if(moveUp)
			{
				
				transform.position += Vector3.up * Time.deltaTime * speed;				// move AI ship to the left
				if(myCamera.WorldToScreenPoint(transform.position).y >= yMax)				// If AI ship reaches left most side of screen reverse direction
				{
					moveUp = false;
					moveDown = true;
				}
			}
			if(moveDown)
			{
				transform.position += Vector3.down * Time.deltaTime * speed;				// move AI ship to the right
				if(myCamera.WorldToScreenPoint(transform.position).y <= yMin)				// If AI ship reaches right most side of screen reverse directions
				{
					moveUp = true;
					moveDown = false;
				}
			}
		}
	}
	
	void SetStartPosition()
	{
		startPosition = new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range(xMin, xMax), 0f, 0f ) ).x, 
		                            myCamera.ScreenToWorldPoint( new Vector3 (0f, yMax, 0f ) ).y,
		                            -1.0f);
		transform.position = startPosition;
		moving = true;
	}
	
	void Death()
	{
		GameObject debrisObject = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "PlayerBullet")
		{
			Death ();
		}
	}
}
