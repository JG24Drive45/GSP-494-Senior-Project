using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour 
{
	// Public
	public float health 	= 1.0f;							// Testing
	public float shields 	= 1.0f;							// Testing

	public int score		= 0;							// Testing
	public int debris		= 0;							// Testing

	public GUIStyle guiStyle;

	// Private	
	private Rect scoreRect;
	private Rect debrisRect;

	private float fLabelWidthRate	= 0.165f;
	private float fLabelHeightRate	= 0.075f;

	private float fFontSizeRate		= 0.05f;

	#region void Awake()
	void Awake()
	{
		int iScreenWidth	 = Screen.width;
		int iScreenHeight	 = Screen.height;
		int labelWidth, labelHeight;

		//Calculate the label size based on screen size
		labelWidth	= (int)( fLabelWidthRate * Screen.width );
		labelHeight	= (int)( fLabelHeightRate * Screen.height );

		// Calculate the Rects based on screen size
		scoreRect = new Rect( 0.1f * iScreenWidth, 0.03f * iScreenHeight, labelWidth, labelHeight );
		debrisRect = new Rect ( iScreenWidth * 0.9f - labelWidth, 0.03f * iScreenHeight, labelWidth, labelHeight );

		// Calculate the font based on screen size
		guiStyle.fontSize = (int)( fFontSizeRate * iScreenHeight );
	}
	#endregion

	#region void Start()
	void Start()
	{
		PlayerScript.OnEnemyDestroyed += UpdateScore;
	}
	#endregion

	#region void OnDestroy()
	void OnDestroy()
	{
		PlayerScript.OnEnemyDestroyed -= UpdateScore;
	}
	#endregion

	#region void Update()
	void Update () 
	{
		if(Input.GetKey(KeyCode.Keypad1))						// Testing
		{
			TakeHealthDamage( 0.05f );
		}
		else if (Input.GetKey(KeyCode.Keypad3))				// Testing
		{
			TakeShieldDamage( 0.1f );
		}
		else if( Input.GetKey(KeyCode.Keypad4))
		{
			TakeHealthDamage( 0.05f );
		}
		else if( Input.GetKey(KeyCode.Keypad6))
		{
			TakeShieldDamage( 0.1f );
		}

		if( Input.GetKeyDown( KeyCode.Return ) )
		{
			UpdateScore( 10 );
		}

		if( Input.GetKeyDown( KeyCode.Backspace ) )
		{
			UpdateDebris( 50 );
		}
	}
	#endregion

	#region public void TakeHealthDamage( float damage )
	public void TakeHealthDamage( float damage )
	{
		health -= damage;
		if( health > 0.0f )
		{
			Renderer temp = GameObject.Find( "LeftHUDPanel" ).GetComponent<Renderer>();
			temp.material.SetFloat( "_HealthPercentage", -( 1.0f - health ) );
			temp.material.SetFloat( "_Inverter", -1.0f );
		}
		else
		{
			// TODO: Kill Player
		}
	}
	#endregion

	#region public void TakeShieldDamage( float damage )
	public void TakeShieldDamage( float damage )
	{
		shields -= damage;
		if( shields > 0.0f )
		{
			GameObject.Find( "RightHUDPanel" ).GetComponent<Renderer>().material.SetFloat( "_HealthPercentage", shields );
		}
	}
	#endregion

	#region public void UpdateScore( int points )
	public void UpdateScore( int points )
	{
		score += points;									// Update the variable
	}
	#endregion

	#region public void UpdateDebris()
	public void UpdateDebris( int scrap )
	{
		debris += scrap;
	}
	#endregion

	#region void OnGUI()
	void OnGUI()
	{
		GUI.Label( scoreRect, score.ToString(), guiStyle );			// Display the score
		GUI.Label( debrisRect, debris.ToString(), guiStyle );			// Display the debris count
	}
	#endregion
}
