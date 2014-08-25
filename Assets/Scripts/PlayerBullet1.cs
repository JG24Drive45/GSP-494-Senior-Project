using UnityEngine;
using System.Collections;

public class PlayerBullet1 : PlayerBullet {

	// Use this for initialization
	public override void Start () 
	{
		velocity 	= new Vector3( 0.0f, 1.0f, 0.0f );
		speed		= 10.0f;
		damage		= PlayerSettingsScript.GetInstance.weaponStrength;
	}
	
	// Update is called once per frame
	public override void Update () 
	{
		base.Update();
	}

	public override void OnCollisionEnter2D( Collision2D other )
	{
		base.OnCollisionEnter2D( other );
	}
}
