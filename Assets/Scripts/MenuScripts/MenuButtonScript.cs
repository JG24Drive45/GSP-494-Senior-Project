using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuButtonScript : MonoBehaviour 
{
	public Material[] materials;
	public Material[] onHoverMaterials;

	private RaycastHit 	hit;
	private Ray			ray;

	public List<Renderer> buttonRenderers = new List<Renderer>();

	#region void Awake()
	void Awake()
	{
		buttonRenderers.Add( GameObject.Find( "PlayGameButton" ).GetComponent<Renderer>() );
		buttonRenderers.Add( GameObject.Find( "LoadGameButton" ).GetComponent<Renderer>() );
		buttonRenderers.Add( GameObject.Find( "InstructionsButton" ).GetComponent<Renderer>() );
		buttonRenderers.Add( GameObject.Find( "OptionsButton" ).GetComponent<Renderer>() );
		buttonRenderers.Add( GameObject.Find( "CreditsButton" ).GetComponent<Renderer>() );
		buttonRenderers.Add( GameObject.Find( "ExitButton" ).GetComponent<Renderer>() );
	}
	#endregion

	#region void Update()
	void Update () 
	{
		ray = Camera.main.ScreenPointToRay( Input.mousePosition );

		// Change Button material if it is hovered over
		if( Physics.Raycast( ray, out hit ) )
		{
			switch( hit.collider.name )
			{
			case "PlayGameButton":
				hit.collider.GetComponent<Renderer>().material = onHoverMaterials[0];
				break;
			case "LoadGameButton":
				hit.collider.GetComponent<Renderer>().material = onHoverMaterials[1];
				break;
			case "InstructionsButton":
				hit.collider.GetComponent<Renderer>().material = onHoverMaterials[2];
				break;
			case "OptionsButton":
				hit.collider.GetComponent<Renderer>().material = onHoverMaterials[3];
				break;
			case "CreditsButton":
				hit.collider.GetComponent<Renderer>().material = onHoverMaterials[4];
				break;
			case "ExitButton":
				hit.collider.GetComponent<Renderer>().material = onHoverMaterials[5];
				break;
			case "ControlPanel":
				for( int i = 0; i < buttonRenderers.Count; i++ )
				{
					buttonRenderers[i].material = materials[i];
				}
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
				case "PlayGameButton":
					Debug.Log( "Clicked Play Game Button" );
					break;
				case "LoadGameButton":
					Debug.Log( "Clicked Load Game Button" );
					break;
				case "InstructionsButton":
					Debug.Log( "Clicked Instructions Button" );
					Application.LoadLevel( "Instructions" );
					break;
				case "OptionsButton":
					Debug.Log( "Clicked Options Button" );
					Application.LoadLevel( "Options" );
					break;
				case "CreditsButton":
					Debug.Log( "Clicked Credits Button" );
					Application.LoadLevel( "Credits" );
					break;
				case "ExitButton":
					Debug.Log( "Clicked Exit Button" );
					break;
				}
			}
		}
	}
	#endregion
}
