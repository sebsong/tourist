using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cradle;
using Cradle.StoryFormats.Harlowe;
//using Cradle.StoryFormats.Harlowe;

public class DialogueControllerTwine : MonoBehaviour {
	private static NPCControllerTwine npc;

	private static GameObject dialogueUI;
	private static Text dialogueUIText;

	private static Image playerUIImage;
	private static Image npcUIImage;

	private static Story currentStory;
	private static bool interacting;

	private static bool isPlayer;
	private static bool isEnd;

    private static Color playerTextColor;
    private static Color npcTextColor;

	// Use this for initialization
	void Start () {
		dialogueUI = GameObject.FindGameObjectWithTag ("dialogue_ui");
		dialogueUIText = GameObject.FindGameObjectWithTag ("dialogue_ui_text").GetComponent<Text> ();

		playerUIImage = GameObject.FindGameObjectWithTag ("player_ui_img").GetComponent<Image> ();
		npcUIImage = GameObject.FindGameObjectWithTag ("npc_ui_img").GetComponent<Image> ();
		dialogueUI.SetActive (false);

		isPlayer = false;
		isEnd = false;

        playerTextColor = new Color(33f/255, 136f/255, 178f/255, 1f);
        npcTextColor = new Color(112f/255, 54f/255, 97f/255, 1f);
	}

	// Update is called once per frame
	void Update () {
		if (interacting) {
			if (Input.anyKeyDown) {
				ContinueInteraction ();
			}
		}
	}

	private static void ContinueInteraction () {
		Image currSpeaker;
		Image otherSpeaker;

		StoryPassage passage;
		IEnumerable<StoryLink> links;
		string link;
		string[] tags;

		links = currentStory.GetCurrentLinks ();
		link = HandleInput ();
		if (currentStory.GetLink (link) == null) {
			return;
		}

		if (isEnd) {
			StopInteraction ();
			isEnd = false;
			return;
		}

		passage = currentStory.CurrentPassage;
		tags = passage.Tags;
		isPlayer = false;
		foreach (string tag in tags) {
			if (tag == "player") {
				isPlayer = true;
			} else if (tag == "end") {
				isEnd = true;
			}
		}

		if (isPlayer) {
			currSpeaker = playerUIImage;
			otherSpeaker = npcUIImage;
            dialogueUIText.color = playerTextColor;
		} else {
			currSpeaker = npcUIImage;
			otherSpeaker = playerUIImage;
            dialogueUIText.color = npcTextColor;
		}
		HighlightSprite (currSpeaker);
		DarkenSprite (otherSpeaker);
		dialogueUIText.text = currentStory.GetCurrentText ().ToArray () [0].Text;
//		StartCoroutine (DisplayText(currentStory.GetCurrentText ().ToArray () [0].Text));
		currentStory.DoLink (link);
	}

	IEnumerator DisplayText(string text) {
		dialogueUIText.text = "";
		foreach (char c in text.ToCharArray ()) {
			dialogueUIText.text += c;
			yield return new WaitForSeconds (0.1f);
		}
	}

	private static string HandleInput () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			return "left_arrow";
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			return "space";
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			return "right_arrow";
		} else {
			return "";
		}
	}

	private static void DarkenSprite (Image img) {
		img.color = new Color (100f / 255, 100f / 255, 100f / 255);
	}

	private static void HighlightSprite (Image img) {
		img.color = Color.white;
	}

	//Set npcUISprite image to the given portrait
	public static void SetInteraction (NPCControllerTwine npcControl, Sprite portrait, Story story) {
		npc = npcControl;
		npcUIImage.sprite = portrait;
		currentStory = story;
	}

	public static void StartInteraction () {
		interacting = true;
		dialogueUI.SetActive (true);
		currentStory.Begin ();
//		ContinueInteraction ();
	}

	public static void StopInteraction () {
		currentStory = null;
		dialogueUIText.text = "";
		dialogueUI.SetActive (false);
		interacting = false;
		npc.InteractEnd ();
	}

}
