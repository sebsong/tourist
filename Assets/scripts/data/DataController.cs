using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	public static DataController Instance;

	private PlayerData playerData;
	private string transitionDoor;

	// Use this for initialization
	void Start () {
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (Instance);
		}
		
	}

	public PlayerData GetPlayerData () {
		return playerData;
	}
	public void SetPlayerData (PlayerData data) {
		playerData = data;
	}
}
