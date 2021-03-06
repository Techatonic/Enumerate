using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class GoToHighScoreSceneScript : MonoBehaviour {
	bool internetConnection;
	public GameObject noInternetButton;
	public void GoToHighScoreSceneVoid(){
		StartCoroutine ("checkInternetConnection");
	}
	public IEnumerator checkInternetConnection(){
		WWW www = new WWW ("http://google.com");
		yield return www;
		if(www.error!=null){
			internetConnection=false;
		}else{
			internetConnection=true;
		}
		if (internetConnection) {
		    ClickController.shouldBe++;
		    DontDestroyOnLoad (GameObject.Find("Music"));
		    SceneManager.LoadScene (3);
		} else {
			noInternetButton.SetActive(true);
		}
	}
	public void noInternetButtonPressed(){
		noInternetButton.SetActive (false);
	}
}