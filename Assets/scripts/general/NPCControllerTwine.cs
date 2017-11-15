using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;

public class NPCControllerTwine : Interactable {

	public Sprite portrait;
	public GameObject item;
	public string conditionItem;

	private Story story;
	private Story full_anagram;
	private Story half_anagram;
	private Story no_anagram;
	private Story item_receive;

	private GameObject exclamation;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		story = GetComponent<Story> ();
		exclamation = transform.GetChild (0).gameObject;
	}
	
	protected override void Interact ()
	{
		base.Interact ();
		DialogueControllerTwine.SetInteraction (this, portrait, story);
		DialogueControllerTwine.StartInteraction ();
	}

	//DEMO
	public override void InteractEnd () {
		if (item != null && (conditionItem == "" || DataController.Instance.PlayerData.InventoryContains(conditionItem))) {
			if (conditionItem != "") {
				DataController.Instance.PlayerData.ProficiencyAdd (100);
			}
			DataController.Instance.PlayerData.InventoryRemove (conditionItem);
			item.SetActive (true);
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
