using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Advertisements;

public class ClickController : MonoBehaviour {
	public static GameObject[] cubes;
	public static SpeedController _SpeedController;
	public static float thisSpeed;
	public static bool clicked=false;
	public static string username;
	public static int plays;
	public static ClickController instance;
	public static int sceneName;
	public static bool clickedOnIncorrect=false;
	public static bool onPause=false;
	public static bool adIsReady=false;
	public static bool backgroundMusicIsOn;
	public static bool touchSoundIsOn;
	public static int previousScene;
	public static int soundPreviousScene=1;
	const string webURL = "http://dreamlo.com/lb/";
	Highscore2[] highscoresList;
	public static int shouldBe = 1;
	public Highscores highscoreManager;
	
	public GameObject Canvas_1;
	public GameObject plane;

	public static void TurnOn(){
		ActuallyTurnOnVoid ();
	}
	public static void ActuallyTurnOnVoid(){
		Time.timeScale=0;
		ClickController.onPause=true;
		//instance.StartCoroutine ("please");
		instance.Canvas_1.SetActive (true);
		instance.plane.SetActive(true);
	}
	void Start(){
		instance = this;
		cubes=GameObject.FindGameObjectsWithTag("SquaresTag");
		InvokeRepeating ("Expand",0.5F,0.1F);
		InvokeRepeating ("changeBanner",5.0F,5.0F);
		thisSpeed = SpeedController.speed;
		if (transform.name == "SquaresTest (0)" && !onPause) {
			if(PlayerPrefs.GetInt("numberOfPlays")==shouldBe){
				TurnOn();
				// DANNY, IT IS HERE!!!!!!!!!!!
			}
			//TurnOnScript.TurnOn ();
			SpeedController.whichOne= Random.Range (0,5);
			GameObject.Find ("SquaresTest (" + SpeedController.whichOne + ")").GetComponentInChildren<TextMesh>().text=(SpeedController.score+PlayerPrefs.GetInt("multiply")).ToString();
			SpeedController.Start ();
		}
	}
	void Update(){
		if(transform.name=="SquaresTest (0)"&&!onPause){
			SpeedController.CheckIfGoneTooFar ();
			GameObject.Find("ScoreText").GetComponent<TextMesh>().text="Score "+SpeedController.score;
			SpeedController.highscores[0]=PlayerPrefs.GetInt("highscore1");
			SpeedController.highscores[1]=PlayerPrefs.GetInt("highscore2");
			SpeedController.highscores[2]=PlayerPrefs.GetInt("highscore3");
			SpeedController.highscores[3]=PlayerPrefs.GetInt("highscore4");
			SpeedController.highscores[4]=PlayerPrefs.GetInt("highscore5");
			SpeedController.highscores[5]=PlayerPrefs.GetInt("highscore6");
			SpeedController.highscores[6]=PlayerPrefs.GetInt("highscore7");
			SpeedController.highscores[7]=PlayerPrefs.GetInt("highscore8");
			SpeedController.highscores[8]=PlayerPrefs.GetInt("highscore9");
			SpeedController.highscores[9]=PlayerPrefs.GetInt("highscore10");
			SpeedController.highscores[10]=PlayerPrefs.GetInt("highscore11");
			SpeedController.highscores[11]=PlayerPrefs.GetInt("highscore12");
			SpeedController.highscores[12]=PlayerPrefs.GetInt("highscore13");
			Vector3 scoreVector=GameObject.Find("ScoreText").GetComponent<TextMesh>().transform.position;
			Vector3 highscoreVector=GameObject.Find("HighscoreText").GetComponent<TextMesh>().transform.position;
			GameObject.Find("HighscoreText").GetComponent<TextMesh>().text="Highscore "+SpeedController.highscores[PlayerPrefs.GetInt("multiply")-1];
			if(SpeedController.score.ToString().Length==1){
				scoreVector.x=7.5f;
			}
			else if(SpeedController.score.ToString().Length==2){
				scoreVector.x=5.5f;
			}
			else if(SpeedController.score.ToString().Length==3){
				scoreVector.x=3.5f;
			}
			else if(SpeedController.score.ToString().Length==4){
				scoreVector.x=1.5f;
			}
			if(SpeedController.highscores[PlayerPrefs.GetInt("multiply")-1].ToString().Length==1){
				highscoreVector.x=7;
			}
			else if(SpeedController.highscores[PlayerPrefs.GetInt("multiply")-1].ToString().Length==2){
				highscoreVector.x=5.75f;
			}
			else if(SpeedController.highscores[PlayerPrefs.GetInt("multiply")-1].ToString().Length==3){
				highscoreVector.x=4.5f;
			}
			else if(SpeedController.highscores[PlayerPrefs.GetInt("multiply")-1].ToString().Length==4){
				highscoreVector.x=3.1f;
			}
			GameObject.Find("ScoreText").GetComponent<TextMesh>().transform.position=scoreVector;
			GameObject.Find("HighscoreText").GetComponent<TextMesh>().transform.position=highscoreVector;
		}
	}
	void Expand(){
		if(!onPause){
			transform.position -= new Vector3 (0,0,thisSpeed);
		}
	}

