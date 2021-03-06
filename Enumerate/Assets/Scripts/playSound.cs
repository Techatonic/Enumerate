using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class playSound : MonoBehaviour {
	public static Transform transform=transform;
	public static AudioSource sfx;
	void Start(){
		sfx = GetComponent<AudioSource> ();
	}
	public static void playSoundVoid(){
		if(ClickController.touchSoundIsOn){
			sfx.Play ();
		}
	}
}
