using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable {

	[SerializeField]
	private string itemName;

	public Item (string itemName) {
		this.itemName = itemName;
	}

	protected override void Interact() {
		base.Interact ();
		DataController.Instance.PlayerData.InventoryAdd (this);
		InteractEnd ();
	}

	public override void InteractEnd() {
		base.InteractEnd ();
		gameObject.SetActive (false);
	}

	protected override void InteractableEffect () {
	}

	protected override void InteractableEffectEnd () {
	}

	public string GetItemName () {
		return itemName;
	}

	public override bool Equals (System.Object obj) {
		if (obj == null) {
			return false;
		} else if (!(obj is Item)) {
			return false;
		} else {
			return ((Item)obj).GetItemName ().Equals (itemName);
		}

	}

	public override int GetHashCode () {
		return itemName.GetHashCode ();
	}
}
