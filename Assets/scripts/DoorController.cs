using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
	public string sceneName;
	public float delay;

	void OnTriggerEnter2D (Collider2D coll) {
		print ("COLLISION");
		Utility.getUtil ().FadeToScene (sceneName, delay);
	}
}
