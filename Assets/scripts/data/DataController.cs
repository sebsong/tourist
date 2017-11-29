using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	public static DataController Instance;

	public PlayerDataManager PlayerData;// { get; private set; }

	/* public string transitionDoor; */

	// Use this for initialization
	void Awake () {
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
			PlayerData = new PlayerDataManager ();
		} else if (Instance != this) {
			Destroy (Instance);
		}
	}
}
