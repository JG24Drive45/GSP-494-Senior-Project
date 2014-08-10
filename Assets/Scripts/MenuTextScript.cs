using UnityEngine;
using System.Collections;

public class MenuTextScript : MonoBehaviour 
{
	// Public Variables
	public GUIStyle guiStyle;										// GUIStyle for the text

	// Private Variables
	private string[] menuText = new string[1];						// Array to hold all the possible strings
	private string text;											// Variable to hold the object's text string

	private int textLength;											// Length of the object's string text

	private int frameCount = 0;										// Framecount
	private int interval = 0;										// Sets the speed at which the object string is displayed

	private string currentText = "";								// Current letters being displayed on screen

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

		textLength = text.Length;
	}
	
	void Start () 
	{
		StartCoroutine( "DisplayText" );
	}

	void Update () 
	{
	
	}

	IEnumerator DisplayText()
	{
		while( frameCount < textLength )
		{
			interval++;
			if( interval % 2 == 0 )
			{
				currentText += text[frameCount];
				frameCount++;
			}

			yield return null;
		}
	}

	void OnGUI()
	{
		GUI.Label( new Rect( Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 100 ), currentText, guiStyle );
	}
}
