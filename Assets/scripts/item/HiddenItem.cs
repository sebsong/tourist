using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItem : Item {

	private SpriteRenderer sr;

	public HiddenItem (string itemName) : base (itemName) {
	}

	protected override void Start () {
		base.Start ();
		sr = gameObject.GetComponent<SpriteRenderer> ();
		sr.enabled = false;
	}

	protected override void InteractableEffect () {
		sr.enabled = true;
	}

	protected override void InteractableEffectEnd () {
		sr.enabled = false;
	}
}
