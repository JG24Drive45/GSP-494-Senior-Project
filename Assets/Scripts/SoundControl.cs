using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {

	public void PlaySound(string p_pathFileName)
	{
		audio.clip = (AudioClip)Resources.Load ("Sounds/" + p_pathFileName);
		audio.PlayOneShot (audio.clip);
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (GameObject.Find("SoundManager"));
		PlaySound ("Menu/ButtonHover");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
