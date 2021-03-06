using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingEndScreenText : MonoBehaviour {
	float yPos;
	int count=0;
	void Start () {
		yPos = GameObject.Find ("EndScreenText").transform.position.y;
		FloatingEndScreenText ();
	}
	void FloatingEndScreenText(){
		GameObject.Find ("EndScreenText").GetComponent<Text>().text = "You got " + SpeedController.score;
		StartCoroutine ("MoveItDown");
	}
	IEnumerator MoveItDown(){
		count++;
		//yPos -= 10;
		GameObject.Find ("EndScreenText").transform.position -= new Vector3 (0,5,0);
		if (count < 30) {
			yield return new WaitForSeconds (0.005f);
			StartCoroutine ("MoveItDown");
		} else {
			yield return 0;
		}
	}
}
