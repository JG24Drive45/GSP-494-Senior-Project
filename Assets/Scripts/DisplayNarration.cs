using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Simple data storage for a piece of narrative - profile image, speaker name, speaker dialogue
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

//Simple data storage for a scene - list of NarrativePieces, level destination at end of scene
class SceneNarration
{
	public string destination;
	public List<NarrativePiece> narration;
	public SceneNarration()
	{
		this.narration = new List<NarrativePiece> ();
	}
};

public class DisplayNarration : MonoBehaviour
{
	//Loads an image as needed (may be substituted for public Textures later)
	private Texture GrabImg(string pFileName)
	{
		return (Texture)Resources.Load("Art/Character Profile Images/" + pFileName);
	}
	//Adds a piece of narrative to a scene
	private void AddNarr(SceneNarration pScene, string pImg, string pSpeaker, string pNarration)
	{
		pScene.narration.Add (new NarrativePiece (GrabImg (pImg),
		                                         pSpeaker,
		                                         pNarration)
		                      );
	}

	//Location of speaker's name
	private Rect speakerBox;
	//Location of dialogue box
	private Rect narrationBox;
	//Location of the character's profile image
	private Rect imageBox;
	//Location of skip button
	private Rect skipBox;

	//Template style of the boxes
	public GUIStyle boxStyle;
	//Style of the skip box
	private GUIStyle skipBoxStyle;
	//Style of the name box
	private GUIStyle nameBoxStyle;

	//Current scene to display
	private int sceneID;
	//Current line of dialogue to display
	private int narrativeIndex = 0;

	//Profile image name shortcuts
	private string imgBlank = "Craine Sprite";
	private string imgDakotaGrey = "Craine Sprite";
	private string imgCarsonWarringer = "Craine Sprite";
	private string imgJoshHarbor = "Craine Sprite";
	private string imgIsabellaIvanova = "Craine Sprite";
	private string imgHansBlau = "Craine Sprite";
	private string imgHirokoTai = "Craine Sprite";

	//Character name shortcuts
	private string nameMale = "Male ";
	private string nameFemale = "Female ";
	private string nameNone = "";
	private string nameNarrator = "Narrator";
	private string nameNewsRep = "News Reporter";
	private string nameMilRep = "Military Representative";
	private string nameSergWarringer = "Sergeant Carson Warringer";
	private string namePrivDakota = "Private Dakota Grey";
	private string nameSpecJoshua = "Specialist Joshua Harbor";
	private string namePrivIsabella = "Private Isabella Ivanova";
	private string namePrivHans = "Private Hans Blau";
	private string nameSpecHiroko = "Specialist Hiroko Tai";

	//Narrative destination shortcuts
	private string mainMenu = "MainMenu";
	private string levelSelect = "LevelSelect";
	private string level1 = "Level1";

	private SceneNarration currentScene = new SceneNarration();

