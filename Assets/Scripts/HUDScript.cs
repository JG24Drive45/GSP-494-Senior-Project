using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour 
{
	// Public
	public float health 	= 1.0f;							// Testing
	public float shields 	= 1.0f;							// Testing

	public int score		= 0;							// Testing
	public int debris		= 0;							// Testing

	public int fontSize		= 12;

	// Private	
	private float fFontSizeRate		= 0.055f;

	#region void Awake()
	void Awake()
	{
		int iScreenWidth	 = Screen.width;
		int iScreenHeight	 = Screen.height;

		// Calculate the font based on screen size
		fontSize = (int)( fFontSizeRate * iScreenHeight );

		// Calculate the positions of the points and debris GUIs
		GameObject p = GameObject.Find( "PointsGUITexture" );
		p.transform.localPosition = new Vector3( 0.15f, 0.91f, 0.0f );
		GameObject d = GameObject.Find( "DebrisGUITexture" );
		d.transform.localPosition = new Vector3( 0.855f, 0.91f, 0.0f );

		// Calculate the texture size of the points and debris GUIs
		int w = (int)( iScreenWidth * 0.3f );
		int h = (int)( iScreenHeight * 0.15f );
		p.guiTexture.pixelInset = new Rect( -( w / 2 ), -( h / 2 ), w, h );
		d.guiTexture.pixelInset = new Rect( -( w / 2 ), -( h / 2 ), w, h );

		// Set the GUIText for the points and debris
		p = GameObject.Find( "PointsGUIText" );
		p.transform.localPosition = new Vector3( 0.03f, 0.912f, 0.5f );
		p.guiText.fontSize = fontSize;
		p.guiText.text = "Points " + score;

		d = GameObject.Find( "DebrisGUIText" );
		d.transform.localPosition = new Vector3( 0.735f, 0.912f, 0.5f );
		d.guiText.fontSize = fontSize;
		d.guiText.text = "Debris " + debris;
	}
	#endregion

	#region void Start()
	void Start()
	{
		PlayerScript.OnEnemyCollision += TakeShieldDamage;
		PlayerScript.OnDebrisCollected += UpdateDebris;
	}
	#endregion

	#region void OnDestroy()
	void OnDestroy()
	{
		PlayerScript.OnEnemyCollision -= TakeShieldDamage;
		PlayerScript.OnDebrisCollected -= UpdateDebris;
	}
	#endregion

	#region void Update()
	void Update () 
	{
		if( Input.GetKeyDown( KeyCode.Return ) )
		{
			UpdateScore( 10 );
		}

		// Regenerate shields
		RegenerateShield();
	}
	#endregion

	#region public void TakeHealthDamage( float damage )
	public void TakeHealthDamage( float damage )
	{
		health -= damage;
		if( health >= 0.0f )
		{
			Renderer temp = GameObject.Find( "LeftHUDPanel" ).GetComponent<Renderer>();
			temp.material.SetFloat( "_HealthPercentage", -( 1.0f - health ) );
			temp.material.SetFloat( "_Inverter", -1.0f );
		}
		else
		{
			health = 0.0f;

			Renderer temp = GameObject.Find( "LeftHUDPanel" ).GetComponent<Renderer>();
			temp.material.SetFloat( "_HealthPercentage", -( 0.0f ) );
			temp.material.SetFloat( "_Inverter", -1.0f );
		}

		// TODO: Kill Player
		if( health <= 0.0f )
		{
			// Player is dead
			Debug.Log( "PLAYER IS DEAD!!!" );
			Application.LoadLevel( "MainMenu" );
		}
	}
	#endregion

	#region public void TakeShieldDamage( float damage )
	public void TakeShieldDamage( float damage )
	{
		float shieldDamage, healthDamage;
		shieldDamage = healthDamage = 0.0f;

		if( shields >= damage )
			shieldDamage = damage;
		else
		{
			shieldDamage = shields ;
			healthDamage = damage - shields;
		}

		shields -= shieldDamage;

		if( shields >= 0.0f )
		{
			GameObject.Find( "RightHUDPanel" ).GetComponent<Renderer>().material.SetFloat( "_HealthPercentage", shields );
		}

		TakeHealthDamage( healthDamage );
	}
	#endregion

	#region public void UpdateScore( int points )
	public void UpdateScore( int points )
	{
		score += points;									// Update the variable
		GameObject.Find( "PointsGUIText" ).guiText.text = "Score " + score;
	}
	#endregion

	#region public void UpdateDebris( int debrisVal )
	public void UpdateDebris( int debrisVal )
	{
		debris += debrisVal;
		GameObject.Find( "DebrisGUIText" ).guiText.text = "Debris " + debris;
	}
	#endregion

	#region public void RegenerateShield()
	public void RegenerateShield()
	{
		if( shields < 1.0f )
		{
			shields += 0.0005f;
			if( shields > 1.0f )
				shields = 1.0f;

			// Update the shield bar
			TakeShieldDamage( 0.0f );
		}

	}
	#endregion
}
