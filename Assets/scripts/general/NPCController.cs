//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class NPCController : Interactable {
//
//	public TextAsset dialogueFile;
//	//DEMO
//	public TextAsset dialogueFileAnagram;
//	public Sprite portrait;
//	public GameObject item;
//	public string conditionItem;
//
//	private Dialogue dialogue;
//	//DEMO
//	private Dialogue dialogueAnagram;
//	private GameObject exclamation;
//
//	// Use this for initialization
//	protected override void Start () {
//		base.Start ();
//		dialogue = new Dialogue (dialogueFile);
//		//DEMO
//		dialogueAnagram = new Dialogue (dialogueFileAnagram);
//		exclamation = transform.GetChild (0).gameObject;
//	}
//	
//	protected override void Interact ()
//	{
//		base.Interact ();
//		if (player.InventoryContains ("backpack")) {
//			DialogueController.SetInteraction (this, portrait, dialogue);
//		} else {
//			DialogueController.SetInteraction (this, portrait, dialogueAnagram);
//		}
//		DialogueController.StartInteraction ();
//	}
//
//	//DEMO
//	public override void InteractEnd () {
//		base.InteractEnd ();
//		if (item != null && (conditionItem == "" || player.InventoryContains(conditionItem))) {
//			item.SetActive (true);
//		}
//	}
//
//	protected override void InteractableEffect () {
//		exclamation.SetActive (true);
//	}
//
//	protected override void InteractableEffectEnd () {
//		exclamation.SetActive (false);
//	}
//
//	private void ShowExclamation () {
//	}
//
//	private void HideExclamation () {
//	}
//}
