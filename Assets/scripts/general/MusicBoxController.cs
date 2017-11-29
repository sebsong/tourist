using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBoxController : MonoBehaviour {
    AudioSource audioSrc;

    void Start() {
        audioSrc = GetComponent<AudioSource>();
    }

    IEnumerator FadeOut(float delay) {
        audioSrc.volume = 1f;
        while (audioSrc.volume > 0) {
            audioSrc.volume -= Time.deltaTime / delay;
            yield return null;
        }
    }

    IEnumerator FadeIn(float delay) {
        audioSrc.volume = 0f;
        if (!audioSrc.isPlaying) {
            audioSrc.Play();
        }
        while (audioSrc.volume < 1) {
            audioSrc.volume += Time.deltaTime / delay;
            yield return null;
        }
    }

	void OnTriggerEnter2D (Collider2D coll) {
        print("TRIGGER");
        StartCoroutine(FadeIn(2f));
	}

	void OnTriggerExit2D (Collider2D coll) {
        StartCoroutine(FadeOut(2f));
	}
}
