using UnityEngine;
using System.Collections;

public class MenuTextScript : MonoBehaviour 
{
	#region Variables
	// Public Variables
	public GUIStyle guiStyle;										// GUIStyle for the text

	// Private Variables
	private string[] menuText = new string[1];						// Array to hold all the possible strings
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
		menuText[0] = 	"Kurt Eastabrooks\n" +
					  	"Jill Gray\n" +
					  	"Jordan Huffman\n" +
						"Eric Huntzberry";

		switch( this.gameObject.name )
		{
		case "CreditsMenuText":
			text = menuText[0];
			break;
		}

		// Cache length of the text string
		textLength = text.Length;

		// Cache resolution
		int width = Screen.width;
		int height = Screen.height;

		// Calculate the font size
		guiStyle.fontSize = (int)( height * fontSizeRate );

		// Used for drop shadow
		blackTextRect = new Rect( width / 2 - 75, height / 2 - 50, 153, 103 );
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
		guiStyle.normal.textColor = Color.red;
		GUI.Label( blackTextRect, currentBlackText, guiStyle );
		guiStyle.normal.textColor = Color.white;
		GUI.Label( whiteTextRect, currentText, guiStyle );
	}
	#endregion
}
