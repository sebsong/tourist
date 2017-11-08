using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IEnumerable<Item> {

	private HashSet<Item> inventory;

	// Use this for initialization
	public Inventory () {
		inventory = new HashSet<Item> ();
	}

	public void AddItem (Item item) {
		inventory.Add (item);
	}

	public bool Contains (Item item) {
		return inventory.Contains (item);
	}

	public IEnumerator<Item> GetEnumerator() {
		return ((IEnumerable<Item>) inventory).GetEnumerator ();
	}

	IEnumerator IEnumerable.GetEnumerator () {
		return this.GetEnumerator ();
	}

//	public void DrawUI () {
//	}
}
