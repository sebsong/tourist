using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour {

	private static Utility util = new Utility ();

	private Utility() {}

	public static Utility getUtil() {
		return util;
	}

	public void FadeToScene(string sceneName, float delay) {
		Image fade = GameObject.FindGameObjectWithTag ("fade").GetComponent<Image>();
		fade.canvasRenderer.SetAlpha (0f);
		fade.CrossFadeAlpha (1f, delay, false);
		StartCoroutine (LoadLevel(sceneName, delay));
	}

	private IEnumerator LoadLevel(string sceneName, float delay) {
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (sceneName);
	}

}
