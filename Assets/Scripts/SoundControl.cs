//using UnityEngine;
//using System.Collections;
//
//public class SoundControl : MonoBehaviour {
//
//	public void PlaySound(string p_pathFileName)
//	{
//		audio.clip = (AudioClip)Resources.Load ("Sounds/" + p_pathFileName);
//		audio.PlayOneShot (audio.clip);
//	}
//
//	// Use this for initialization
//	void Start () {
//		DontDestroyOnLoad (GameObject.Find("SoundManager"));
//		PlaySound ("Menu/ButtonHover");
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}


using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour 
{
	private static SoundControl instance = null;
	
	public AudioClip onHover;
	public AudioClip onClick;
	public AudioClip playerBulletFire;
	public AudioClip enemyBulletFire;
	
	public static SoundControl GetInstance
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

		// Subscribe to events
		MenuButtonScript.onMouseOver += PlayOnHover;
		MenuButtonScript.onMouseClick += PlayOnClick;
		PlayerScript.OnPlayerShooting += PlayPlayerFire;
		Enemy1AI.OnEnemyFire += PlayEnemyFire;
		Enemy2AI.OnEnemyFire += PlayEnemyFire;
		Enemy3AI.OnEnemyFire += PlayEnemyFire;
	}

	void OnDestroy()
	{
		MenuButtonScript.onMouseOver -= PlayOnHover;
		MenuButtonScript.onMouseClick -= PlayOnClick;
		PlayerScript.OnPlayerShooting -= PlayPlayerFire;
		Enemy1AI.OnEnemyFire -= PlayEnemyFire;
		Enemy2AI.OnEnemyFire -= PlayEnemyFire;
		Enemy3AI.OnEnemyFire -= PlayEnemyFire;
	}

	void PlayOnHover()
	{
		audio.PlayOneShot( onHover );
	}

	void PlayOnClick()
	{
		audio.PlayOneShot( onClick );
	}

	void PlayPlayerFire()
	{
		audio.PlayOneShot (playerBulletFire);
	}

	void PlayEnemyFire()
	{
		audio.PlayOneShot( enemyBulletFire );
	}
}
