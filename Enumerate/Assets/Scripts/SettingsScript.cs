using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsScript : MonoBehaviour {
	public List<GameObject> greens;
	public List<GameObject> noGreens;
	public GameObject backgroundMusicMuteButton;
	public GameObject sfxMuteButton;
	void Start(){
		if(!ClickController.backgroundMusicIsOn){
			backgroundMusicMuteButton.SetActive(true);
		}
		if(!ClickController.touchSoundIsOn){
			sfxMuteButton.SetActive(true);
		}
	}
	public void changeBackgrouondMusic(){
		if (ClickController.backgroundMusicIsOn) {
			ClickController.backgroundMusicIsOn = false;
			backgroundMusicMuteButton.SetActive(true);
			GameObject.Find("Music").GetComponent<AudioSource>().Pause();
		} else {
			backgroundMusicMuteButton.SetActive(false);
			ClickController.backgroundMusicIsOn=true;
			GameObject.Find("Music").GetComponent<AudioSource>().UnPause();
		}
	}
	public void changeTouchSound(){
		if (ClickController.touchSoundIsOn) {
			sfxMuteButton.SetActive(true);
			ClickController.touchSoundIsOn = false;
		} else {
			sfxMuteButton.SetActive(false);
			ClickController.touchSoundIsOn=true;
		}
	}
	public void removeOthers(){
		foreach(GameObject i in greens){
			i.SetActive(false);
		}
	}
	public void changeColour(){
		greens [0].SetActive (true);
		greens [12].SetActive (true);
		PlayerPrefs.SetInt("multiply",1);
		PlayerPrefs.SetInt("LevelType",1);
	}
	public void changeColour1(){
		greens [1].SetActive (true);
		greens [13].SetActive (true);
		PlayerPrefs.SetInt("multiply",2);
		PlayerPrefs.SetInt("LevelType",2);
	}
	public void changeColour2(){
		greens [2].SetActive (true);
		greens [14].SetActive (true);
		PlayerPrefs.SetInt("multiply",3);
		PlayerPrefs.SetInt("LevelType",3);
	}
	public void changeColour3(){
		greens [3].SetActive (true);
		greens [15].SetActive (true);
		PlayerPrefs.SetInt("multiply",4);
		PlayerPrefs.SetInt("LevelType",4);
	}
	public void changeColour4(){
		greens [4].SetActive (true);
		greens [16].SetActive (true);
		PlayerPrefs.SetInt("multiply",5);
		PlayerPrefs.SetInt("LevelType",5);
	}public void changeColour5(){
		greens [5].SetActive (true);
		greens [17].SetActive (true);
		PlayerPrefs.SetInt("multiply",6);
		PlayerPrefs.SetInt("LevelType",6);
	}public void changeColour6(){
		greens [6].SetActive (true);
		greens [18].SetActive (true);
		PlayerPrefs.SetInt("multiply",7);
		PlayerPrefs.SetInt("LevelType",7);
	}public void changeColour7(){
		greens [7].SetActive (true);
		greens [19].SetActive (true);
		PlayerPrefs.SetInt("multiply",8);
		PlayerPrefs.SetInt("LevelType",8);
	}public void changeColour8(){
		greens [8].SetActive (true);
		greens [20].SetActive (true);
		PlayerPrefs.SetInt("multiply",9);
		PlayerPrefs.SetInt("LevelType",9);
	}public void changeColour9(){
		greens [9].SetActive (true);
		greens [21].SetActive (true);
		PlayerPrefs.SetInt("multiply",10);
		PlayerPrefs.SetInt("LevelType",10);
	}public void changeColour10(){
		greens [10].SetActive (true);
		greens [22].SetActive (true);
		PlayerPrefs.SetInt("multiply",11);
		PlayerPrefs.SetInt("LevelType",11);
	}public void changeColour11(){
		greens [11].SetActive (true);
		greens [23].SetActive (true);
		PlayerPrefs.SetInt("multiply",12);
		PlayerPrefs.SetInt("LevelType",12);
	}
}