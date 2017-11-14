using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorController : Interactable {

	private static string currentExitDoorName;
	public static Vector3 currentExitPosition;

	[SerializeField]
	private string doorName, exitDoorName, sceneName;

	[SerializeField]
	private float delay;

	private Image fade;
	private GameObject glow;

	protected override void Start() {
		base.Start ();
		fade = GameObject.FindGameObjectWithTag ("fade").GetComponent<Image>();
		fade.canvasRenderer.SetAlpha (0f);
		glow = transform.GetChild (0).gameObject;
		if (doorName == currentExitDoorName) {
			currentExitPosition = transform.position;
		}
	}

	protected override void Interact() {
		base.Interact ();
		currentExitDoorName = exitDoorName;
		FadeToScene (sceneName, delay);
	}

	protected override void InteractableEffect () {
		glow.SetActive (true);
	}

	protected override void InteractableEffectEnd () {
		glow.SetActive (false);
	}

	void FadeToScene(string sceneName, float delay) {
		fade.CrossFadeAlpha (1f, delay, false);
		StartCoroutine (LoadLevel(sceneName, delay));
	}

	private IEnumerator LoadLevel(string sceneName, float delay) {
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (sceneName);
	}

}
