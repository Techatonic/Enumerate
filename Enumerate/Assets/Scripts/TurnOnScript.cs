using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnOnScript : MonoBehaviour {
	private static bool available=true;
	int number=0;
	Highscore1[] highscoresList;
	public Highscores highscoreManager;
	const string webURL = "http://dreamlo.com/lb/";
	readonly string[] publics={"56c040706e51b6083ca54e00","568d805f6e51b6163489755c", "568d80786e51b616348975d1", "568d80996e51b6163489764d"};
	private static string usernameString;
	public static TurnOnScript instance;
	public static PlayAgainScript clickController;
	public static void TurnOn(){
		ActuallyTurnOnVoid ();
	}
	public static void ActuallyTurnOnVoid(){
		Time.timeScale=0;
		ClickController.onPause=true;
		instance.StartCoroutine ("please");
	}
	IEnumerator please(){
		yield return new WaitForSeconds (0.5f);
		clickController.Canvas_1 = GameObject.Find ("Canvas 1");
		Debug.Log (clickController.Canvas_1);
		clickController.Canvas_1.SetActive (true);
		clickController.plane.SetActive(true);
	}
	public void GoToInputBoxSubmit(){
		StartCoroutine ("InputBoxSubmit");
	}
	public IEnumerator InputBoxSubmit(){
		WWW	www = new WWW (webURL+publics[number]+"/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			string[] entries = www.text.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
			highscoresList = new Highscore1[entries.Length];
			for (int i = 0; i <entries.Length; i ++) {
				string[] entryInfo = entries[i].Split(new char[] {'|'});
				string username = entryInfo[0];
				int score = int.Parse(entryInfo[1]);
				highscoresList[i] = new Highscore1(username,score);
				if(highscoresList[i].username.ToLower()==GameObject.Find("CheckUsername").GetComponent<InputField>().text.ToLower()||highscoresList[i].username.ToLower()==""){
					available=false;
				}
			}
		}
		number++;
		if (number < 4) {
			GoToInputBoxSubmit ();
		} else {
			number=0;
			StartCoroutine("submitUsername");
		}
	}
	public IEnumerator submitUsername(){
		yield return 0;
		if (available && GameObject.Find("CheckUsername").GetComponent<InputField>().text.ToLower()!="") {
			PlayerPrefs.SetString ("username", GameObject.Find ("CheckUsername").GetComponent<InputField> ().text);
			ClickController.username = GameObject.Find ("CheckUsername").GetComponent<InputField> ().text;
			GameObject.Find ("CheckUsername").SetActive (false);
			GameObject.Find("Canvas 1").SetActive(false);
			GameObject.Find("Plane").SetActive(false);
			Time.timeScale=1;
			ClickController.onPause=false;
		} else {
			GameObject.Find("CheckUsername").GetComponent<InputField>().text="";
			GameObject.Find("CheckUsername").GetComponent<InputField>().placeholder.GetComponent<Text>().text = "That username has been taken. Please pick a new one.";
		}
		available = true;
	}
}