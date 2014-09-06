using UnityEngine;
using System.Collections;

public class PlayerSettingsScript : MonoBehaviour
{
	public int totalScore			= 0;
	public int totalDebris			= 0;
	public float shipSpeed			= 5.0f;
	public int weaponStrength		= 5;

	public int upgradePoints		= 0;

	public int levelNum				= 0;										// What level is the player currently on
	public int narrativeNum			= 0;										// What narrative the player is currently on
	public float levelTime			= 0;

	public bool[] levelStatus 		= new bool[10];

	public int sceneNum				= 0;
	public bool openingSceneViewed 	= false;

	public enum PlayerState { MAINMENU, LEVEL, NARRATIVE, UPGRADE };
	PlayerState state;

	private static PlayerSettingsScript instance = null;
	
	public static PlayerSettingsScript GetInstance
	{
		get
		{
			return instance;
		}
	}

	#region void Awake()
	void Awake()
	{
		if( instance != null && instance != this )
		{
			Destroy( this.gameObject );
			return;
		}
		else
		{
			instance = this;
		}

		DontDestroyOnLoad( this.gameObject );
	}
	#endregion

	#region void Start()
	void Start()
	{
		PlayerScript.OnLevelBeaten += SetLevelBeaten;

		state = PlayerState.MAINMENU;
		for( int i = 0; i < 10; i++ )
		{
			levelStatus[i] = false;
		}
	}
	#endregion

	void OnDestroy()
	{
		PlayerScript.OnLevelBeaten -= SetLevelBeaten;
	}

	void SetLevelBeaten( int levelNum )
	{
		levelStatus[levelNum - 1] = true;
	}
}
