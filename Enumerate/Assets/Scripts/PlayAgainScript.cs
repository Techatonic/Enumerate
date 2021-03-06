using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgainScript : MonoBehaviour {
	public static PlayAgainScript instance;
	private static bool available=true;
	int number=0;
	Highscore1[] highscoresList;
	public Highscores highscoreManager;
	const string webURL = "http://dreamlo.com/lb/";
	readonly string[] publics={"56c040706e51b6083ca54e00","568d805f6e51b6163489755c", "568d80786e51b616348975d1", "568d80996e51b6163489764d"};
	private static string usernameString;
	public static bool firstTime=false;
	public GameObject Canvas_1;
	public GameObject plane;
	void Start(){
		if(SceneManager.GetActiveScene().buildIndex==0&&ClickController.soundPreviousScene!=0){
			GameObject.Find ("Music").GetComponent<AudioSource> ().Play ();
		}
		
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			ClickController.plays = PlayerPrefs.GetInt ("numberOfPlays");
			if (PlayerPrefs.GetInt ("numberOfPlays") == 0) {
				firstTime=true;
				PlayerPrefs.SetInt("multiply",1);
				PlayerPrefs.SetInt("LevelType",1);
			}
			ClickController.backgroundMusicIsOn=true;
			ClickController.touchSoundIsOn=true;
		}
		PlayerPrefs.SetInt ("numberOfPlays", PlayerPrefs.GetInt("numberOfPlays") + 1);
		ClickController.username = PlayerPrefs.GetString ("username");
	}
	void Update(){
		if(ClickController.previousScene==0){
			ClickController.previousScene=7;
		}
	}
	public void playMultiply(){
		PlayerPrefs.SetInt("multiply",13);
		PlayerPrefs.SetInt("LevelType",13);
	}
	public void playNormal(){
		if(PlayerPrefs.GetInt("multiply")==13){
			PlayerPrefs.SetInt("multiply",1);
			PlayerPrefs.SetInt("LevelType",1);
		}
	}
	public void StartGame(){
		instance = this;
		DontDestroyOnLoad (GameObject.Find("Music"));
		//DontDestroyOnLoad (GameObject.Find("AdmobGameObject"));
		SceneManager.LoadScene (1);
		ClickController.previousScene=1;
		ClickController.sceneName = 1;
		SpeedController.speed = 0.3f;
		SpeedController.score=0;
		SpeedController.otherScore = 0;
		Time.timeScale = 1;
		ClickController.onPause = false;
		StartCoroutine ("Try1");
	}
	IEnumerator Try1(){
		yield return new WaitForSeconds (2.0f);
		instance.Try();
	}
	void Try(){
		GameObject.Find("ScoreText").GetComponent<TextMesh>().text="Score: "+SpeedController.score;
		SpeedController.score = 0;
	}
	public void GoBackToPreviousScene(){
		DontDestroyOnLoad (GameObject.Find("Music"));
		SceneManager.LoadScene (ClickController.previousScene);
	}
	public void leaveGame(){
		Application.Quit ();
	}
	public void goToSettings(){
		DontDestroyOnLoad (GameObject.Find("Music"));
		SceneManager.LoadScene (6);
		ClickController.sceneName = 6;
		ClickController.previousScene=6;
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			ClickController.soundPreviousScene = 0;
		} else {
			ClickController.soundPreviousScene=1;
		}
		ClickController.shouldBe++;
	}
	public void goToInstructions(){
		DontDestroyOnLoad (GameObject.Find("Music"));
		SceneManager.LoadScene (5);
		ClickController.sceneName = 5;
		ClickController.previousScene=5;
		ClickController.shouldBe++;
	}
}
public struct Highscore1 {
	public string username;
	public int score;
	
	public Highscore1(string _username, int _score) {
		username = _username;
		score = _score;
	}
}