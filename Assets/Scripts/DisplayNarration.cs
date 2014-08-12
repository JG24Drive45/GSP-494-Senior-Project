using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class NarrativePiece
{
	public string speaker;
	public string narration;
	public NarrativePiece(string pSpeaker, string pNarration)
	{
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

	private Rect speakerBox;
	private Rect narrationBox;

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
		scene1.narration.Add (new NarrativePiece("Staff Sergeant Jennifer Greenheart",
		                                        "Get to work, welp!")
		        );
		scene1.narration.Add (new NarrativePiece ("Private Dakota Grey",
		                                         "Yes, ma'am!")
		        );
		gameNarrative.Add (scene1);
		scene2.narration.Add (new NarrativePiece ("Staff Sergeant Dakota Grey",
		                                        "Wait.. I'm in charge now..? MUAHAHAHAHA. LICK MY BOOT, PRIVATE!")
				);
		scene2.narration.Add (new NarrativePiece ("Private Jennifer Green",
		                                        ";_;")
				);
		scene2.narration.Add (new NarrativePiece ("Narrator",
		                                         "Get your fanfic pens out..")
				);
		gameNarrative.Add (scene2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (speakerBox, gameNarrative[sceneID].narration[narrativeIndex].speaker, boxStyle);
		//GUI.Label (narrationBox, sceneNarrative[narrativeIndex].narration, boxStyle);
		if (GUI.Button (narrationBox, gameNarrative[sceneID].narration[narrativeIndex].narration, boxStyle))
		{
			if (narrativeIndex+1 < gameNarrative[sceneID].narration.Count)
				narrativeIndex++;
		}
	}
}
