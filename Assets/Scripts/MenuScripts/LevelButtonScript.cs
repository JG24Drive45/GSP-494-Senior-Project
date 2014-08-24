using UnityEngine;
using System.Collections;

public class LevelButtonScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		switch( this.gameObject.name )
		{
		case "Level1Button":
			Debug.Log( "Clicked Level 1 Buton" );
			Application.LoadLevel( "Jills Test Level" );
			break;
		}
	}
}
