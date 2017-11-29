using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;

public class NPCControllerTwine : Interactable {

	public Sprite portrait;
	public GameObject item;
	public string conditionItem;

//	private Story story;
//	private Story full_anagram;
//	private Story half_anagram;
//	private Story no_anagram;
//	private Story item_receive;
	private Story[] stories;

	private GameObject exclamation;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		stories = new Story[4];
		Story[] tempStories = GetComponents<Story> ();
		for (int i = 0; i < tempStories.Length; i++) {
			stories [i] = tempStories [i];
		}
		exclamation = transform.GetChild (0).gameObject;
	}
	
	protected override void Interact ()
	{
		base.Interact ();
		Story story;
		if (stories [3] != null && DataController.Instance.PlayerData.InventoryContains (conditionItem)) {
			story = stories [3];
		} else {
			story = stories[DataController.Instance.PlayerData.ProficiencyLevel];
		}
		DialogueControllerTwine.SetInteraction (this, portrait, story);
		DialogueControllerTwine.StartInteraction ();
	}

	//DEMO
	public override void InteractEnd () {
		if (conditionItem == "" || DataController.Instance.PlayerData.InventoryContains(conditionItem)) {
			if (conditionItem != "") {
				DataController.Instance.PlayerData.ProficiencyAdd (50);
			}
			DataController.Instance.PlayerData.InventoryRemove (conditionItem);
			if (item != null) {
				item.SetActive (true);
			}
			item = null;
		}
		base.InteractEnd ();
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
