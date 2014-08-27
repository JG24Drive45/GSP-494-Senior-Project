using UnityEngine;
using System.Collections;

public class Enemy1AI : MonoBehaviour 
{
	public float speed;					// how fast the ship moves
	public int health;					// health of AI
	public bool moving;					// if the ship is moving
	public Vector3 destination;			// destination of ship
	public Vector3 distance;			// distance to the destination
	public Transform target;			// the target of the AI destination

	public GameObject debris;			// debri game object

	public Camera myCamera;				// main camera
	public int xMin;
	public int xMax;

	void Start () 
	{
		target = GameObject.Find("Player").transform;
		health = 5;
		speed = 5.0f;
		myCamera = Camera.main;
		xMin = 25;
		xMax = Screen.width - 25;
		moving = false;
		SetDestination();
	}

	void Update () 
	{
		Movement ();					// Start the movement of the AI
	}

	void Movement()
	{
		if(!moving)
		{
			distance = destination - transform.position;								// get the distance left till target is reached
			distance.Normalize(); 														// normalize the distance vector to get vector with direction and magnitude
			moving = true;
		}
		if(moving)
		{
			transform.Translate(distance * speed * Time.deltaTime, Space.World);
		}

		if( transform.position.x <= -8.0f || transform.position.x >= 8.0f || transform.position.y >= 6.0f || transform.position.y <= -6.0f )
		{
			RepositionEnemey();
		}

	}

	void SetDestination()
	{
		destination = new Vector3(target.position.x, target.position.y + 1, 0.0f);		// set destination to a little bit past the intended target
	}

	void RepositionEnemey()
	{
		transform.position = new Vector3( myCamera.ScreenToWorldPoint( new Vector3( Random.Range( xMin, xMax ), 0f, 0f ) ).x, 
		                             myCamera.ScreenToWorldPoint( new Vector3 (0f, Screen.height, 0f ) ).y,
		                                 -1.0f);
		moving = false;		// reset moving to false to calculate new destination
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
