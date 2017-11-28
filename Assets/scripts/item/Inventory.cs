using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : IEnumerable<Item> {

	private HashSet<Item> inventory;
	private Text inventoryText;

	// Use this for initialization
	public Inventory () {
//		inventoryText = GameObject.FindGameObjectWithTag ("inventory_ui").GetComponent<Text> ();
		inventory = new HashSet<Item> ();
		DrawUI ();
	}

	public void AddItem (Item item) {
		inventory.Add (item);
		DrawUI ();
	}

	public void RemoveItem (string itemName) {
		inventory.Remove (new Item (itemName));
		DrawUI ();
	}

	public bool Contains (string itemName) {
		return inventory.Contains (new Item(itemName));
	}

	public IEnumerator<Item> GetEnumerator() {
		return ((IEnumerable<Item>) inventory).GetEnumerator ();
	}

	IEnumerator IEnumerable.GetEnumerator () {
		return this.GetEnumerator ();
	}

	public void DrawUI () {
		inventoryText = GameObject.FindGameObjectWithTag ("inventory_ui").GetComponent<Text> ();
		string inventoryString = "";
		foreach (Item item in inventory) {
			inventoryString += item.GetItemName () + "\n";
		}
		inventoryText.text = inventoryString;
	}
}
