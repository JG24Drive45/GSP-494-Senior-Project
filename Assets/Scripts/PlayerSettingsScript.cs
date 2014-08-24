using UnityEngine;
using System.Collections;

public class PlayerSettingsScript : MonoBehaviour
{
	public static int score		= 0;
	public static int debris	= 0;

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
		
		DontDestroyOnLoad( this.gameObject );
	}
}
