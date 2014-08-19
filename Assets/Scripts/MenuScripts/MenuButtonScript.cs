using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour 
{
	public Material[] materials;

	#region void OnMouseEnter()
	void OnMouseEnter()
	{
		this.gameObject.renderer.material = materials[1];
	}
	#endregion

	#region void OnMouseExit()
	void OnMouseExit()
	{
		this.gameObject.renderer.material = materials[0];
	}
	#endregion

	#region void OnMouseUp()
	void OnMouseUp()
	{
		switch( this.gameObject.name )
		{
		case "PlayGameButton":
			Debug.Log( "Clicked the play game button" );
			break;
		case "LoadGameButton":
			Debug.Log( "Clicked the load game button" );
			break;
		case "InstructionsButton":
			Debug.Log( "Clicked the instructions button" );
			Application.LoadLevel( "Instructions" );
			break;
		case "OptionsButton":
			Debug.Log( "Clicked the options button" );
			Application.LoadLevel( "Options" );
			break;
		case "CreditsButton":
			Debug.Log( "Clicked the credits button" );
			Application.LoadLevel( "Credits" );
			break;
		case "ExitButton":
			Debug.Log( "Clicked the exit button" );
			break;
		case "BackButton":
			Debug.Log( "Clicked the back button" );
			Application.LoadLevel( "MainMenu" );
			break;
		}
	}
	#endregion
}
