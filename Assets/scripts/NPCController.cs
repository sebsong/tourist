using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	public TextAsset dialogueFile;
	public Sprite portrait;

	private Dialogue dialogue;

	private bool interactable;
	private static bool interacting;
	private static float interactionCooldown;

	// Use this for initialization
	void Start () {
		dialogue = new Dialogue (dialogueFile);
		interactable = false;
		interactionCooldown = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (interactionCooldown == 0 && interactable && !interacting) {
			InteractableEffect ();
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
	void InteractableEffect () {
	}

	void Interact() {
		interacting = true;
		DialogueController.SetInteraction (portrait, dialogue);
		DialogueController.StartInteraction ();
	}

	public static void StopInteraction () {
		interactionCooldown = 1f;
		interacting = false;
	}

	void OnTriggerEnter2D (Collider2D coll) {
		interactable = true;
	}

	void OnTriggerExit2D (Collider2D coll) {
		interactable = false;
	}
}
