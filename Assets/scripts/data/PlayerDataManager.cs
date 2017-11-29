using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager {
	public Inventory PlayerInventory { get; set; }
	public int Proficiency { get; private set; }
	public int ProficiencyLevel { get; private set; }

	public PlayerDataManager() {
		PlayerInventory = new Inventory ();
		Proficiency = 0;
		ProficiencyLevel = 1;
	}

	public void ProficiencyAdd (int pts) {
		Proficiency += pts;
		if (Proficiency >= 100) {
			Proficiency = 0;
			if (ProficiencyLevel < 4) {
				ProficiencyLevel += 1;
			}
		}
	}

	public void InventoryAdd (Item item) {
		PlayerInventory.AddItem (item);
	}

	public void InventoryRemove (string itemName) {
		PlayerInventory.RemoveItem (itemName);
	}

	public bool InventoryContains (string itemName) {
		return PlayerInventory.Contains (itemName);
	}

}
