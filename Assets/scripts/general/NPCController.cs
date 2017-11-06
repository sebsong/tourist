using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : Interactable {

	public TextAsset dialogueFile;
	public Sprite portrait;

	private Dialogue dialogue;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		dialogue = new Dialogue (dialogueFile);
	}
	
	protected override void Interact ()
	{
		base.Interact ();
		DialogueController.SetInteraction (this, portrait, dialogue);
		DialogueController.StartInteraction ();
	}

	protected override void InteractableEffect () {
	}
}
