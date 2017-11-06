using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	// Handle player movement
	void Move() {
		Vector3 dir;
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		if (horizontal != 0) {
			dir = new Vector2 (horizontal, 0);
		} else {
			dir = new Vector2 (0, vertical);
		}

		transform.position += dir * speed * Time.deltaTime;
	}
}
