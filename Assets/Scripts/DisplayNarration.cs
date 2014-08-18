using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class NarrativePiece
{
	public Texture image;
	public string speaker;
	public string narration;
	public NarrativePiece(Texture pImg, string pSpeaker, string pNarration)
	{
		this.image = pImg;
		this.speaker = pSpeaker;
		this.narration = pNarration;
	}
};

class SceneNarration
{
	public List<NarrativePiece> narration;
	public SceneNarration()
	{
		this.narration = new List<NarrativePiece> ();
	}
};

public class DisplayNarration : MonoBehaviour
{

	private Texture GrabImg(string pFileName)
	{
		return (Texture)Resources.Load("Art/Character Profile Images/" + pFileName);
	}

	private void AddNarr(SceneNarration pScene, string pImg, string pSpeaker, string pNarration)
	{
		pScene.narration.Add (new NarrativePiece (GrabImg (pImg),
		                                         pSpeaker,
		                                         pNarration)
		                      );
	}

	private Rect speakerBox;
	private Rect narrationBox;
	private Rect imageBox;

	public GUIStyle boxStyle;

	public int sceneID;
	private int narrativeIndex = 0;

	private List<SceneNarration> gameNarrative = new List<SceneNarration>();
	private SceneNarration scene1 = new SceneNarration();
	private SceneNarration scene2 = new SceneNarration();
	// Use this for initialization
	void Start ()
	{
		narrationBox.xMin = 0;
		narrationBox.xMax = Screen.width;
		narrationBox.yMin = (Screen.height - (Screen.height / 5));
		narrationBox.yMax = Screen.height;
		speakerBox.xMin = 0;
		speakerBox.xMax = Screen.width;
		speakerBox.yMin = narrationBox.yMin - (Screen.height / 15);
		speakerBox.yMax = speakerBox.yMin + (Screen.height / 20);
		imageBox.xMin = Screen.width / 20;
		imageBox.xMax = imageBox.xMin + (Screen.width / 5);
		imageBox.yMax = speakerBox.yMin;
		imageBox.yMin = imageBox.yMax - (Screen.height / 2);

		AddNarr (scene1,
		         "Craine Sprite",
		         "Staff Sergeant Jennifer Greenheart",
		         "Get to work, welp!");
		AddNarr (scene1,
		         "Craine Sprite",
				 "Private Dakota Grey",
				 "Yes, ma'am!");
		gameNarrative.Add (scene1);

		AddNarr (scene2,
		         "Craine Sprite",
		         "Staff Sergeant Dakota Grey",
		         "Wait.. I'm in charge now..? MUAHAHAHAHA. LICK MY BOOT, PRIVATE!");
		AddNarr (scene2,
		         "Craine Sprite",
		         "Private Jennifer Green",
		         ";_;");
		AddNarr (scene2,
		         "Craine Sprite",
		         "Narrator",
		         "Get your fanfic pens out..");
		gameNarrative.Add (scene2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (speakerBox, gameNarrative[sceneID].narration[narrativeIndex].speaker, boxStyle);
		GUI.DrawTexture (imageBox, gameNarrative [sceneID].narration [narrativeIndex].image);
		if (GUI.Button (narrationBox, gameNarrative[sceneID].narration[narrativeIndex].narration, boxStyle))
		{
			if (narrativeIndex+1 < gameNarrative[sceneID].narration.Count)
				narrativeIndex++;
		}
	}
}
