using UnityEngine;
using System.Collections;

public class MenuTextScript : MonoBehaviour 
{
	#region Variables
	// Public Variables
	public GUIStyle guiStyle;										// GUIStyle for the text

	// Private Variables
	private string[] menuText = new string[2];						// Array to hold all the possible strings
	private string text;											// Variable to hold the object's text string

	private int textLength;											// Length of the object's string text

	private int frameCount = 0;										// Framecount
	private int interval = 0;										// Sets the speed at which the object string is displayed

	private string currentText = "";								// Current letters being displayed on screen
	private string currentBlackText = "";

	private const float fontSizeRate = 0.075f;						// Use for calculating the font size based on screen height

	private Rect whiteTextRect;										// Rect for foreground text
	private Rect blackTextRect;										// Rect for drop shadow text
	#endregion

	#region void Awake()
	void Awake()
	{
		// Credits
		menuText[0] = 	"Kurt Eastabrooks - Gameplay Programmer\n" +
					  	"Jill Gray - Main Menu & GUI Programmer\n" +
					  	"Jordan Huffman - Enemy & AI Programmer\n" +
						"Eric Huntzberry - Sound & Narration Programmer\n\n" +
						"Special thanks to Matt Devlin\n" +
						"for Main Menu and HUD artwork";
		// Instructions
		menuText[1] = 	"Use the arrow or WASD\n" +
						"keys to move your ship\n\n" +
						"Use the spacebar\n" +
						"to shoot\n\n" +
						"Collect debris along the way";

		switch( this.gameObject.name )
		{
		case "CreditsMenuText":
			text = menuText[0];
			break;

		case "InstructionsMenuText":
			text = menuText[1];
			break;
		}

		// Cache length of the text string
		textLength = text.Length;

		// Cache resolution
		int width = Screen.width;
		int height = Screen.height;

		// Calculate the font size
		guiStyle.fontSize = (int)( height * fontSizeRate );

		// Set font weight
		guiStyle.fontStyle = FontStyle.Normal;

		// Used for drop shadow
		blackTextRect = new Rect( width / 2 - 75, height / 2 - 50, 155, 105 );
		// Use for foreground text
		whiteTextRect = new Rect( width / 2 - 75, height / 2 - 50, 150, 100 );
	}
	#endregion

	#region void Start()
	void Start () 
	{
		StartCoroutine( "DisplayText" );
	}
	#endregion

	#region IEnumerator DisplayText()
	IEnumerator DisplayText()
	{
		while( frameCount < textLength )
		{
			interval++;
			if( interval % 2 == 0 )
			{
				currentText += text[frameCount];
				currentBlackText += text[frameCount];
				frameCount++;
			}

			yield return null;
		}
	}
	#endregion

	#region void OnGUI()
	void OnGUI()
	{
		//guiStyle.normal.textColor = Color.red;
		guiStyle.normal.textColor = new Color( 0.97f, 0.66f, 0.0f );
		GUI.Label( blackTextRect, currentBlackText, guiStyle );
		guiStyle.normal.textColor = Color.white;
		GUI.Label( whiteTextRect, currentText, guiStyle );
	}
	#endregion
}
