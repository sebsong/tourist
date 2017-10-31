using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	private static GameObject dialogueUI;
	private static Text dialogueUIText;

	private static Image playerUIImage;
	private static Image npcUIImage;

	private static Dialogue currentDialogue;
	private static bool interacting;

	// Use this for initialization
	void Start () {
		dialogueUI = GameObject.FindGameObjectWithTag ("dialogue_ui");
		dialogueUIText = GameObject.FindGameObjectWithTag ("dialogue_ui_text").GetComponent<Text> ();

		playerUIImage = GameObject.FindGameObjectWithTag ("player_ui_img").GetComponent<Image> ();
		npcUIImage = GameObject.FindGameObjectWithTag ("npc_ui_img").GetComponent<Image> ();
		dialogueUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (interacting) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				ContinueInteraction ();
			}
		}
	}

	private static void ContinueInteraction () {
		Image currSpeaker;
		Image otherSpeaker;

		if (!currentDialogue.HasLine ()) {
			StopInteraction ();
			return;
		}

		if (currentDialogue.PeekNextSpeaker () == "Player") {
			currSpeaker = playerUIImage;
			otherSpeaker = npcUIImage;
		} else {
			currSpeaker = npcUIImage;
			otherSpeaker = playerUIImage;
		}
		HighlightSprite (currSpeaker);
		DarkenSprite (otherSpeaker);
		dialogueUIText.text = currentDialogue.NextLine ();
	}

	private static void DarkenSprite (Image img) {
		img.color = new Color (100f / 255, 100f / 255, 100f / 255);
	}

	private static void HighlightSprite (Image img) {
		img.color = Color.white;
	}

	//Set npcUISprite image to the given portrait
	public static void SetInteraction (Sprite portrait, Dialogue dialogue) {
		npcUIImage.sprite = portrait;
		currentDialogue = dialogue;
	}

	public static void StartInteraction () {
		interacting = true;
		dialogueUI.SetActive (true);
		ContinueInteraction ();
	}

	public static void StopInteraction () {
		dialogueUI.SetActive (false);
		interacting = false;
		NPCController.StopInteraction ();
	}
}
