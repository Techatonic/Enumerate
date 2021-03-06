using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumbersFalling : MonoBehaviour {
	public GameObject thePrefab;
	int noOfObjects=0;
	GameObject[] numbersList;
	GameObject newObject;
	GameObject newObject1;
	GameObject newObject2;
	Canvas canvas;
	string nameOfObject;
	Vector3 vector;
	bool allowedToFall=false;
	int amountOfAllowed;
	int placeX1;
	int placeX2;
	int placeX3;
	int[] placesItCanFallX = {-550,-480,-410,-340,-270,-200,-130,-60,10,80,150};
	int[] placesItCanFallX1 = {-550,-480,-410,-340,440,510,580,650};
	int[] placesItCanFallX2 = {-550,-480,-410,-340,430,500,570,640};
	float speed;
	void Start(){
		speed = 5.5f;
		canvas = GameObject.Find ("Canvas").GetComponent<Canvas>();
		StartCoroutine ("InstantiatePrefab");
	}
	void Update(){
		CheckNumbers ();
	}
	IEnumerator InstantiatePrefab(){
		placeX1 = 15;
		placeX2 = 15;
		placeX3 = 15;
		if (SceneManager.GetActiveScene().buildIndex == 0 ||SceneManager.GetActiveScene().buildIndex==7) {
			placeX1 = placesItCanFallX [Random.Range (0, placesItCanFallX.Length)];
		} else if(SceneManager.GetActiveScene().buildIndex==5){
			placeX1=placesItCanFallX1[Random.Range(0,placesItCanFallX1.Length)];
		}
		else if(SceneManager.GetActiveScene().buildIndex==2){
			placeX1=placesItCanFallX2[Random.Range(0,placesItCanFallX2.Length)];
		}
		CheckNumberX (1);
		vector=new Vector3(placeX1,300,0);
		newObject=Instantiate (thePrefab, vector, Quaternion.identity) as GameObject;
		newObject.transform.SetParent (canvas.gameObject.transform, false);
		noOfObjects++;
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			placeX2 = placesItCanFallX [Random.Range (0, placesItCanFallX.Length)];
		} else if(SceneManager.GetActiveScene().buildIndex==5){
			placeX2=placesItCanFallX1[Random.Range(0,placesItCanFallX1.Length)];
		}
		else if(SceneManager.GetActiveScene().buildIndex==2){
			placeX2=placesItCanFallX2[Random.Range(0,placesItCanFallX2.Length)];
		}
		CheckNumberX (2);
		vector=new Vector3(placeX2,300,0);
		newObject=Instantiate (thePrefab, vector, Quaternion.identity) as GameObject;
		newObject.transform.SetParent (canvas.gameObject.transform, false);
		noOfObjects++;
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			placeX3 = placesItCanFallX [Random.Range (0, placesItCanFallX.Length)];
		} else if(SceneManager.GetActiveScene().buildIndex==5){
			placeX3=placesItCanFallX1[Random.Range(0,placesItCanFallX1.Length)];
		}
		else if(SceneManager.GetActiveScene().buildIndex==2){
			placeX3	=placesItCanFallX2[Random.Range(0,placesItCanFallX2.Length)];
		}
		CheckNumberX (3);
		vector=new Vector3(placeX3,300,0);
		newObject=Instantiate (thePrefab, vector, Quaternion.identity) as GameObject;
		newObject.transform.SetParent (canvas.gameObject.transform, false);
		noOfObjects++;
		GameObject[] ObjectsInScene = GameObject.FindGameObjectsWithTag ("Number");
		for(int i=0; i<ObjectsInScene.Length;i++){
			ObjectsInScene[i].GetComponent<Text>().fontSize=90;
			if(i+1==ObjectsInScene.Length||i+2==ObjectsInScene.Length||i+3==ObjectsInScene.Length){
				ObjectsInScene[i].GetComponent<Text>().text=(Random.Range(0,10)).ToString();
				ObjectsInScene[i].GetComponent<Text>().color=new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1);
			}
		}
		yield return new WaitForSeconds(1);
		StartCoroutine ("InstantiatePrefab");
	}
	void CheckNumberX(int whichX){
		if(whichX==1){
			if(placeX1==placeX2||placeX1==placeX3){
				if (SceneManager.GetActiveScene().buildIndex == 0||SceneManager.GetActiveScene().buildIndex==7) {
					placeX1 = placesItCanFallX [Random.Range (0, placesItCanFallX.Length)];
				} else if(SceneManager.GetActiveScene().buildIndex==5){
					placeX1=placesItCanFallX1[Random.Range(0,placesItCanFallX1.Length)];
				}
				else if(SceneManager.GetActiveScene().buildIndex==2){
					placeX1=placesItCanFallX2[Random.Range(0,placesItCanFallX2.Length)];
				}

				//CheckNumberX(1);
			}
		}
		else if(whichX==2){
			if(placeX2==placeX1||placeX2==placeX3){
				if (SceneManager.GetActiveScene().buildIndex == 0||SceneManager.GetActiveScene().buildIndex==7) {
					placeX2 = placesItCanFallX [Random.Range (0, placesItCanFallX.Length)];
				} else if(SceneManager.GetActiveScene().buildIndex==5){
					placeX2=placesItCanFallX1[Random.Range(0,placesItCanFallX1.Length)];
				}
				else if(SceneManager.GetActiveScene().buildIndex==2){
					placeX2=placesItCanFallX2[Random.Range(0,placesItCanFallX2.Length)];
				}
				//CheckNumberX(2);
			}
		}
		else if(whichX==3){
			if(placeX3==placeX2||placeX3==placeX1){
				if (SceneManager.GetActiveScene().buildIndex == 0||SceneManager.GetActiveScene().buildIndex==7) {
					placeX3 = placesItCanFallX [Random.Range (0, placesItCanFallX.Length)];
				} else if(SceneManager.GetActiveScene().buildIndex==5){
					placeX3=placesItCanFallX1[Random.Range(0,placesItCanFallX1.Length)];
				}
				else if(SceneManager.GetActiveScene().buildIndex==2){
					placeX3=placesItCanFallX2[Random.Range(0,placesItCanFallX2.Length)];
				}
				//CheckNumberX(3);
			}
		}
	}
	void CheckNumbers(){
		numbersList=GameObject.FindGameObjectsWithTag("Number");
		//i is the one at the top and otherOne is at the bottom
		foreach(GameObject i in numbersList){
			if(i.transform.position.y>95){
				amountOfAllowed=0;
				foreach(GameObject otherOne in numbersList){
					if(Mathf.Round(i.transform.position.y-33)==Mathf.Round(otherOne.transform.position.y)&&i.transform.position.x==otherOne.transform.position.x){
						break;
					}
					else{
						amountOfAllowed++;
					}
				}
				if(amountOfAllowed==numbersList.Length){
					i.transform.position-=new Vector3(0,speed,0);
				}
			}
			StartCoroutine (checkYOfNumbers(i));
		}
	}
	IEnumerator checkYOfNumbers(GameObject i){
		float firstY = i.transform.position.y;
		yield return new WaitForSeconds (0.01f);
		float secondY = i.transform.position.y;
		if(firstY==secondY&&firstY>250){
			Destroy(i);
		}
	}
}