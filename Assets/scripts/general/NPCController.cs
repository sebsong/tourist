using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : Interactable {

	public TextAsset dialogueFile;
	public Sprite portrait;

	private Dialogue dialogue;
	private GameObject exclamation;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		dialogue = new Dialogue (dialogueFile);
		exclamation = transform.GetChild (0).gameObject;
	}
	
	protected override void Interact ()
	{
		base.Interact ();
		DialogueController.SetInteraction (this, portrait, dialogue);
		DialogueController.StartInteraction ();
	}

	protected override void InteractableEffect () {
		exclamation.SetActive (true);
	}

	protected override void InteractableEffectEnd () {
		exclamation.SetActive (false);
	}

	private void ShowExclamation () {
	}

	private void HideExclamation () {
	}
}
