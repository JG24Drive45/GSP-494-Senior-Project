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

	//Style of the boxes
	public GUIStyle boxStyle;
	//Style of the skip box
	private GUIStyle skipBoxStyle;

	//Current scene to display
	private int sceneID;
	//Current line of dialogue to display
	private int narrativeIndex = 0;

	//Profile image name shortcuts
	private string imgBlank = "Craine Sprite";
	private string imgDakota = "Craine Sprite";
	private string imgWarringer = "Craine Sprite";
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

	//Level name shortcuts
	private string levelSelect = "LevelSelect";
	private string level1 = "Level1";

	//Full list of the game's narrative
	private List<SceneNarration> gameNarrative = new List<SceneNarration>();
	//Individual scenes
	private SceneNarration sceneIntro = new SceneNarration();
	private SceneNarration sceneLvl1Open =  new SceneNarration();
	private SceneNarration sceneLvl1Close = new SceneNarration();

	// Use this for initialization
	void Start ()
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
		//Skip box has same style to other boxes, but is centered
		skipBoxStyle = new GUIStyle (boxStyle);
		skipBoxStyle.alignment = TextAnchor.UpperCenter;

		AddNarr (sceneIntro,
		         imgBlank,
		         nameFemale + nameNewsRep,
		         "The Federation of Humanity claim to have found a " +
		         "source of ‘X01’, the ingredient necessary for creating the " +
		         "antidote to Gymna, the deadly disease that has spread " +
		         "throughout the planets of humanity");
		AddNarr (sceneIntro,
		         imgBlank,
		         nameFemale + nameNewsRep,
		         "Unfortunately, the source is already being utilized " +
		         "by an alien race with a population fifty times larger " +
		         "than humanity’s.");
		AddNarr (sceneIntro,
		         imgBlank,
		         nameFemale + nameNewsRep,
		         "The FoH attempted peaceful negotiations with the alien " +
		         "race, but they fell through. The FoH declared war shortly " +
		         "after, claiming that it was the only way to save the human " +
		         "race from this terrible disease and the greed of these aliens.");
		AddNarr (sceneIntro,
		         imgBlank,
		         nameFemale + nameNewsRep,
		         "We have with us a representative from the military" +
				 "to explain what the FoH's goals are with this war.");
		AddNarr (sceneIntro,
		         imgBlank,
		         nameMale + nameMilRep,
		         "The alien race actually uses the mineral to construct " +
		         "their ships and other mechanical structures, so the primary " +
		         "goal is the neutralization and scrapping of these structures.");
		AddNarr (sceneIntro,
		         imgBlank,
		         nameMale + nameMilRep,
		         "The FoH is still looking for new recruits to help save" +
				 "humanity by fighting against the large armadas of our foes.");
		AddNarr (sceneIntro,
		         imgDakota,
		         namePrivDakota,
		         "I decided to join the war effort shortly after hearing that " +
		         "report. It wasn’t a difficult decision, seeing as most of " +
		         "my family had already been infected with Gymna. I had a " +
		         "letter sent to them, since they couldn’t be let out of " +
		         "quarantine. I’m sure they understand. There’s not much " +
		         "point in going on if everybody I know is dead by the end " +
		         "of the year. Besides… the FoH says this war can save them. " +
		         "I need to do my part… Ah. Someone’s coming.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameNone,
		         "A pleasant-looking man stands in front of you and your " +
		         "squad with his arms folded. He begins to speak with a " +
		         "warm voice.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Welcome, soldiers. I am Sergeant Carson Warringer. You may " +
		         "address me as ‘Sergeant’, ‘Sergeant Warringer’, or 'sir'. I will " +
		         "be giving you all your orders from here on.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Sergeant Warringer steps closer to the man farthest to the left," +
				 "then announces, \"You will introduce yourselves now. Who are you and why are you here?\"");
		AddNarr (sceneIntro,
		         imgJoshHarbor,
		         nameSpecJoshua,
		         "Specialist Joshua Harbor, sir! The ships the military uses " +
		         "are fascinating, and I truly enjoy having the chance to " +
		         "work on them at the benefit of humanity.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Sergeant Warringer nods, then steps closer to the woman " +
		         "to the right of Joshua.");
		AddNarr (sceneIntro,
		         imgHirokoTai,
		         nameSpecHiroko,
		         "Specialist Hiroko Tai, sir. I want to keep my team happy " +
		         "and healthy.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Sergeant Warringer nods, then steps closer to the young " +
		         "man to the right of Hiroko and to the left of you.");
		AddNarr (sceneIntro,
		         imgHansBlau,
		         namePrivHans,
		         "Private Hans Blau, sir. Military blood runs in the family, " +
		         "so it was obvious I’d join and do them proud.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Sergeant Warringer nods, then steps in front of you.");
		AddNarr (sceneIntro,
		        imgDakota,
		        namePrivDakota,
		        "Private Dakota Grey, sir. I joined the war because I want " +
		        "to help save my loved ones from Gymna.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Sergeant Warringer nods, then steps closer to the young " +
		         "woman last in line.");
		AddNarr (sceneIntro,
		         imgIsabellaIvanova,
		         namePrivIsabella,
		         "Private Isabella Ivanova, sir. My family died to Gymna. " +
		         "Without a place to call home, the military seemed like " +
		         "the best option.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Sergeant Warringer simply nods one last time, then steps " +
		         "back to his original position.");
		AddNarr (sceneIntro,
		         imgWarringer,
		         nameSergWarringer,
		         "Good. Now that you all know why your allies are fighting, " +
		         "I hope that you can respect those reasons. You need to " +
		         "respect and trust each other to become respected and " +
		         "trustworthy soldiers. That is all for now. You have been " +
		         "given a tour of the facility. You will go through a" +
		         "basic training simulation as a team tomorrow at 0800 hours. You are " +
		         "free until then. Do not be late. Dismissed.");
		sceneIntro.destination = levelSelect;
		gameNarrative.Add (sceneIntro);

		AddNarr (sceneLvl1Open,
		         imgBlank,
		         nameNone,
		         "This is placeholder text for level 1's opening scene.");
		sceneLvl1Open.destination = level1;
		gameNarrative.Add (sceneLvl1Open);

		AddNarr (sceneLvl1Close,
		         imgBlank,
		         nameNone,
		         "This is placeholder text for level 1's closing scene.");
		sceneLvl1Close.destination = levelSelect;
		gameNarrative.Add (sceneLvl1Close);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		//Draw the speaker's box and name
		GUI.Label (speakerBox, gameNarrative[sceneID].narration[narrativeIndex].speaker, boxStyle);
		//Draw the speaker's profile image
		GUI.DrawTexture (imageBox, gameNarrative [sceneID].narration [narrativeIndex].image);
		//Draw the dialogue box as a button which, if left-clicked, advances the scene
		if (GUI.Button (narrationBox, gameNarrative[sceneID].narration[narrativeIndex].narration, boxStyle))
		{
			if (Event.current.button == 0)
			{
				if (narrativeIndex+1 < gameNarrative[sceneID].narration.Count)
				{
					narrativeIndex++;
				}
				else
				{
					Application.LoadLevel(gameNarrative[sceneID].destination);
				}
				if (Event.current.button == 1)
				{
					if (narrativeIndex > 0)
					{
						narrativeIndex--;
					}
				}
			}
		}
		if (GUI.Button (skipBox, "Skip", skipBoxStyle))
		{
			narrativeIndex = gameNarrative[sceneID].narration.Count-1;
		}
	}
}
