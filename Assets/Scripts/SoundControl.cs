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
	public AudioSource sounds;
	public AudioSource loopingBGM;

	private static SoundControl instance = null;
	
	public AudioClip onHover;
	public AudioClip onClick;
	public AudioClip playerBulletFire;
	public AudioClip enemyBulletFire;
	public AudioClip menuBGM;
	public AudioClip levelBGM;
	public AudioClip narrationBGM;

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

		AudioSource[] aSources = GetComponents<AudioSource> ();
		
		sounds = aSources[0];
		loopingBGM = aSources[1];

		loopingBGM.loop = true;

		// Subscribe to events
		MenuButtonScript.onMouseOver += PlayOnHover;
		MenuButtonScript.onMouseClick += PlayOnClick;
		PlayerScript.OnPlayerShooting += PlayPlayerFire;
		Enemy1AI.OnEnemyFire += PlayEnemyFire;
		Enemy2AI.OnEnemyFire += PlayEnemyFire;
		Enemy3AI.OnEnemyFire += PlayEnemyFire;

		PlayMenuBGM ();
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
		sounds.PlayOneShot( onHover );
	}

	void PlayOnClick()
	{
		sounds.PlayOneShot( onClick );
	}

	void PlayPlayerFire()
	{
		sounds.PlayOneShot (playerBulletFire);
	}

	void PlayEnemyFire()
	{
		sounds.PlayOneShot( enemyBulletFire );
	}

	void PlayMenuBGM()
	{
		if (loopingBGM.isPlaying)
			loopingBGM.Stop ();
		loopingBGM.clip = menuBGM;
		loopingBGM.Play ();
	}

	void PlayLevelBGM()
	{
		if (loopingBGM.isPlaying)
			loopingBGM.Stop ();
		loopingBGM.clip = levelBGM;
		loopingBGM.Play ();
	}

	void PlayNarrativeBGM()
	{
		if (loopingBGM.isPlaying)
			loopingBGM.Stop ();
		loopingBGM.clip = narrationBGM;
		loopingBGM.Play ();
	}
}
