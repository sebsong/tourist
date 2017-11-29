using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	public static DataController Instance;

	public PlayerDataManager PlayerData;// { get; private set; }

	public string ExitDoorName;// { get; set; }
	public Vector3 ExitPosition;// { get; set; }


	/* public string transitionDoor; */

	// Use this for initialization
	void Awake () {
		if (Instance == null) {
            print("REINITIALIZE");
			DontDestroyOnLoad (gameObject);
			Instance = this;
            print(PlayerData);
			PlayerData = new PlayerDataManager ();
		} else if (Instance != this) {
			Destroy (gameObject);
		}
	}
}
