﻿using UnityEngine;
using System.Collections;

public class PlayerSettingsScript : MonoBehaviour
{
	public int totalScore		= 0;
	public int totalDebris		= 0;
	public float shipSpeed		= 5.0f;

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
