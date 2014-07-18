using UnityEngine;
using System.Collections;

public class DeleteThisLater : MonoBehaviour 
{
	public float hSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Update rotation
		transform.rotation = Quaternion.Euler( new Vector3( 0.0f, -Input.GetAxis( "Horizontal" ) * 20.0f, 180.0f ) );

		// Update position
		transform.position += new Vector3( Input.GetAxis( "Horizontal" ) * hSpeed * Time.deltaTime, 0.0f, 0.0f );
	}
}