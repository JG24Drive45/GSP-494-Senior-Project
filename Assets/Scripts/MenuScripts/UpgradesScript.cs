using UnityEngine;
using System.Collections;

public class UpgradesScript : MonoBehaviour 
{
	private float fFontSizeRate		= 0.1f;
	public int fontSize;

	private GameObject speedText;
	private GameObject strengthText;

	#region void Start()
	void Start () 
	{
		speedText = GameObject.Find( "SpeedUpgradeText" );
		strengthText = GameObject.Find( "WeaponUpgradeText" );

		int iScreenWidth	 = Screen.width;
		int iScreenHeight	 = Screen.height;

		// Calculate the font based on screen size
		fontSize = (int)( fFontSizeRate * iScreenHeight );

		speedText.guiText.fontSize = fontSize;
		strengthText.guiText.fontSize = fontSize;

		speedText.guiText.text = "Speed " + PlayerSettingsScript.GetInstance.shipSpeed.ToString();
		strengthText.guiText.text = "Strength " + PlayerSettingsScript.GetInstance.weaponStrength.ToString();
	}
	#endregion

	#region void Update()
	void Update () 
	{
	
	}
	#endregion

	#region void OnMouseUp()
	void OnMouseUp()
	{
		switch( this.gameObject.name )
		{
		case "SpeedDownArrow":
			if( PlayerSettingsScript.GetInstance.shipSpeed > 1.0f )
			{
				PlayerSettingsScript.GetInstance.shipSpeed--;
				UpdateSpeedText();
			}
			break;
		case "SpeedUpArrow":
			if( PlayerSettingsScript.GetInstance.shipSpeed < 10.0f )
			{
				PlayerSettingsScript.GetInstance.shipSpeed++;
				UpdateSpeedText();
			}
			break;
		case "StrengthDownArrow":
			if( PlayerSettingsScript.GetInstance.weaponStrength > 1 )
			{
				PlayerSettingsScript.GetInstance.weaponStrength--;
				UpdateStrengthText();
			}
			break;
		case "StrengthUpArrow":
			if( PlayerSettingsScript.GetInstance.weaponStrength < 10 )
			{
				PlayerSettingsScript.GetInstance.weaponStrength++;
				UpdateStrengthText();
			}
			break;
		}
	}
	#endregion

	#region void UpdateSpeedText()
	void UpdateSpeedText()
	{
		speedText.guiText.text = "Speed " + PlayerSettingsScript.GetInstance.shipSpeed.ToString();
	}
	#endregion

	#region void UpdateStrengthText()
	void UpdateStrengthText()
	{
		strengthText.guiText.text = "Strength " + PlayerSettingsScript.GetInstance.weaponStrength.ToString();
	}
	#endregion
}
