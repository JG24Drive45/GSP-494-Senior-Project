using UnityEngine;
using System.Collections;

public class TopMenuScript : MonoBehaviour 
{
	private Vector3 originalPos;
	private Vector3 inactivePos;

	private Vector3 moveDirection;

	private float moveSpeed;

	#region void Awake()
	void Awake()
	{
		originalPos = transform.position;
		inactivePos = new Vector3( -3.5f, 1.0f, 0.0f );

		moveDirection = ( inactivePos - originalPos );
		moveDirection.Normalize();

		moveSpeed = 10.0f;
	}
	#endregion

	#region void Start()
	void Start()
	{
		if( PlayerSettingsScript.GetInstance.openingSceneViewed )
		{
			InactivateTopMenu();
		}
	}
	#endregion

	#region public void InactivateTopMenu()
	// Turns off button colliders
	// dims the top menu
	// moves the top menu to the left and up
	// moves the bottom menu on screen
	public void InactivateTopMenu()
	{
		MeshRenderer[] materials = GetComponentsInChildren<MeshRenderer>();
		foreach( MeshRenderer mat in materials )
		{
			Color col = mat.material.color;
			col.a = 0.5f;
			mat.material.color = col;
		}		
		
		GameObject[] buttons = GameObject.FindGameObjectsWithTag( "TopMenuButton" );
		foreach( GameObject go in buttons )
		{
			go.GetComponent<BoxCollider>().enabled = false;
		}

		StartCoroutine( "MoveMenuAway" );
		GameObject.Find( "BottomMenu" ).GetComponent<BottomMenuScript>().MoveOnScreen();
	}
	#endregion

	#region public void ActivateTopMenu()
	public void ActivateTopMenu()
	{
		MeshRenderer[] materials = GetComponentsInChildren<MeshRenderer>();
		foreach( MeshRenderer mat in materials )
		{
			Color col = mat.material.color;
			col.a = 1.0f;
			mat.material.color = col;
		}

		GameObject[] buttons = GameObject.FindGameObjectsWithTag( "TopMenuButton" );
		foreach( GameObject go in buttons )
		{
			go.GetComponent<BoxCollider>().enabled = true;
		}

		StartCoroutine( "MoveMenuBack" );
		StartCoroutine( GameObject.Find( "BottomMenu" ).GetComponent<BottomMenuScript>().MoveMenuOffScreen() );
	}
	#endregion

	#region public IEnumerator MoveMenuAway()
	public IEnumerator MoveMenuAway()
	{
		Debug.Log( "Starting TOP menu coroutine" );
		while( transform.position.x > inactivePos.x || transform.position.y < inactivePos.y )
		{
			Debug.Log( "TM Position: " + transform.position );
			transform.position += ( moveSpeed * moveDirection * Time.deltaTime );
			yield return null;
		}
		transform.position = inactivePos;
	}
	#endregion

	#region public IEnumerator MoveMenuBack()
	public IEnumerator MoveMenuBack()
	{
		while( transform.position.x < originalPos.x || transform.position.y > originalPos.y )
		{
			transform.position += ( moveSpeed * moveDirection * Time.deltaTime * -1.0f );
			yield return null;
		}
		transform.position = originalPos;
	}
	#endregion
}
