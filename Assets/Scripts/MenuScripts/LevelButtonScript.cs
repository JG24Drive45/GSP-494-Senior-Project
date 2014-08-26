using UnityEngine;
using System.Collections;

public class LevelButtonScript : MonoBehaviour 
{
	public int levelNum;
	public float levelTime;
	public bool isLevelBeaten	= false;

	void Awake()
	{
		levelTime = 60 + ( (levelNum - 1) % 10 ) * 10;
	}

	void Start () 
	{
		isLevelBeaten = PlayerSettingsScript.GetInstance.levelStatus[levelNum - 1];
	}

	void Update () 
	{
	}

	void OnMouseUp()
	{
		switch( this.gameObject.name )
		{
		case "Level1Button":
			Debug.Log( "Clicked Level 1 Buton" );
			PlayerSettingsScript.GetInstance.levelNum = levelNum;
			PlayerSettingsScript.GetInstance.levelTime = levelTime;
			//Application.LoadLevel( "Jills Test Level" );
			Application.LoadLevel( "Narrative Cutscene" );
			break;
		}
	}

	void SetLevelBeaten( int levelNum )
	{
		if( this.levelNum == levelNum )
		{
			isLevelBeaten = true;
		}
	}
}
