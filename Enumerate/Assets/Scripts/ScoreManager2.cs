using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ScoreManager2 : MonoBehaviour {
	public static void DoHighScores(){
		if (PlayerPrefs.GetInt("LevelType")==1) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore1")) {
				PlayerPrefs.SetInt ("highscore1", SpeedController.score);
			}
		} else if (PlayerPrefs.GetInt("LevelType")==2) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore2")) {
				PlayerPrefs.SetInt ("highscore2", SpeedController.score);
			}
		} else if (PlayerPrefs.GetInt("LevelType")==3) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore3")) {
				PlayerPrefs.SetInt ("highscore3", SpeedController.score);
			}
		} else if (PlayerPrefs.GetInt("LevelType")==4) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore4")) {
				PlayerPrefs.SetInt ("highscore4", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==5) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore5")) {
				PlayerPrefs.SetInt ("highscore5", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==6) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore6")) {
				PlayerPrefs.SetInt ("highscore6", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==7) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore7")) {
				PlayerPrefs.SetInt ("highscore7", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==8) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore8")) {
				PlayerPrefs.SetInt ("highscore8", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==9) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore9")) {
				PlayerPrefs.SetInt ("highscore9", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==10) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore10")) {
				PlayerPrefs.SetInt ("highscore10", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==11) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore11")) {
				PlayerPrefs.SetInt ("highscore11", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==12) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore12")) {
				PlayerPrefs.SetInt ("highscore12", SpeedController.score);
			}
		}else if (PlayerPrefs.GetInt("LevelType")==13) {
			if (SpeedController.score > PlayerPrefs.GetInt ("highscore13")) {
				PlayerPrefs.SetInt ("highscore13", SpeedController.score);
			}
		}
	}
}