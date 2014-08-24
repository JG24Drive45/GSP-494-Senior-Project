using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour 
{
	public delegate void SFX();

	public static event SFX onMouseOver;
	public static event SFX onMouseClick;

	public Material[] materials;

	#region void OnMouseEnter()
	void OnMouseEnter()
	{
		if( onMouseOver != null )
			onMouseOver();
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
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the play game button" );
			Application.LoadLevel( "LevelSelect" );
			break;
		case "LoadGameButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the load game button" );
			break;
		case "InstructionsButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the instructions button" );
			Application.LoadLevel( "Instructions" );
			break;
		case "OptionsButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the options button" );
			Application.LoadLevel( "Options" );
			break;
		case "CreditsButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the credits button" );
			Application.LoadLevel( "Credits" );
			break;
		case "ExitButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the exit button" );
			break;
		case "BackButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the back button" );
			Application.LoadLevel( "MainMenu" );
			break;
		}
	}
	#endregion
}
