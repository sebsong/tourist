using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine {

	private string speaker;
	private string text;

	public DialogueLine(string speaker, string text) {
		this.speaker = speaker;
		this.text = text;
	}

	public string GetSpeaker() {
		return speaker;
	}

	public string GetText() {
		return text;
	}
}
