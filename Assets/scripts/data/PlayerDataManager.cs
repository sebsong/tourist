using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager {
	public Inventory PlayerInventory { get; set; }
	public int Proficiency { get; set; }
	public int ProficiencyLevel { get; set; }

	public PlayerDataManager() {
		PlayerInventory = new Inventory ();
		Proficiency = 0;
		ProficiencyLevel = 0;
	}

	public void InventoryAdd (Item item) {
		PlayerInventory.AddItem (item);
	}

	public bool InventoryContains (string itemName) {
		return PlayerInventory.Contains (itemName);
	}
}
