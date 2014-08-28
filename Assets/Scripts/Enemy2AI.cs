using UnityEngine;
using System.Collections;

public class Enemy2AI : MonoBehaviour 
{	
	public int health;					// health of AI

	public int xMin;					// minimum width boundary
	public int xMax;					// maximum width boundary
	public float yMin;					// minimum height boundary
	public float yMax;					// maximum height boundary

	public float speed;					// how fast the ship moves

	public bool moving;					// if the ship is moving
	public bool inPosition;				// if the ship is in position to start moving
	public bool moveRight;				// move ship right
	public bool moveLeft;				// move ship left

	public Vector3 destination;			// destination of ship
	public Vector3 distance;			// distance to the destination
	public Vector3 startPosition;		// the starting position of the ship
	public Transform target;			// the target of the AI destination

	public GameObject debris;			// debri game object
	public GameObject bullet;			// enemy bullet game object
	
	public Camera myCamera;				// main camera

	void Start () 
	{
		target = GameObject.Find("Player").transform;
		health = 5;
		speed = 2.5f;
		myCamera = Camera.main;

		xMin = 25;
		xMax = Screen.width - 25;
		yMin = Screen.height * .80f;
		yMax = Screen.height * .90f;

		moveLeft = false;
		moveRight = true;

		SetStartPosition();
		StartCoroutine( "Attack" );
	}

	void Update () 
	{
		Movement();			// start the Movement function
	}

	#region AI Movement
	void Movement()
	{
		if(moving)
		{
			if(moveLeft)
			{

				transform.position += Vector3.left * Time.deltaTime * speed;				// move AI ship to the left
				if(myCamera.WorldToScreenPoint(transform.position).x <= xMin)				// If AI ship reaches left most side of screen reverse direction
				{
					moveLeft = false;
					moveRight = true;
				}
			}
			if(moveRight)
			{
				transform.position += Vector3.right * Time.deltaTime * speed;				// move AI ship to the right
				if(myCamera.WorldToScreenPoint(transform.position).x >= xMax)				// If AI ship reaches right most side of screen reverse directions
				{
					moveLeft = true;
					moveRight = false;
				}
			}
		}
	}
	// Sets the start position of the AI
	void SetStartPosition()
	{
		startPosition = new Vector3( myCamera.ScreenToWorldPoint( new Vector3( xMin, 0f, 0f ) ).x, 
		                                      myCamera.ScreenToWorldPoint( new Vector3 (0f, Random.Range(yMin, yMax), 0f ) ).y,
		                                      -1.0f);
		transform.position = startPosition;
		moving = true;
	}	
	#endregion

	#region Attack()
	IEnumerator Attack()
	{
		while( health > 0 )
		{
			yield return new WaitForSeconds( Random.Range( 1.0f, 1.75f ) );
			GameObject bulletObject = ( GameObject )Instantiate( bullet, transform.position, Quaternion.identity );
		}
	}
	#endregion

	#region DMG and Collision
	void TakeDamage()
	{
		health -= PlayerSettingsScript.GetInstance.weaponStrength;			// get the weapon dmg and subtract from health
		
		if( health >= 0 )
		{
			Death();
		}
	}
	
	void Death()
	{
		GameObject debrisObject = ( GameObject )Instantiate( debris, transform.position, Quaternion.identity );
		Destroy( gameObject );
	}
	
	void OnTriggerEnter2D( Collider2D other )
	{
		switch( other.gameObject.tag )
		{
		case "PlayerBullet":
			TakeDamage();
			break;
		}
	}
	#endregion
}
