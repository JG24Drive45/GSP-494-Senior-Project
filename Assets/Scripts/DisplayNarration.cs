using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Character
{
	public Texture image;
	public string name;
	public Character(Texture pImg, string pName)
	{
		this.image = pImg;
		this.name = pName;
	}
};

//Simple data storage for a piece of narrative - profile image, speaker name, speaker dialogue
class NarrativePiece
{
	public Character speaker;
	public string narration;
	public NarrativePiece(Character pSpeaker, string pNarration)
	{
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
	//Adds a piece of narrative to a scene
	private void AddNarr(SceneNarration pScene, Character pSpeaker, string pNarration)
	{
		pScene.narration.Add (new NarrativePiece (pSpeaker,
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
	public Texture imgBlank;
	public Texture imgDakotaGrey;
	public Texture imgCarsonWarringer;
	public Texture imgJoshHarbor;
	public Texture imgIsabellaIvanova;
	public Texture imgHansBlau;
	public Texture imgHirokoTai;
	public Texture imgJenniferGreenheart;


	//Characters
	private Character charNarrator;
	private Character charCrew;
	private Character charFemNewsRep;
	private Character charMaleMilRep;
	private Character charStaffSergeJenniferGreenheart;
	private Character charSergeCarsonWarringer;
	private Character charPrivDakotaGrey;
	private Character charSpecJoshuaHarbor;
	private Character charPrivIsabellaIsanova;
	private Character charPrivHansBlau;
	private Character charSpecHirokoTai;

	//Narrative destination shortcuts
	private string mainMenu = "MainMenu";
	private string levelSelect = "LevelSelect";
	private string level1 = "Level1";
	private string level2 = "Level2";
	private string level3 = "Level3";
	private string level4 = "Level4";
	private string level5 = "Level5";
	private string level6 = "Level6";

	private SceneNarration currentScene = new SceneNarration();

	// Use this for initialization
	void Awake ()
	{
		charNarrator = new Character (imgBlank, "Narrator");
		charCrew = new Character (imgBlank, "Crew");
		charFemNewsRep = new Character (imgBlank, "Female News Reporter");
		charMaleMilRep = new Character (imgBlank, "Male Military Representative");
		charStaffSergeJenniferGreenheart = new Character (imgJenniferGreenheart, "Staff Sergeant Jennifer Greenheart");
		charSergeCarsonWarringer = new Character (imgCarsonWarringer, "Sergeant Carson Warringer");
		charPrivDakotaGrey = new Character (imgDakotaGrey, "Private Dakota Grey");
		charSpecJoshuaHarbor = new Character (imgJoshHarbor, "Specialist Joshua Harbor");
		charPrivIsabellaIsanova = new Character (imgIsabellaIvanova, "Private Isabella Isanova");
		charPrivHansBlau = new Character (imgHansBlau, "Private Hans Blau");
		charSpecHirokoTai = new Character (imgHirokoTai, "Specialist Hiroko Tai");

		//Setting box dimensions
		narrationBox.xMin = 0;
		narrationBox.xMax = Screen.width;
		narrationBox.yMin = (Screen.height - (Screen.height / 5));
		narrationBox.yMax = Screen.height;
		speakerBox.xMin = 0;
		speakerBox.xMax = Screen.width - (Screen.width/4) - 1;
		speakerBox.yMin = narrationBox.yMin - (Screen.height / 15);
		speakerBox.yMax = speakerBox.yMin + (Screen.height / 20);
		float profileWidth = 1324;
		float profileHeight = 1648;
		imageBox.xMin = 20;
		imageBox.yMax = speakerBox.yMin;
		//This finds the ratio between the height of the profile image and the height space remaining
		float profileToSpaceHeightRatio = profileHeight / (imageBox.yMax);
		//Divide the profile's width and height by the height ratio to ensure the image fits the height space
		//Height is used due to it being a taller than wide image
		//The same ratio is used for both to maintain the aspect ratio of the image
		imageBox.xMax = imageBox.xMin + (int)(profileWidth/(profileToSpaceHeightRatio));
		imageBox.yMin = imageBox.yMax - (int)(profileHeight/(profileToSpaceHeightRatio));
		skipBox.xMin = speakerBox.xMax + 1;
		skipBox.xMax = Screen.width;
		skipBox.yMin = speakerBox.yMin;
		skipBox.yMax = speakerBox.yMax;
		float width = 539;
		float height = 404;
		float oldNewWidthRatio = width / (float)Screen.width;
		float oldNewHeightRatio = height / (float)Screen.height;
		boxStyle.fontSize = (int)(boxStyle.fontSize / oldNewHeightRatio);
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
			         charFemNewsRep,
			         "The Federation of Humanity claim to have found a " +
			         "source of ‘X01’, the ingredient necessary for creating the " +
			         "antidote to Gymna, the deadly disease that has spread " +
			         "throughout the planets of humanity.");
			AddNarr (currentScene,
			         charFemNewsRep,
			         "Unfortunately, the source is already being utilized " +
			         "by an alien race with a population fifty times larger " +
			         "than humanity’s.");
			AddNarr (currentScene,
			         charFemNewsRep,
			         "The FoH attempted peaceful negotiations with the alien " +
			         "race, but they fell through. The FoH declared war shortly " +
			         "after, claiming that it was the only way to save the human " +
			         "race from this terrible disease and the greed of these aliens.");
			AddNarr (currentScene,
			         charFemNewsRep,
			         "We have with us a representative from the military " +
					 "to explain what the FoH's goals are with this war.");
			AddNarr (currentScene,
			         charMaleMilRep,
			         "The alien race actually uses the mineral to construct " +
			         "their ships and other mechanical structures, so the primary " +
			         "goal is the neutralization and scrapping of these structures.");
			AddNarr (currentScene,
			         charMaleMilRep,
			         "The FoH is still looking for new recruits to help save " +
					 "humanity by fighting against the large armadas of our foes.");
			AddNarr (currentScene,
			         charPrivDakotaGrey,
			         "I decided to join the war effort shortly after hearing that " +
			         "report. It wasn’t a difficult decision, seeing as most of " +
			         "my family had already been infected with Gymna. I had a " +
			         "letter sent to them, since they couldn’t be let out of " +
			         "quarantine. I’m sure they understand. There’s not much " +
			         "point in going on if everybody I know is dead by the end " +
			         "of the year. Besides… the FoH says this war can save them. " +
			         "I need to do my part… Ah. Someone’s coming.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "A pleasant-looking man stands in front of you and your " +
			         "squad with his arms folded. He begins to speak with a " +
			         "warm voice.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Welcome, soldiers. I am Sergeant Carson Warringer. You may " +
			         "address me as ‘Sergeant’, ‘Sergeant Warringer’, or 'sir'. I will " +
			         "be giving you all your orders from here on.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Sergeant Warringer steps closer to the man farthest to the left, " +
					 "then announces, \"You will introduce yourselves now. Who are you and why are you here?\"");
			AddNarr (currentScene,
			         charSpecJoshuaHarbor,
			         "Specialist Joshua Harbor, sir! The ships the military uses " +
			         "are fascinating, and I truly enjoy having the chance to " +
			         "work on them at the benefit of humanity.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Sergeant Warringer nods, then steps closer to the woman " +
			         "to the right of Joshua.");
			AddNarr (currentScene,
			         charSpecHirokoTai,
			         "Specialist Hiroko Tai, sir. I want to keep my team happy " +
			         "and healthy.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Sergeant Warringer nods, then steps closer to the young " +
			         "man to the right of Hiroko and to the left of you.");
			AddNarr (currentScene,
			         charPrivHansBlau,
			         "Private Hans Blau, sir. Military blood runs in the family, " +
			         "so it was obvious I’d join and do them proud.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Sergeant Warringer nods, then steps in front of you.");
			AddNarr (currentScene,
			        charPrivDakotaGrey,
			        "Private Dakota Grey, sir. I joined the war because I want " +
			        "to help save my loved ones from Gymna.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Sergeant Warringer nods, then steps closer to the young " +
			         "woman last in line.");
			AddNarr (currentScene,
			         charPrivIsabellaIsanova,
			         "Private Isabella Ivanova, sir. My family died to Gymna. " +
			         "Without a place to call home, the military seemed like " +
			         "the best option.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Sergeant Warringer simply nods one last time, then steps " +
			         "back to his original position.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
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
			         charSergeCarsonWarringer,
			         "So as to familiarize you all with your comrades’ roles " +
			         "on-board, I will be re-stating the areas you have trained " +
			         "for. I will of course be commanding. Private Dakota Grey " +
			         "will be handling communications.");
			AddNarr (currentScene,
			         charPrivDakotaGrey,
			         "Yes, sir.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Private Hans Blau will be directing our weapons.");
			AddNarr (currentScene,
			        charPrivHansBlau,
			        "Yes, sir!");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Private Isabella Isanova will be doing shield calculations.");
			AddNarr (currentScene,
			         charPrivIsabellaIsanova,
			         "Yes, sir.");
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Specialist Joshua Harbor will be with the engines.");
			AddNarr (currentScene,
			        charSpecJoshuaHarbor,
			        "Yessir!");
			AddNarr (currentScene,
			        charSergeCarsonWarringer,
			        "And finally, Specialist Hiroko Tai will be on standby to " +
			        "monitor the physical and mental state of the crew.");
			AddNarr (currentScene,
			        charSpecHirokoTai,
			        "Yes, sir.");
			AddNarr (currentScene,
			        charSergeCarsonWarringer,
			        "Good. Battle stations, soldiers.");
			currentScene.destination = level1;
			break;
		case 2:
			//Level 1 post-scene
			AddNarr (currentScene,
			         charSergeCarsonWarringer,
			         "Good work. Specialist Tai will now be performing a " +
			         "routine checkup on you all. You are dismissed when she " +
			         "is done.");
			AddNarr (currentScene,
			        charSpecHirokoTai,
			        "Hiroko goes from person to person, checking different body " +
			        "parts and asking questions regarding your mental states.");
			AddNarr (currentScene,
			        charCrew,
			        "You and the rest of the crew head to the cafeteria after " +
			        "Hiroko confirms everyone's health.");
			AddNarr (currentScene,
			        charPrivHansBlau,
			        "That was amazing. Did you see how many enemy crafts we " +
			        "went up against?");
			AddNarr (currentScene,
			        charPrivDakotaGrey,
			        "It really did seem too exaggerated. One of us, with an " +
			        "overwhelming technological advantage, against such a large " +
			        "force of enemies?");
			AddNarr (currentScene,
			        charSpecJoshuaHarbor,
			        "Well, I was informed that our fleet has a technological " +
			        "advantage over the enemy, but it shouldn’t be so " +
			        "extraordinary when you consider the size of their fleet.");
			AddNarr (currentScene,
			        charPrivHansBlau,
			        "Fine by me. A higher kill count will impress the top brass.");
			AddNarr (currentScene,
			        charPrivIsabellaIsanova,
			        "Maybe it’s to prepare us for the worst..?");
			AddNarr (currentScene,
			        charPrivDakotaGrey,
			        "We had too much of an advantage for that to be the worst, " +
			        "but we’ll see when we really get into battle, I suppose.");
			currentScene.destination = mainMenu;
			break;
		case 3:
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "You've all been gathered because it's time to enter your first battle at the outskirts of" +
			        "the war zone. Just because these are not the front lines, does not mean you are not at risk." +
			        "Be careful. Stay safe. Fight for the sake of humanity...");
			AddNarr(currentScene,
			        charCrew,
			        "Yes, sir!");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Battle stations, soldiers.");
			currentScene.destination = level2;
			break;
		case 4:
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Carson heaves a sigh of relief as you all return.");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "I cannot overstate my joy and satisfaction with your performance and with your safe return. You" +
			        "have done well, and I expect you all to continue to do well. That is all. Dismissed.");
			AddNarr(currentScene,
			        charNarrator,
			        "Later, in the cafeteria...");
			AddNarr(currentScene,
			        charPrivHansBlau,
			        "So... does anybody else think that serge is a bit too... soft?");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "Soft? I think he is a kind man who does not want those around him to die.");
			AddNarr (currentScene,
			         charPrivIsabellaIsanova,
			         "Isabella nods and says, \"I can relate to the fear of losing people...\"");
			AddNarr(currentScene,
			        charPrivHansBlau,
			        "Mm... still, this is war, and people will die. We kill them, they kill us. That's how it works." +
			        "Just hope we kill a lot more... And with how many there are, we need to kill a LOT more.");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "On that note, I want to remind everybody that we were clearly outnumbered again, but we pulled " +
			        "through due to our overwhelming technological advantage.");
			AddNarr(currentScene,
			        charPrivHansBlau,
			        "Hey, don't be so dismissive of my mastery of the weapons system. And Isabella's been doing " +
			        "alright with the shields.");
			AddNarr(currentScene,
			        charPrivIsabellaIsanova,
			        "Isabella remains silent.");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "Dakota sighs and says, \"I guess...\"");
			currentScene.destination = mainMenu;
			break;
		case 5:
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Alright, everybody. We'll be moving deeper into enemy territory for this mission. " +
			        "You will be facing a large amount of enemies, but I hae high hopes you will all " +
			        "come back unharmed. You know the drill - battle stations, soldiers.");
			currentScene.destination = level3;
			break;
		case 6:
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "You look out over the field after the adrenalie of battle has sbsided, realizing " +
			        "the horrific field of sharpnel and corpses littered about. You can't help but mutter " +
			        "in awe, \"Good god...\"");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "What's wrong, private?");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "...is this even war?");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Clarify yourself, private.");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "Looks more like a massacre...");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "After a pause, Carson brings Specialist Tai closer. \"Have Dakota brought in for " +
			        "therapy after we're done here, Specialist.\"");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "Yes, sir.");
			currentScene.destination = mainMenu;
			break;
		case 7:
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "So here I am, sitting in Hiroko's office, waiting. She called me out after the " +
			        "battle for an examination of some sort.");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "Hiroko walks in with a smile and a clipboard, and then sits in the chair opposite you.");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "So, how are you doing, Private Dakota?");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "I'm fine, I suppose. I've sustained no injuries in combat, of course.");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "Hiroko nods, and then says, \"Of course. But how are you feeling after the last battle?\"");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "I've been having doubts, I guess. About this 'war'. It feels more like a slaughtering...");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "Hiroko nods, and then says, \"Not all wars are fought equally. One side is bound to have " +
			        "an advantage. We should feel fortunate that we are on that side, able to fight to save " +
			        "our people.");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "But if we have such an advantage, why would they not give in to our demands? Surely anybody " +
			        "would know not to anger a group with more power and a cause to fight.");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "Hiroko thinks for a moment before stating, \"Only they know the answer to that question. " +
			        "Their cultures and beliefs are so unknown to us. Maybe they would rather die fighting " +
			        "than help others. It is unfortunate, but I'm sure the higher-ups would not drag us into " +
			        "a war unless it was necessary.");
			AddNarr(currentScene,
			        charNarrator,
			        "The two of you sit in silence for a bit, reflecting on what was said. For now, you " +
			        "have to accept the situation. Hiroko makes good points, and there's no evidence against " +
			        "what she says.");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "Alright. I understand. Thank you for your time and help.");
			AddNarr(currentScene,
			        charSpecHirokoTai,
			        "Hiroko smiles. \"It's my pleasure. You are dismissed until the next battle, now, private.");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "It wasn't long after that discussion that a set of familiar words reached my ears again. " +
			        "\"Battle stations, soldiers.\"");
			currentScene.destination = level4;
			break;
		case 8:
			AddNarr(currentScene,
			        charNarrator,
			        "After the battle, the crew is preparing to leave battle stations, when something " +
			        "suddenly shows up on radar.");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Focus, crew, we're not out of it yet. Private Grey, identify the inco-");
			AddNarr(currentScene,
			        charNarrator,
			        "Sergeant Carson is cut off by a sudden blast to the ship's hull.");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Isanova, focus! Do not let another one by!");
			AddNarr(currentScene,
			        charPrivIsabellaIsanova,
			        "Yes, sir!");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Blau, aim and fire at will!");
			AddNarr(currentScene,
			        charPrivHansBlau,
			        "Yes, sir!");
			AddNarr(currentScene,
			        charNarrator,
			        "The enemy is swiftly dealt with, but the ship is unfit for battle until the damage " +
			        "can be repaired.");
			currentScene.destination = mainMenu;
			break;
		case 9:
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Carson stands before the crew and begins his announcement. \"Due to the lack of " +
			        "preparation for an incoming attack, a mistake that lead to unnecessary daage to the " +
			        "ship, which has now been prepared, Staff Sergeant Greenheart will be watching over " +
			        "the crew via video and audio feed for this next mission.\"");
			AddNarr(currentScene,
			        charStaffSergeJenniferGreenheart,
			        "A woman's profile comes up on screen. \"I expect no less than excellence " +
			        "and no excuse for failure. Battle stations, soldiers.\"");
			currentScene.destination = level5;
			break;
		case 10:
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "Search the wreckage of the battlefield for ships still operating. We must avoid " +
			        "another ambush.");
			AddNarr(currentScene,
			        charNarrator,
			        "While searching the field, a transmission is received and heard by the crew. The " +
			        "voice sounds... slimy, and its speech is in broken English. \"Please. Stop hunting. " +
			        "We surrender X01 we carry.\"");
			AddNarr(currentScene,
			        charStaffSergeJenniferGreenheart,
			        "Shut off the transmission!");
			AddNarr(currentScene,
			        charNarrator,
			        "You are locked in fear and confusion as the alien voice continues, \"Please. Surrender. " +
			        "Peace. Mercy.\"");
			AddNarr(currentScene,
			        charStaffSergeJenniferGreenheart,
			        "Private Grey, SHUT OFF THAT TRANSMISSION. Find the source n-");
			AddNarr(currentScene,
			        charNarrator,
			        "Greenheart's shouting is cut off by an explosion in the room. Apparently, you were not " +
			        "the only one shocked by the alien's voice, as the shields were once again open...");
			currentScene.destination = mainMenu;
			break;
		case 11:
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "The rest of the situation is a blur, but we somehow made it out, likely with Greenheart's " +
			        "guidance. Private Hans Blau's inures from the impact were fatal. We were forced to undergo " +
			        "psychiatric treatment with Hiroko, as well as going through basic training again once we were " +
			        "all cleared.");
			AddNarr(currentScene,
			        charPrivDakotaGrey,
			        "Isabella needed some extra time to get through that... seems she can't help but blame herself " +
			        "for not having the shields ready. It's not her fault, though. We all messed up. I hope she " +
			        "understands that now. She's not alone in her guilt. We had a meeting with Sergeant Warringer, " +
			        "with Staff Sergeant Greenheart using digital means to join us shortly after we were all cleared.");
			AddNarr(currentScene,
			        charStaffSergeJenniferGreenheart,
			        "The man before you is Specialist Geoffrey Gordon. He has earned his rank after serving and " +
			        "and excelling as a weapons operator for two years. He will be replacing Private Blau as your" +
			        "crew's weapons operator. I expect his skill will up the performance levels of your squad.");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "As you can see, Specialist Gordon comes highly regarded by Staff Sergeant Greenheart. You " +
			        "will all be going through integration training to ensure you will work effectly as a team. Dismissed.");
			AddNarr(currentScene,
			        charNarrator,
			        "After integration training, where Geoffrey was able to show off how much better than us he " +
			        "believes he is, we were called in for another meeting with Sergeant Warringer and " +
			        "Staff Sergeant Greenheart.");
			AddNarr(currentScene,
			        charStaffSergeJenniferGreenheart,
			        "The war has been winding down while you were all coping. You will be seeing one last battle, " +
			        "though. You should be grateful to have this chance to redeem your failures, especially with " +
			        "the help of such a highly-skilled soldier.");
			AddNarr(currentScene,
			        charSergeCarsonWarringer,
			        "After some silence from the crew, Sergeant Warringer thanked Staff Sergeant Greenheart. " +
			        "After she left, his facial features sunk. He was going to have to order it once again. " +
			        "Hopefully this would be the last time. \"Battle stations, soldiers.\"");
			currentScene.destination = level6;
			break;
		case 12:
			if (PlayerSettingsScript.totalDebris <= 60000)
			{
				AddNarr (currentScene,
				         charNarrator,
				         "Without gathering enough scrap, the disease overcame humanity. It was too late now. " +
				         "No amount of X01 would save us. The governments of the Federation took what they had gained " +
				         "and isolated themselves from the infected to let them die without risk of it spreading. " +
				         "The war was for nothing.");
			}
			else
			{
				AddNarr(currentScene,
				        charNarrator,
				        "With the amount of scrap gathered, the governments of the Federation were able to " +
				        "create enough of the cure to eradicate the disease. Your family was saved. Your friends " +
				        "were saved. In the process, your comrade died. Many more died without you ever meeting them. " +
				        "The enemy, or target, or whatever they were - they died, too. Was it all worth it?");
			}
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
		GUI.Label (speakerBox, currentScene.narration[narrativeIndex].speaker.name, nameBoxStyle);
		//Draw the speaker's profile image
		GUI.DrawTexture (imageBox, currentScene.narration[narrativeIndex].speaker.image);
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
