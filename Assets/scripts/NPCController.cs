using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

	private bool interactable;

	// Use this for initialization
	void Start () {
		interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (interactable) {
			InteractableEffect ();
		}
		
	}

	//Visual effect to indicate player in range of NPC
	void InteractableEffect () {
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
