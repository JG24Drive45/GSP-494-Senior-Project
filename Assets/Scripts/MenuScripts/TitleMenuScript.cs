using UnityEngine;
using System.Collections;

public class TitleMenuScript : MonoBehaviour 
{
	void Update () 
	{
		if( Input.anyKeyDown )
		{
			Application.LoadLevel( "MainMenu" );
		}
	}
}
