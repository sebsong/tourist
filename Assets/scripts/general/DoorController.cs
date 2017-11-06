using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {
	public string doorName;
	public string sceneName;
	public float delay;

	private Image fade;
	private bool interactable;

	void Start() {
		fade = GameObject.FindGameObjectWithTag ("fade").GetComponent<Image>();
		fade.canvasRenderer.SetAlpha (0f);
	}

	void OnTriggerEnter2D (Collider2D coll) {
		FadeToScene (sceneName, delay);
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
