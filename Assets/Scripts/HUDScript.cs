using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour 
{
	public float health = 1.0f;					// Testing
	public float shields = 1.0f;				// Testing

	void Awake()
	{

	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Keypad1))						// Testing
		{
			if( health > 0.0f )
			{
				health -= 0.01f;
				if( health < 0.0f )
					health = 0.0f;
				UpdateHealthBar();
			}
		}
		else if (Input.GetKey(KeyCode.Keypad3))				// Testing
		{
			if( shields > 0.0f )
			{
				shields -= 0.01f;
				if( shields < 0.0f )
					shields = 0.0f;
				UpdateHealthBar();
			}
		}
		else if( Input.GetKey(KeyCode.Keypad4))
		{
			if( health < 1.0f )
			{
				health += 0.01f;
				if( health > 1.0f )
					health = 1.0f;
				UpdateHealthBar();
			}
		}
		else if( Input.GetKey(KeyCode.Keypad6))
		{
			if( shields < 1.0f )
			{
				shields += 0.01f;
				if( shields > 1.0f )
					shields = 1.0f;
				UpdateHealthBar();
			}
		}
	}

	public void UpdateHealthBar()
	{
		Renderer temp = GameObject.Find( "LeftHealthBar" ).GetComponent<Renderer>();
		temp.material.SetFloat( "_HealthPercentage", -( 1.0f - health ) );
		temp.material.SetFloat( "_Inverter", -1.0f );


		GameObject.Find( "RightHealthBar" ).GetComponent<Renderer>().material.SetFloat( "_HealthPercentage", shields );
	}
}