	// Use this for initialization
	void Awake ()
	{
		//Setting box dimensions
		narrationBox.xMin = 0;
		narrationBox.xMax = Screen.width;
		narrationBox.yMin = (Screen.height - (Screen.height / 5));
		narrationBox.yMax = Screen.height;
		speakerBox.xMin = 0;
		speakerBox.xMax = Screen.width - (Screen.width/4) - 1;
		speakerBox.yMin = narrationBox.yMin - (Screen.height / 15);
		speakerBox.yMax = speakerBox.yMin + (Screen.height / 20);
		imageBox.xMin = Screen.width / 20;
		imageBox.xMax = imageBox.xMin + (Screen.width / 5);
		imageBox.yMax = speakerBox.yMin;
		imageBox.yMin = imageBox.yMax - (Screen.height / 2);
		skipBox.xMin = speakerBox.xMax + 1;
		skipBox.xMax = Screen.width;
		skipBox.yMin = speakerBox.yMin;
		skipBox.yMax = speakerBox.yMax;
		float width = 539;
		float height = 404;
		float originalRatio = width / height;
		float currentRatio = (float)Screen.width / (float)Screen.height;
		float ratioChange = currentRatio / originalRatio;
		boxStyle.fontSize = (int)(boxStyle.fontSize * ratioChange);
		//Skip box has same style to other boxes, but is centered
		skipBoxStyle = new GUIStyle (boxStyle);
		skipBoxStyle.alignment = TextAnchor.MiddleCenter;
		//Name box has same style as skip box
		nameBoxStyle = new GUIStyle (skipBoxStyle);
		//Current scene gathered from PlayerSettings
		sceneID = PlayerSettingsScript.GetInstance.sceneNum;

		switch(sceneID)
		{
		case 0:
			//Intro scene
			AddNarr (currentScene,
			         imgBlank,
			         nameFemale + nameNewsRep,
			         "The Federation of Humanity claim to have found a " +
			         "source of ‘X01’, the ingredient necessary for creating the " +
			         "antidote to Gymna, the deadly disease that has spread " +
			         "throughout the planets of humanity.");
			AddNarr (currentScene,
			         imgBlank,
			         nameFemale + nameNewsRep,
			         "Unfortunately, the source is already being utilized " +
			         "by an alien race with a population fifty times larger " +
			         "than humanity’s.");
			AddNarr (currentScene,
			         imgBlank,
			         nameFemale + nameNewsRep,
			         "The FoH attempted peaceful negotiations with the alien " +
			         "race, but they fell through. The FoH declared war shortly " +
			         "after, claiming that it was the only way to save the human " +
			         "race from this terrible disease and the greed of these aliens.");
			AddNarr (currentScene,
			         imgBlank,
			         nameFemale + nameNewsRep,
			         "We have with us a representative from the military " +
					 "to explain what the FoH's goals are with this war.");
			AddNarr (currentScene,
			         imgBlank,
			         nameMale + nameMilRep,
			         "The alien race actually uses the mineral to construct " +
			         "their ships and other mechanical structures, so the primary " +
			         "goal is the neutralization and scrapping of these structures.");
			AddNarr (currentScene,
			         imgBlank,
			         nameMale + nameMilRep,
			         "The FoH is still looking for new recruits to help save " +
					 "humanity by fighting against the large armadas of our foes.");
			AddNarr (currentScene,
			         imgDakotaGrey,
			         namePrivDakota,
			         "I decided to join the war effort shortly after hearing that " +
			         "report. It wasn’t a difficult decision, seeing as most of " +
			         "my family had already been infected with Gymna. I had a " +
			         "letter sent to them, since they couldn’t be let out of " +
			         "quarantine. I’m sure they understand. There’s not much " +
			         "point in going on if everybody I know is dead by the end " +
			         "of the year. Besides… the FoH says this war can save them. " +
			         "I need to do my part… Ah. Someone’s coming.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameNone,
			         "A pleasant-looking man stands in front of you and your " +
			         "squad with his arms folded. He begins to speak with a " +
			         "warm voice.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Welcome, soldiers. I am Sergeant Carson Warringer. You may " +
			         "address me as ‘Sergeant’, ‘Sergeant Warringer’, or 'sir'. I will " +
			         "be giving you all your orders from here on.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Sergeant Warringer steps closer to the man farthest to the left, " +
					 "then announces, \"You will introduce yourselves now. Who are you and why are you here?\"");
			AddNarr (currentScene,
			         imgJoshHarbor,
			         nameSpecJoshua,
			         "Specialist Joshua Harbor, sir! The ships the military uses " +
			         "are fascinating, and I truly enjoy having the chance to " +
			         "work on them at the benefit of humanity.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Sergeant Warringer nods, then steps closer to the woman " +
			         "to the right of Joshua.");
			AddNarr (currentScene,
			         imgHirokoTai,
			         nameSpecHiroko,
			         "Specialist Hiroko Tai, sir. I want to keep my team happy " +
			         "and healthy.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Sergeant Warringer nods, then steps closer to the young " +
			         "man to the right of Hiroko and to the left of you.");
			AddNarr (currentScene,
			         imgHansBlau,
			         namePrivHans,
			         "Private Hans Blau, sir. Military blood runs in the family, " +
			         "so it was obvious I’d join and do them proud.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Sergeant Warringer nods, then steps in front of you.");
			AddNarr (currentScene,
			        imgDakotaGrey,
			        namePrivDakota,
			        "Private Dakota Grey, sir. I joined the war because I want " +
			        "to help save my loved ones from Gymna.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Sergeant Warringer nods, then steps closer to the young " +
			         "woman last in line.");
			AddNarr (currentScene,
			         imgIsabellaIvanova,
			         namePrivIsabella,
			         "Private Isabella Ivanova, sir. My family died to Gymna. " +
			         "Without a place to call home, the military seemed like " +
			         "the best option.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Sergeant Warringer simply nods one last time, then steps " +
			         "back to his original position.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Good. Now that you all know why your allies are fighting, " +
			         "I hope that you can respect those reasons. You need to " +
			         "respect and trust each other to become respected and " +
			         "trustworthy soldiers. That is all for now. You have been " +
			         "given a tour of the facility. You will go through a " +
			         "basic training simulation as a team tomorrow at 0800 hours. You are " +
			         "free until then. Do not be late. Dismissed.");
			currentScene.destination = mainMenu;
			break;
		case 1:
			//Level 1 pre-scene
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "So as to familiarize you all with your comrades’ roles " +
			         "on-board, I will be re-stating the areas you have trained " +
			         "for. I will of course be commanding. Private Dakota Grey " +
			         "will be handling communications.");
			AddNarr (currentScene,
			         imgDakotaGrey,
			         namePrivDakota,
			         "Yes, sir.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Private Hans Blau will be directing our weapons.");
			AddNarr (currentScene,
			        imgHansBlau,
			        namePrivHans,
			        "Yes, sir!");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Private Isabella Isanova will be doing shield calculations.");
			AddNarr (currentScene,
			         imgIsabellaIvanova,
			         namePrivIsabella,
			         "Yes, sir.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Specialist Joshua Harbor will be with the engines.");
			AddNarr (currentScene,
			        imgJoshHarbor,
			        nameSpecJoshua,
			        "Yessir!");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			        nameSergWarringer,
			        "And finally, Specialist Hiroko Tai will be on standby to " +
			        "monitor the physical and mental state of the crew.");
			AddNarr (currentScene,
			        imgHirokoTai,
			        nameSpecHiroko,
			        "Yes, sir.");
			AddNarr (currentScene,
			         imgCarsonWarringer,
			        nameSergWarringer,
			        "Good. Battle stations, soldiers.");
			currentScene.destination = level1;
			break;
		case 2:
			//Level 1 post-scene
			AddNarr (currentScene,
			         imgCarsonWarringer,
			         nameSergWarringer,
			         "Good work. Specialist Tai will now be performing a " +
			         "routine checkup on you all. You are dismissed when she " +
			         "is done.");
			AddNarr (currentScene,
			        imgHirokoTai,
			        nameNone,
			        "Hiroko goes from person to person, checking different body " +
			        "parts and asking questions regarding your mental states.");
			AddNarr (currentScene,
			        imgBlank,
			        nameNone,
			        "You and the rest of the crew head to the cafeteria after " +
			        "Hiroko confirms everyone's health.");
			AddNarr (currentScene,
			        imgHansBlau,
			        namePrivHans,
			        "That was amazing. Did you see how many enemy crafts we " +
			        "went up against?");
			AddNarr (currentScene,
			        imgDakotaGrey,
			        namePrivDakota,
			        "It really did seem too exaggerated. One of us, with an " +
			        "overwhelming technological advantage, against such a large " +
			        "force of enemies?");
			AddNarr (currentScene,
			        imgJoshHarbor,
			        nameSpecJoshua,
			        "Well, I was informed that our fleet has a technological " +
			        "advantage over the enemy, but it shouldn’t be so " +
			        "extraordinary when you consider the size of their fleet.");
			AddNarr (currentScene,
			        imgHansBlau,
			        namePrivHans,
			        "Fine by me. A higher kill count will impress the top brass.");
			AddNarr (currentScene,
			        imgIsabellaIvanova,
			        namePrivIsabella,
			        "Maybe it’s to prepare us for the worst..?");
			AddNarr (currentScene,
			        imgDakotaGrey,
			        namePrivDakota,
			        "We had too much of an advantage for that to be the worst, " +
			        "but we’ll see when we really get into battle, I suppose.");
			currentScene.destination = mainMenu;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		//Draw the speaker's box and name
		GUI.Label (speakerBox, currentScene.narration[narrativeIndex].speaker, nameBoxStyle);
		//Draw the speaker's profile image
		GUI.DrawTexture (imageBox, currentScene.narration [narrativeIndex].image);
		//Draw the dialogue box as a button which, if left-clicked, advances the scene
		if (GUI.Button (narrationBox, currentScene.narration[narrativeIndex].narration, boxStyle))
		{
			if (Event.current.button == 0)
			{
				if (narrativeIndex+1 < currentScene.narration.Count)
				{
					narrativeIndex++;
				}
				else
				{
					Application.LoadLevel(currentScene.destination);
				}
			}
			if (Event.current.button == 1)
			{
				if (narrativeIndex > 0)
				{
					narrativeIndex--;
				}
			}
		}
		if (GUI.Button (skipBox, "Skip", skipBoxStyle))
		{
			narrativeIndex = currentScene.narration.Count-1;
		}
	}
}
