using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : Item {

    [SerializeField]
	private GameObject fakeBackpack, painting;

	public Backpack (string itemName) : base (itemName) {
	}

	protected override void Start () {
		base.Start ();
        fakeBackpack.SetActive (false);
        painting.SetActive (true);
	}

    protected override void Interact() {
        base.Interact();
        DataController.Instance.PlayerData.ProficiencyLevel = 3;
    }
}
