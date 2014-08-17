using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour 
{
	private RaycastHit 	hit;
	private Ray			ray;

	public Material[] materials;

	#region void Update()
	void Update()
	{
		ray = Camera.main.ScreenPointToRay( Input.mousePosition );

		// Change Button material if it is hovered over
		if( Physics.Raycast( ray, out hit ) )
		{
			switch( hit.collider.name )
			{
			case "BackButton":
				hit.collider.GetComponent<Renderer>().material = materials[1];
				break;
			case "ButtonHoverCollider":
				GameObject.Find( "BackButton" ).GetComponent<Renderer>().material = materials[0];
				break;
			}
		}

		// Check for Button Clicks
		if( Input.GetMouseButtonUp(0) )
		{
			if( Physics.Raycast( ray, out hit ) )
			{
				switch( hit.collider.name )
				{
				case "BackButton":
					Debug.Log( "Clicked Back Button" );
					Application.LoadLevel( "MainMenu" );
					break;
				}
			}
		}
	}
	#endregion
}
