using UnityEngine;
using System.Collections;

public class UpgradesScript : MonoBehaviour 
{
	private float fFontSizeRate		= 0.1f;
	public int fontSize;

	private GameObject speedText;
	private GameObject strengthText;
	private GameObject pointsText;
	private UpgradeVarsScript upgradeVars;

	#region void Start()
	void Start () 
	{
		speedText = GameObject.Find( "SpeedUpgradeText" );
		strengthText = GameObject.Find( "WeaponUpgradeText" );
		pointsText = GameObject.Find( "PointsText" );
		upgradeVars = GameObject.Find( "UpgradeVars" ).GetComponent<UpgradeVarsScript>();

		int iScreenWidth	 = Screen.width;
		int iScreenHeight	 = Screen.height;

		// Calculate the font based on screen size
		fontSize = (int)( fFontSizeRate * iScreenHeight );

		speedText.guiText.fontSize = fontSize;
		strengthText.guiText.fontSize = fontSize;
		pointsText.guiText.fontSize = fontSize;

		speedText.guiText.text = "Speed " + PlayerSettingsScript.GetInstance.shipSpeed.ToString();
		strengthText.guiText.text = "Strength " + PlayerSettingsScript.GetInstance.weaponStrength.ToString();
		pointsText.guiText.text = "Points Available " + PlayerSettingsScript.GetInstance.upgradePoints.ToString();
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
			if( PlayerSettingsScript.GetInstance.shipSpeed > 1.0f && upgradeVars.tempSpeed > upgradeVars.originalSpeed )
			{
				upgradeVars.tempSpeed -= 1.0f;
				upgradeVars.pointsAvail++;
				upgradeVars.pointsUsed--;
				UpdateSpeedText();
				UpdatePointsText();
			}
			break;
		case "SpeedUpArrow":
			if( PlayerSettingsScript.GetInstance.shipSpeed < 10.0f && upgradeVars.pointsAvail > 0 )
			{
				upgradeVars.tempSpeed += 1.0f;
				upgradeVars.pointsAvail--;
				upgradeVars.pointsUsed++;
				UpdateSpeedText();
				UpdatePointsText();
			}
			break;
		case "StrengthDownArrow":
			if( PlayerSettingsScript.GetInstance.weaponStrength > 1 && upgradeVars.tempStrength > upgradeVars.originalStrenth )
			{
				upgradeVars.tempStrength--;
				upgradeVars.pointsAvail++;
				upgradeVars.pointsUsed--;
				UpdateStrengthText();
				UpdatePointsText();
			}
			break;
		case "StrengthUpArrow":
			if( PlayerSettingsScript.GetInstance.weaponStrength < 10 && upgradeVars.pointsAvail > 0 )
			{
				upgradeVars.tempStrength++;
				upgradeVars.pointsAvail--;
				upgradeVars.pointsUsed++;
				UpdateStrengthText();
				UpdatePointsText();
			}
			break;
		case "SaveButton":
			PlayerSettingsScript.GetInstance.shipSpeed = upgradeVars.tempSpeed;
			PlayerSettingsScript.GetInstance.weaponStrength = upgradeVars.tempStrength;
			PlayerSettingsScript.GetInstance.totalScore -= ( upgradeVars.pointsUsed * 2000 );
			// Update the amount of upgrade points the player has
			PlayerSettingsScript.GetInstance.upgradePoints = PlayerSettingsScript.GetInstance.totalScore / 2000;
			break;
		}
	}
	#endregion

	#region void UpdateSpeedText()
	void UpdateSpeedText()
	{
		speedText.guiText.text = "Speed " + upgradeVars.tempSpeed.ToString();
	}
	#endregion

	#region void UpdateStrengthText()
	void UpdateStrengthText()
	{
		strengthText.guiText.text = "Strength " + upgradeVars.tempStrength.ToString();
	}
	#endregion

	#region void UpdatePointsText()
	void UpdatePointsText()
	{
		pointsText.guiText.text = "Points Available " + upgradeVars.pointsAvail.ToString();
	}
	#endregion
}
