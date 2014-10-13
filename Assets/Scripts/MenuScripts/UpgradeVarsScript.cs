using UnityEngine;
using System.Collections;

public class UpgradeVarsScript : MonoBehaviour 
{
	public float originalSpeed;
	public float tempSpeed;
	public int originalStrenth;
	public int tempStrength;
	public int pointsAvail;
	public int pointsUsed;

	// Use this for initialization
	void Start () 
	{
		originalSpeed = tempSpeed = PlayerSettingsScript.GetInstance.shipSpeed;
		originalStrenth = tempStrength = PlayerSettingsScript.GetInstance.weaponStrength;
		pointsAvail = PlayerSettingsScript.GetInstance.upgradePoints;
		pointsUsed = 0;
	}

}
