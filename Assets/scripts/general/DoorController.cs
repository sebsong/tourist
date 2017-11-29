using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorController : Interactable {

	public static string ExitDoorName;// { get; set; }
	public static Vector3 ExitPosition;// { get; set; }

	[SerializeField]
	private string doorName, exitDoorName, sceneName;

	[SerializeField]
	private float delay;

	private Image fade;
	private GameObject glow;

	protected override void Start() {
		base.Start ();
		if (doorName == ExitDoorName) {
			ExitPosition = transform.position;
		}
		fade = GameObject.FindGameObjectWithTag ("fade").GetComponent<Image>();
		fade.canvasRenderer.SetAlpha (0f);
		glow = transform.GetChild (0).gameObject;
	}

	protected override void Interact() {
		base.Interact ();
		ExitDoorName = exitDoorName;
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
