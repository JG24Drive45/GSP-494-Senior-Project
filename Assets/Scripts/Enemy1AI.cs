using UnityEngine;
using System.Collections;

public class Enemy1AI : MonoBehaviour 
{
	public float speed;					// how fast the ship moves
	public int health;					// health of AI
	public Vector3 destination;			// destination of ship
	public Vector3 distance;			// distance to the destination

	public Camera myCamera;				// main camera
	void Start () 
	{
		speed = 1.5f;
	}

	void Update () 
	{
		Movement ();					// Start the movement of the AI
	}

	void Movement()
	{

	}

}
