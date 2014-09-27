using UnityEngine;
using System.Collections;

public class ScrollingBackgroundScript : MonoBehaviour 
{
	public float scrollSpeed = 0.001f;
	public float moveTotal = 0.0f;

	private Vector3 originalPos;

	void Start()
	{
		originalPos = transform.position;
	}

	void Update()
	{
		transform.position += new Vector3( 0.0f, scrollSpeed, 0.0f );
		moveTotal += scrollSpeed;
		if( moveTotal >= 15.0f )
		{
			moveTotal = 0.0f;
			transform.position = originalPos;
		}
	}
}
