using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour 
{
	// Button Attributes
	public float fButtonWidth;
	public float fButtonHeight;
	public string sButtonText;

	public float fXPositionRate;					// Range from 0.0f to 1.0f
	public float fYPositionRate;					// Range from 0.0f to 1.0f

	public float fFontSizeRate;						// Range from 0.0f to 1.0f

	public GUIStyle guiStyle;


	void Awake()
	{
		guiStyle.fontSize = (int)( Screen.height * fFontSizeRate );
	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if( GUI.Button( new Rect ( ( Screen.width * fXPositionRate ) - ( fButtonWidth / 2.0f ), ( Screen.height * fYPositionRate ) - ( fButtonHeight / 2.0f ), 
		                          fButtonWidth, fButtonHeight ), sButtonText, guiStyle ) )
		{
			Debug.Log( "Clicked Button" );
		}
	}
}
