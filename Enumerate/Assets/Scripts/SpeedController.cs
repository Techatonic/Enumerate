using UnityEngine;

public class SpeedController : MonoBehaviour {
	public static float speed=0.6F;
	public static int score=0;
	public static float otherScore=0f;
	public static int whichOne;
	public static string whichOneName;
	public static int[] red =   {0,0,255,255,204,255,153,0,51};
	public static int[] green = {255,230,255,204,51,153,255,153,51};
	public static int[] blue =  {0,230,0,0,255,230,204,0,204};
	public static int numberOfColor=0;

	public static float correctAnswer;
	public static int randomNumber1;
	public static int randomNumber2;
	public static float randomNumber11;
	public static float randomNumber22;

	public static int[] highscores = {
		PlayerPrefs.GetInt ("highscore1"),
		PlayerPrefs.GetInt ("highscore2"),
		PlayerPrefs.GetInt ("highscore3"),
		PlayerPrefs.GetInt ("highscore4"),
		PlayerPrefs.GetInt ("highscore5"),
		PlayerPrefs.GetInt ("highscore6"),
		PlayerPrefs.GetInt ("highscore7"),
		PlayerPrefs.GetInt ("highscore8"),
		PlayerPrefs.GetInt ("highscore9"),
		PlayerPrefs.GetInt ("highscore10"),
		PlayerPrefs.GetInt ("highscore11"),
		PlayerPrefs.GetInt ("highscore12"),
		PlayerPrefs.GetInt ("highscore13"),
	};
	public static void Correct(){
		if (PlayerPrefs.GetInt ("multiply") == 13) {
			score += 1;
		} else {
			score += PlayerPrefs.GetInt("multiply");
		}
		otherScore += 0.1f;
		CheckIfGoneTooFar ();
		whichOne = Random.Range (0,5);
		GameObject.Find ("SquaresTest (" + whichOne + ")").GetComponentInChildren<TextMesh>().text=(score+PlayerPrefs.GetInt("multiply")).ToString();
		ChooseNumbers (false);
		Color newColor = new Color ();
		foreach (GameObject hello in ClickController.cubes) {
			hello.transform.position = new Vector3 (hello.transform.position.x, 0, 20);
			if(Mathf.Approximately(otherScore,Mathf.RoundToInt(otherScore))){
				newColor=new Color(red[numberOfColor],green[numberOfColor],blue[numberOfColor]);
				hello.GetComponent<Renderer>().material.color=newColor;
			}
		}
		if (Mathf.Approximately (otherScore, Mathf.RoundToInt (otherScore))) {
			if(numberOfColor==red.Length){
				numberOfColor=0;
			}
			else{
				numberOfColor++;
			}
		}
		ClickController.clicked=false;
		if (score < 15) {
			speed += 0.05F;
		} else {
			speed += 0.01F;
		}
		ClickController.thisSpeed = speed;
	}
	public static void CheckIfGoneTooFar(){
		if (ClickController.cubes[0].transform.position.z <=1){
			ClickController.Die();
		}
		if (ClickController.cubes[0].transform.position.z>0.7){
			ClickController.clicked=false;
		}
	}
	public static void Start(){
		ChooseNumbers (true);
	}
	public static void ChooseNumbers(bool IsItStart){
		if(PlayerPrefs.GetInt("multiply")==13){
			randomNumber1 = Random.Range (0,13);
			randomNumber2 = Random.Range (0,13);
			randomNumber11 = randomNumber1;
			randomNumber22 = randomNumber2;
			GameObject.Find ("Multiply Text").GetComponent<TextMesh>().text=randomNumber1+"*"+randomNumber2;
			
			correctAnswer = randomNumber1 * randomNumber2;
			GameObject.Find ("SquaresTest (" + SpeedController.whichOne + ")").GetComponentInChildren<TextMesh> ().text = correctAnswer.ToString ();
		}
		for(var i=0; i<=4;i++){
			if(i!=whichOne&&IsItStart){
				GameObject.Find("SquaresTest (" + i + ")").GetComponentInChildren<TextMesh>().text=UnityEngine.Random.Range(1,10).ToString();
				if(GameObject.Find("SquaresTest (" + i + ")").GetComponentInChildren<TextMesh>().text=="0"){
					ChooseNumbers(true);
				}
			}
			else if(i!=whichOne){
				GameObject.Find("SquaresTest (" + i + ")").GetComponentInChildren<TextMesh>().text=UnityEngine.Random.Range(1,score*5).ToString();
				if(GameObject.Find("SquaresTest (" + i + ")").GetComponentInChildren<TextMesh>().text=="0"){
					ChooseNumbers(false);
				}
			}
			string daNumber=GameObject.Find("SquaresTest (" + i + ")").GetComponentInChildren<TextMesh>().text;
			GameObject.Find("SquaresTest (" + i + ")").GetComponentInChildren<TextMesh>().text="";
			for(int j=0;j<daNumber.Length;j++){
				GameObject.Find("SquaresTest (" + i + ")").GetComponentInChildren<TextMesh>().text+=daNumber[j]+" ";
			}

		}
	}
}