using UnityEngine;
using System.Collections;

public class LevelButtonScript : MonoBehaviour 
{
	public int levelNum;
	public float levelTime;
	public bool isLevelBeaten	= false;

	public bool isLevelUnlocked = false;

	public Material[] materials;

	#region void Awake()
	void Awake()
	{
		levelTime = 60 + ( (levelNum - 1) % 10 ) * 10;

		if( levelNum == 1 )
		{
			isLevelUnlocked = true;
			renderer.material = materials[1];
		}
		else
		{
			isLevelUnlocked = PlayerSettingsScript.GetInstance.levelStatus[levelNum - 2];
			if( isLevelUnlocked )
				renderer.material = materials[1];
			else
				renderer.material = materials[0];
		}
	}
	#endregion

	#region void Start()
	void Start () 
	{
		isLevelBeaten = PlayerSettingsScript.GetInstance.levelStatus[levelNum - 1];
	}
	#endregion

	#region void OnMouseUp()
	void OnMouseUp()
	{
		if( isLevelUnlocked )
		{
			switch( this.gameObject.name )
			{
			case "Level1Button":
				Debug.Log( "Clicked Level 1 Buton" );
				PlayerSettingsScript.GetInstance.levelNum = levelNum;
				PlayerSettingsScript.GetInstance.levelTime = levelTime;
				PlayerSettingsScript.GetInstance.sceneNum = PlayerSettingsScript.GetInstance.levelNum * 2 - 1;
				Application.LoadLevel( "Narrative Cutscene" );
				break;
			}
		}
	}
	#endregion

	#region void SetLevelBeaten( int levelNum )
	void SetLevelBeaten( int levelNum )
	{
		if( this.levelNum == levelNum )
		{
			isLevelBeaten = true;
		}
	}
	#endregion
}
