using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour 
{
	// Button Attributes
	public 	float 		fButtonWidth;														// Width of the button
	public 	float 		fButtonHeight;														// Height of the button
	public 	string 		sButtonText;														// Text for the button
														
	public 	float 		fXPositionRate;														// Range from 0.0f to 1.0f
	public 	float 		fYPositionRate;														// Range from 0.0f to 1.0f
														
	public 	float 		fFontSizeRate;														// Range from 0.0f to 1.0f
														
	public 	GUIStyle 	guiStyle;															// GUIStyle for the button
														
	private Rect 		buttonRect;															// Rect position for the button
														
	void Awake()										
	{											   	
		int screenWidth, screenHeight;														// Cache screen width and height
		screenWidth 	= Screen.width;			 	
		screenHeight 	= Screen.height;				
														
		fButtonWidth 	= screenWidth / 4;													// Calculate button width based on screen width
		fButtonHeight	= screenHeight / 12; 												// Calculate button height based on screen height

		buttonRect = new Rect( ( screenWidth * fXPositionRate ) - ( fButtonWidth / 2.0f ), 	// Calculate the Rect position
		                      ( screenHeight * fYPositionRate ) - ( fButtonHeight / 2.0f ),
		                      fButtonWidth, fButtonHeight );

		guiStyle.fontSize = (int)( screenHeight * fFontSizeRate );							// Set button font size based on screen height
	}

	void Start () 
	{
	
	}

	void Update () 
	{

	}

	void OnGUI()
	{
		// If player clicked on a menu button
		if( GUI.Button( buttonRect, sButtonText, guiStyle ) )
		{
			switch( this.gameObject.name )													// Go to the scene that corresponds to the button clicked
			{
			case "PlayButton":
				Debug.Log( "CLicked the play button" );
				break;
			case "OptionsButton":
				Application.LoadLevel( "Options" );
				break;
			case "CreditsButton":
				Application.LoadLevel( "Credits" );
				break;
			case "ExitButton":
				Application.Quit();
				break;
			case "BackButton":
				Application.LoadLevel( "MainMenu" );
				break;
			}
		}
	}
}
