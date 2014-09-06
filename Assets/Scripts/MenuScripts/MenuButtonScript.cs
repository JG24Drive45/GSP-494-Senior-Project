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
			PlayerSettingsScript.GetInstance.sceneNum = 0;
			PlayerSettingsScript.GetInstance.openingSceneViewed = true;
			Application.LoadLevel( "Narrative Cutscene" );
			break;




		case "LoadGameButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the load game button" );

			// needs to bring out the submenu
			GameObject.Find( "TopMenu" ).GetComponent<TopMenuScript>().InactivateTopMenu();
			break;



		case "InstructionsButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the instructions button" );
			Application.LoadLevel( "Instructions" );
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
			Application.Quit();
			break;
		case "UpgradesButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the upgrades button" );
			// TODO: go to the upgrades scene
			break;
		case "LevelButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the level button" );
			Application.LoadLevel( "LevelSelect" );
			break;
		case "OptionsButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the options button" );
			Application.LoadLevel( "Options" );
			break;
		case "SubBackButton":
			if( onMouseClick != null )
				onMouseClick();
			GameObject.Find( "TopMenu" ).GetComponent<TopMenuScript>().ActivateTopMenu();
			break;
		case "BackButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the back button" );
			Application.LoadLevel( "MainMenu" );
			break;
		case "ContinueButton":
			if( onMouseClick != null )
				onMouseClick();
			Debug.Log( "Clicked the continue button" );
			// Change time scale back to 1
			Time.timeScale = 1.0f;
			Application.LoadLevel( "Narrative Cutscene" );
			break;
		}
	}
	#endregion
}
