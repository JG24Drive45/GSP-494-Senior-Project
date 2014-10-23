using UnityEngine;
using System.Collections;

public class ToggleSoundScript : MonoBehaviour 
{
	public int fontSize;

	void Start () 
	{
		float fontRate = 0.15f;
		int height;
		height = Screen.height;
		fontSize = (int)(height * fontRate);

		GameObject.Find( "SoundText" ).guiText.fontSize = fontSize;
	}

	void OnMouseUp()
	{
		AudioSource[] aud;

		switch( gameObject.name )
		{
		case "OnButton":
			//GameObject.Find( "SoundManager" ).audio.volume = 1.0f;
			aud = GameObject.Find( "SoundManager" ).GetComponents<AudioSource>();
			foreach( AudioSource source in aud )
			{
				source.volume = 1.0f;
			}
			Debug.Log( "ON" );
			break;
		case "OffButton":
			//GameObject.Find( "SoundManager" ).audio.volume = 0.0f;
			aud = GameObject.Find( "SoundManager" ).GetComponents<AudioSource>();
			foreach( AudioSource source in aud )
			{
				source.volume = 0.0f;
			}
			Debug.Log( "OFF" );
			break;
		}
	}
}
