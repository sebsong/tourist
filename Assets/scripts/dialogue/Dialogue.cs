using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Dialogue {

	private List<DialogueLine> script;
	private int idx;


	public Dialogue (TextAsset textFile) {
		script = new List<DialogueLine> ();
		idx = 0;
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
				currentSpeaker = Regex.Replace (section, "<|>| ", "");
			} else {
				script.Add (new DialogueLine (currentSpeaker, section));
			}
		}
	}

	public string NextLine() {
		string tempText = script [idx].GetText ();
		idx++;
		return tempText;
	}

	public bool HasLine() {
		bool temp = idx < script.Count;
		if (!temp) {
			idx = 0;
		}
		return temp;
	}

	public string PeekNextSpeaker() {
		return script[idx].GetSpeaker ();
	}
}
