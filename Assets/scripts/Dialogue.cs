using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Dialogue {

	private Queue<DialogueLine> script;


	public Dialogue (TextAsset textFile) {
		script = new Queue<DialogueLine> ();
		ParseFile (textFile);
	}

	//Parse the given TextAsset and populate the script
	private void ParseFile(TextAsset textFile) {
		string contents;
		string[] splitContents;
		string currentSpeaker = "";

		contents = textFile.text;
		contents = Regex.Replace (contents, "\r|\n", "");

		splitContents = Regex.Split (contents, "===");

		foreach (string section in splitContents) {
			if (Regex.Match (section, "<(.*)>").Success) {
				currentSpeaker = Regex.Replace (section, "<|>", "");
			} else {
				script.Enqueue (new DialogueLine (currentSpeaker, section));
			}
		}
	}

	public string NextLine() {
		return script.Dequeue ().GetText ();
	}

	public bool HasLine() {
		return script.Count > 0;
	}

	public string PeekNextSpeaker() {
		return script.Peek ().GetSpeaker ();
	}

}
