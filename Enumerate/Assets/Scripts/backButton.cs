using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject menuButton;
	public GameObject soundButton;
	public GameObject restartButton;
	public GameObject playButton;
	public GameObject pausedText;
	public GameObject blackBackground;
	public static List<GameObject> buttonList;
	void Start(){
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
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			backButtonVoid();
		}
		if(!ClickController.backgroundMusicIsOn){
			GameObject.Find("Music").GetComponent<AudioSource>().Pause();
		}
	}
	public void backButtonVoid(){
		if(SceneManager.GetActiveScene().buildIndex==0||SceneManager.GetActiveScene().buildIndex==7){
			Application.Quit();
		}
		else if(SceneManager.GetActiveScene().buildIndex==1){
			if(ClickController.onPause){
				pauseButton.SetActive (true);
				foreach(GameObject i in buttonList){
					i.SetActive(false);
				}
				Time.timeScale = 1;
				ClickController.onPause = false;	
			}
			else{
				pauseButton.SetActive (false);
				foreach(GameObject i in buttonList){
					i.SetActive(true);
				}
				Time.timeScale=0;
				ClickController.onPause=true;			}
		}
		else if(SceneManager.GetActiveScene().buildIndex==2){
			DontDestroyOnLoad (GameObject.Find("Music"));
            ClickController.sceneName = 0;
            ClickController.previousScene = 0;
            SceneManager.LoadScene(7);
		}
		else if(SceneManager.GetActiveScene().buildIndex==3){
			DontDestroyOnLoad (GameObject.Find("Music"));
			Application.LoadLevel (ClickController.previousScene);
		}
		else if(SceneManager.GetActiveScene().buildIndex==4){
			DontDestroyOnLoad (GameObject.Find("Music"));
            ClickController.sceneName = 0;
            ClickController.previousScene = 0;
            SceneManager.LoadScene(7);
        }
		else if(SceneManager.GetActiveScene().buildIndex==5){
            ClickController.sceneName = 0;
            ClickController.previousScene = 0;
            DontDestroyOnLoad(GameObject.Find("Music"));
            SceneManager.LoadScene(7);
        }
		else if(SceneManager.GetActiveScene().buildIndex==6){
			DontDestroyOnLoad (GameObject.Find("Music"));
            ClickController.sceneName = 0;
            ClickController.previousScene = 0;
            SceneManager.LoadScene(7);
		}
	}
}