using UnityEngine;
using System.Collections;

public class LevelCompleteMenuScript : MonoBehaviour 
{
	private GUIText guitext;

	void Awake()
	{
		int width, height;
		width = Screen.width;
		height = Screen.height;

		guitext = GameObject.Find( "Text" ).GetComponent<GUIText>();
		guitext.fontSize = (int)( height * 0.07f );
		guitext.text = "Level " + PlayerSettingsScript.GetInstance.levelNum.ToString() + " Complete\n\n" +
					   "Score: " + GameObject.Find( "HUD" ).GetComponent<HUDScript>().GetPoints().ToString() + "\n" +
					   "Debris: " + GameObject.Find( "HUD" ).GetComponent<HUDScript>().GetDebris().ToString();
		guitext.transform.localPosition = new Vector3( 0.1f, 0.105f, 0.0f );
	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
