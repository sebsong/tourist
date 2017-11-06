using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

	private bool interactable;
	private static bool interacting;
	private static float interactionCooldown;
	private PlayerController player;

	// Use this for initialization
	protected virtual void Start () {
		interactable = false;
		interacting = false;
		interactionCooldown = 1f;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (interactionCooldown == 0 && interactable && !interacting) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Interact ();
			}
		}

		if (interactionCooldown > 0) {
			interactionCooldown -= Time.deltaTime;
		} else {
			interactionCooldown = 0;
		}
	}

	//Visual effect to indicate player in range of NPC
	protected abstract void InteractableEffect ();

	protected abstract void InteractableEffectEnd ();

	protected virtual void Interact() {
		interacting = true;
		player.Interact ();
	}

	public virtual void InteractEnd () {
		interactionCooldown = 1f;
		interacting = false;
		player.InteractEnd ();
	}

	protected virtual void OnTriggerEnter2D (Collider2D coll) {
		interactable = true;
		InteractableEffect ();
	}

	protected virtual void OnTriggerExit2D (Collider2D coll) {
		interactable = false;
		InteractableEffectEnd ();
	}
}
