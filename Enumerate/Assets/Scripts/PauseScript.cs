using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject menuButton;
	public GameObject soundButton;
	public GameObject soundOffButton;
	public GameObject restartButton;
	public GameObject playButton;
	public GameObject pausedText;
	public GameObject blackBackground;
	public GameObject checkMenuButton;
	public GameObject checkRestartButton;
	public static AudioSource gameMusic;
	public static List<GameObject> buttonList;
    public GameObject multiplyText;


	void Start(){
		gameMusic = GameObject.Find ("Music").GetComponent<AudioSource> ();
		buttonList = new List<GameObject> ();
		addButtons ();
	}
	void addButtons(){
		buttonList.Add (menuButton);
		buttonList.Add (soundButton);
		buttonList.Add (restartButton);
		buttonList.Add (playButton);
		buttonList.Add (pausedText);
		buttonList.Add (blackBackground);
	}
	public void Pause(){
		pauseButton.SetActive (false);
        multiplyText.SetActive(false);
		foreach(GameObject i in buttonList){
			i.SetActive(true);
		}
		Time.timeScale=0;
		ClickController.onPause=true;
		/*#if UNITY_ANDROID
		StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.BOTTOM);
		#endif*/
	}
	public void Unpause(){
		pauseButton.SetActive (true);
        multiplyText.SetActive(true);
		foreach(GameObject i in buttonList){
			i.SetActive(false);
		}
		soundOffButton.SetActive (false);
		Time.timeScale = 1;
		ClickController.onPause = false;
		/*#if UNITY_ANDROID
		StartAppWrapper.addBanner( 
		                          StartAppWrapper.BannerType.AUTOMATIC,
		                          StartAppWrapper.BannerPosition.BOTTOM);
		#endif*/
	}
	public void checkRestart(){
		checkRestartButton.SetActive (true);
	}
	public void Restart(){
		checkRestartButton.SetActive (false);
		ClickController.shouldBe++;
		DontDestroyOnLoad (GameObject.Find("Music"));
		Application.LoadLevel (1);
		foreach(GameObject i in buttonList){
			i.SetActive(true);
		}
		ClickController.onPause = false;
		Time.timeScale = 1;
		SpeedController.score = 0;
		ClickController.sceneName = 1;
		ClickController.previousScene=1;
	}
	public void changeSound(){
		if (!ClickController.backgroundMusicIsOn) {
			ClickController.backgroundMusicIsOn=true;
			soundOffButton.SetActive(false);
			gameMusic.Play();
		} else {
			ClickController.backgroundMusicIsOn=false;
			soundOffButton.SetActive(true);
			gameMusic.Pause();
		}
	}
	public void checkMenu(){
		checkMenuButton.SetActive (true);
	}
	public void goToMenu(){
		checkMenuButton.SetActive (false);
		DontDestroyOnLoad (GameObject.Find("Music"));
		Application.LoadLevel (7);
		ClickController.onPause = false;
		Time.timeScale = 1;
		ClickController.sceneName = 0;
		ClickController.previousScene=0;
		/*#if UNITY_ANDROID
		StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.BOTTOM);
		#endif*/
	}
}