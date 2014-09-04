using UnityEngine;
using System.Collections;

public class BottomMenuScript : MonoBehaviour 
{
	private Vector3 originalPos;
	private Vector3 desiredPos;	
	private Vector3 moveDirection;
	
	private float moveSpeed;

	#region void Awake()
	void Awake()
	{
		originalPos = transform.position;
		desiredPos = new Vector3( 2.5f, -1.0f, 0.0f );
		
		moveDirection = ( desiredPos - originalPos );
		moveDirection.Normalize();
		
		moveSpeed = 20.0f;
	}
	#endregion

	#region public IEnumerator MoveMenuOnScreen()
	public IEnumerator MoveMenuOnScreen()
	{
		while( transform.position.x > desiredPos.x )
		{
			transform.position += ( moveSpeed * moveDirection * Time.deltaTime );
			yield return null;
		}
		transform.position = desiredPos;
	}
	#endregion

	#region IEnumerator MoveMenuOffScreen()
	public IEnumerator MoveMenuOffScreen()
	{
		while( transform.position.x < originalPos.x )
		{
			transform.position += ( moveSpeed * moveDirection * Time.deltaTime * -1.0f );
			yield return null;
		}
		transform.position = originalPos;
	}
	#endregion
}
