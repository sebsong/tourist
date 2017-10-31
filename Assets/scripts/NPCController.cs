using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	public TextAsset dialogueFile;

	private Dialogue d;

	private bool interactable;
	private bool interacting;

	// Use this for initialization
	void Start () {
		d = new Dialogue (dialogueFile);
		interactable = false;
		while (d.HasLine ()) {
			print (d.PeekNextSpeaker ());
			print (d.NextLine ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (interactable) {
			if (!interacting) {
				InteractableEffect ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (!interacting) {
					Interact ();
				} else {
				}
			}
		}

	}

	//Visual effect to indicate player in range of NPC
	void InteractableEffect () {
	}

	void Interact() {
		interacting = true;
	}

	void OnTriggerEnter2D (Collider2D coll) {
		print ("ENTER");
		interactable = true;
	}

	void OnTriggerExit2D (Collider2D coll) {
		print ("EXIT");
		interactable = false;
	}
}
