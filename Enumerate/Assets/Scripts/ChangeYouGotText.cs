using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeYouGotText : MonoBehaviour {
	void Start(){
		if(SceneManager.GetActiveScene().buildIndex==2){
			GameObject.Find("You Got Text").GetComponent<TextMesh>().text="You Got To "+SpeedController.score;
		}
	}
}