	void OnMouseDown(){
		if (!onPause) {
			if(PlayerPrefs.GetInt("multiply")==13){
				if (int.Parse (transform.GetComponentInChildren<TextMesh> ().text.Replace(" ",string.Empty)) == SpeedController.correctAnswer) {
					clicked = true;
					SpeedController.Correct ();
					playSound.playSoundVoid();
				} else {
					clickedOnIncorrect = true;
					StartCoroutine("waitForReady");
				}
			}
			else{
				if (int.Parse (transform.GetComponentInChildren<TextMesh> ().text.Replace(" ",string.Empty)) == SpeedController.score + PlayerPrefs.GetInt("multiply")) {
					clicked = true;
					SpeedController.Correct ();
					playSound.playSoundVoid();
				} else {
					clickedOnIncorrect = true;
					StartCoroutine("waitForReady");
				}
			}
		}
	}
	void changeBanner(){
	}
	public IEnumerator waitForReady(){
		yield return 0;
		adIsReady=true;
		StartCoroutine(Die());
	}
    public static IEnumerator Die() {
        string url = null;
        if (PlayerPrefs.GetInt("LevelType") == 1) {
            url = webURL + "N12_D-01a0-HUnKfkieUaQlLTDbEJoBkmWVNKwI6HMpg" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 2) {
            url = webURL + "tf5IeLSJ6ESLUlrm56Y2uA4V-DTHaHnE-abSqGvoePwg" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 3) {
            url = webURL + "tOQmG351LUmGe8NeMtBtsQRiTADbmGFU-XhNOWAyQocA" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 4) {
            url = webURL + "F4VTzCbh50O8rz0mNx37zQ6L_P7mkpkEuWUmV32PAodw" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 5) {
            url = webURL + "pNAbimij90-oVWbof7IhTgN1usvVG-j0aogAm33PmaUA" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 6) {
            url = webURL + "wVJVJaiBS06yzM4OB7KmEg1FnytQBG90m9i9xUeAo_4w" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 7) {
            url = webURL + "tCpLBsby2EqNb0ceo7wFyAjKy3TNod0kK2LRPRo0UphA" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 8) {
            url = webURL + "jm_g49-hAUKAQtLCt3b6awjRDsEDYG0E-thQcmEdgtzQ" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 9) {
            url = webURL + "zFf5SIak-0ebMhFKwH-Yewp6YvrcGWqUq8j7KWgpKp0Q" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 10) {
            url = webURL + "WEmW_3sew0md4nOifJ_zqAYMZoTpaAQkewKUPqTEq_KQ" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 11) {
            url = webURL + "M2rwLGBGSUiQDb3264YIdQhcAnFJGVKkujYiC_RajZFg" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 12) {
            url = webURL + "Eas4kNub-E2lhFq0PEK3eQKnIqwgYFi0G07sEp85M6bg" + "/add/" + username + "/" + SpeedController.score;
        }
        else if (PlayerPrefs.GetInt("LevelType") == 13) {
            url = webURL + "2dwyFFBPK0GgyvtGVJTCXQ5jD8D5x37EmEoxnuqbL2Dw" + "/add/" + username + "/" + SpeedController.score;
        }
        else {
            print("Something wrong with level types");
        }
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        soundPreviousScene = 1;
        DontDestroyOnLoad(GameObject.Find("Music"));
        ClickController.shouldBe++;
        sceneName = 2;
        previousScene = 2;
        ScoreManager2.DoHighScores();

        if (Random.Range(0f, 1f) < 0.5f) { // 50% chance of ad showing - always skippable
            #if UNITY_ADS
            Advertisement.Show();
            #endif
        }

        SceneManager.LoadScene("End Scene");
    }
}
public struct Highscore2 {
	public string username;
	public int score;
	
	public Highscore2(string _username, int _score) {
		username = _username;
		score = _score;
	}
}