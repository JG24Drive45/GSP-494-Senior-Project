using UnityEngine;
using System.Collections;

public class PlayerSettingsScript : MonoBehaviour
{
	public int totalScore		= 0;
	public int totalDebris		= 0;
	public float shipSpeed		= 10.0f;
	public int weaponStrength	= 5;

	public int upgradePoints	= 0;

	public int levelNum			= 0;										// What level is the player currently on
	public int narrativeNum		= 0;										// What narrative the player is currently on

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

		state = PlayerState.MAINMENU;

		DontDestroyOnLoad( this.gameObject );
	}
}
