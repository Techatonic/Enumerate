using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Highscores : MonoBehaviour {
	const string webURL = "http://dreamlo.com/lb/";
	readonly string[] publics = {
		"56c040706e51b6083ca54e00",
		"568d805f6e51b6163489755c", 
		"568d80786e51b616348975d1", 
		"568d80996e51b6163489764d", 
		"5740496c6e51b6162837813d", 
		"574049826e51b6162837818c",
		"574204026e51b608bc45e2c9",
		"574204106e51b608bc45e2fe",
		"5742041e6e51b608bc45e326",
		"574204286e51b608bc45e34a",
		"574204306e51b608bc45e35f",
		"574204386e51b608bc45e375",
		"5744a9f18af6030a30f1228c",
	};
	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;
	static Highscores instance;
	
	void Awake() {
		highscoreDisplay = GetComponent<DisplayHighscores> ();
		instance = this;
	}
	public void DownloadHighscores(int level) {
		StartCoroutine(DownloadHighscoresFromDatabase(level));
	}
	IEnumerator DownloadHighscoresFromDatabase(int level) {
		WWW	www = new WWW (webURL+publics[level]+"/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}
	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
		}
	}
}
public struct Highscore {
	public string username;
	public int score;
	
	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}
}