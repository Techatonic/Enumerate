using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHighscores : MonoBehaviour {
	public Text[] highscoreFields;
	public Text[] highscoreFields1;
	public Text[] highscoreFields2;
	public Text[] highscoreFields3;
	public Text[] highscoreFields4;
	public Text[] highscoreFields5;
	public Text[] highscoreFields6;
	public Text[] highscoreFields7;
	public Text[] highscoreFields8;
	public Text[] highscoreFields9;
	public Text[] highscoreFields10;
	public Text[] highscoreFields11;
	public Text[] highscoreFields12;

	public Text[] yourhighscoreField;

	public GameObject highscore1;
	public GameObject highscore2;
	public GameObject highscore3;
	public GameObject highscore4;
	public GameObject highscore5;
	public GameObject highscore6;
	public GameObject highscore7;
	public GameObject highscore8;
	public GameObject highscore9;
	public GameObject highscore10;
	public GameObject highscore11;
	public GameObject highscore12;
	public GameObject highscore13;

	public GameObject yourScore1;
	public GameObject yourScore2;
	public GameObject yourScore3;
	public GameObject yourScore4;
	public GameObject yourScore5;
	public GameObject yourScore6;
	public GameObject yourScore7;
	public GameObject yourScore8;
	public GameObject yourScore9;
	public GameObject yourScore10;
	public GameObject yourScore11;
	public GameObject yourScore12;
	public GameObject yourScore13;

	public static int whichLeaderboardAreYouOn=1;
	public static int numberDoneSoFar=0;
	Highscores highscoresManager;
	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields1.Length; i ++) {
			highscoreFields1[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields2.Length; i ++) {
			highscoreFields2[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields3.Length; i ++) {
			highscoreFields3[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields4.Length; i ++) {
			highscoreFields4[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields5.Length; i ++) {
			highscoreFields5[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields6.Length; i ++) {
			highscoreFields6[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields7.Length; i ++) {
			highscoreFields7[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields8.Length; i ++) {
			highscoreFields8[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields9.Length; i ++) {
			highscoreFields9[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields10.Length; i ++) {
			highscoreFields10[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields11.Length; i ++) {
			highscoreFields11[i].text = i+1 + ". Fetching...";
		}
		for (int i = 0; i < highscoreFields12.Length; i ++) {
			highscoreFields12[i].text = i+1 + ". Fetching...";
		}
		highscoresManager = GetComponent<Highscores>();
		StartCoroutine(RefreshHighscores(0));
	}
	public void OnHighscoresDownloaded(Highscore[] highscoreList) {
		if(numberDoneSoFar==1){
			for (int i =0; i < highscoreFields.Length; i ++) {
				highscoreFields[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields[i].text += characters[j];
						}
					}
					highscoreFields[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore1.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore1.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(1));
		}
		else if(numberDoneSoFar==2){
			for (int i =0; i < highscoreFields1.Length; i ++) {
				highscoreFields1[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields1[i].text += characters[j];
						}
					}
					highscoreFields1[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields1[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore2.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore2.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(2));
		}
		else if(numberDoneSoFar==3){
			for (int i =0; i < highscoreFields2.Length; i ++) {
				highscoreFields2[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields2[i].text += characters[j];
						}
					}
					highscoreFields2[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields2[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore3.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore3.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(3));
		}
		else if(numberDoneSoFar==4){
			for (int i =0; i < highscoreFields3.Length; i ++) {
				highscoreFields3[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields3[i].text += characters[j];
						}
					}
					highscoreFields3[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields3[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore4.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore4.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(4));
		}
		else if(numberDoneSoFar==5){
			for (int i =0; i < highscoreFields4.Length; i ++) {
				highscoreFields4[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields4[i].text += characters[j];
						}
					}
					highscoreFields4[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields4[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore5.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore5.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(5));
		}
		else if(numberDoneSoFar==6){
			for (int i =0; i < highscoreFields5.Length; i ++) {
				highscoreFields5[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields5[i].text += characters[j];
						}
					}
					highscoreFields5[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields5[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore6.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore6.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(6));
		}
		else if(numberDoneSoFar==7){
			for (int i =0; i < highscoreFields6.Length; i ++) {
				highscoreFields6[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields6[i].text += characters[j];
						}
					}
					highscoreFields6[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields6[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore7.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore7.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(7));
		}
		else if(numberDoneSoFar==8){
			for (int i =0; i < highscoreFields7.Length; i ++) {
				highscoreFields7[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields7[i].text += characters[j];
						}
					}
					highscoreFields7[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields7[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore8.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore8.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(8));
		}
		else if(numberDoneSoFar==9){
			for (int i =0; i < highscoreFields8.Length; i ++) {
				highscoreFields8[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields8[i].text += characters[j];
						}
					}
					highscoreFields8[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields8[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore9.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore9.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(9));
		}
		else if(numberDoneSoFar==10){
			for (int i =0; i < highscoreFields9.Length; i ++) {
				highscoreFields9[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields9[i].text += characters[j];
						}
					}
					highscoreFields9[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields9[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore10.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore10.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(10));
		}
		else if(numberDoneSoFar==11){
			for (int i =0; i < highscoreFields10.Length; i ++) {
				highscoreFields10[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields10[i].text += characters[j];
						}
					}
					highscoreFields10[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields10[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore11.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore11.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(11));
		}
		else if(numberDoneSoFar==12){
			for (int i =0; i < highscoreFields11.Length; i ++) {
				highscoreFields11[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields11[i].text += characters[j];
						}
					}
					highscoreFields11[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields11[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore12.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore12.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
			StartCoroutine(RefreshHighscores(12));
		}
		else if(numberDoneSoFar==13){
			for (int i =0; i < highscoreFields12.Length; i ++) {
				highscoreFields12[i].text = i+1 + ". ";
				if (i < highscoreList.Length) {
					string[] characters=new string[highscoreList[i].username.Length];
					for(int j=0;j<highscoreList[i].username.Length;j++){
						characters[j]=highscoreList[i].username[j].ToString();
						if(j<6){
							highscoreFields12[i].text += characters[j];
						}
					}
					highscoreFields12[i].text += " - " + highscoreList[i].score;
				}
				else if(i<=10){
					highscoreFields12[i].text+=" N/A";
				}
			}
			bool gotUsername=false;
			for(int i=0;i<highscoreList.Length;i++){
				if(highscoreList[i].username==ClickController.username){
					yourScore13.GetComponent<Text>().text=(i+1) +". You - "+highscoreList[i].score;
					gotUsername=true;
				}
			}
			if(!gotUsername){
				yourScore13.GetComponent<Text>().text="         N/A";
			}
			gotUsername=false;
		}
	}
	
	public IEnumerator RefreshHighscores(int numberToDo) {
		highscoresManager.DownloadHighscores(numberToDo);
		numberDoneSoFar = numberToDo+1;
		yield return new WaitForSeconds(0.5f);
	}
	public void goUpOne(){
		if (whichLeaderboardAreYouOn != 13) {
			whichLeaderboardAreYouOn++;
		} else {
			whichLeaderboardAreYouOn=1;
		}
		checkWhichLeaderboard ();
	}
	public void goDownOne(){
		if (whichLeaderboardAreYouOn != 1) {
			whichLeaderboardAreYouOn--;
		} else {
			whichLeaderboardAreYouOn=13;
		}
		checkWhichLeaderboard ();
	}
	public void checkWhichLeaderboard(){
		if(whichLeaderboardAreYouOn==1){
			clicked1();
		}
		else if(whichLeaderboardAreYouOn==2){
			clicked2();
		}
		else if(whichLeaderboardAreYouOn==3){
			clicked3();
		}
		else if(whichLeaderboardAreYouOn==4){
			clicked4();
		}
		else if(whichLeaderboardAreYouOn==5){
			clicked5();
		}
		else if(whichLeaderboardAreYouOn==6){
			clicked6();
		}
		else if(whichLeaderboardAreYouOn==7){
			clicked7();
		}
		else if(whichLeaderboardAreYouOn==8){
			clicked8();
		}
		else if(whichLeaderboardAreYouOn==9){
			clicked9();
		}
		else if(whichLeaderboardAreYouOn==10){
			clicked10();
		}
		else if(whichLeaderboardAreYouOn==11){
			clicked11();
		}
		else if(whichLeaderboardAreYouOn==12){
			clicked12();
		}
		else if(whichLeaderboardAreYouOn==13){
			clicked13();
		}
	}
	public void clicked1(){
		highscore1.SetActive (true);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked2(){
		highscore1.SetActive (false);
		highscore2.SetActive (true);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked3(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (true);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked4(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (true);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked5(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (true);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked6(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (true);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked7(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (true);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked8(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (true);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked9(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (true);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked10(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (true);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked11(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (true);
		highscore12.SetActive (false);
		highscore13.SetActive (false);
	}
	public void clicked12(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (true);
		highscore13.SetActive (false);
	}
	public void clicked13(){
		highscore1.SetActive (false);
		highscore2.SetActive (false);
		highscore3.SetActive (false);
		highscore4.SetActive (false);
		highscore5.SetActive (false);
		highscore6.SetActive (false);
		highscore7.SetActive (false);
		highscore8.SetActive (false);
		highscore9.SetActive (false);
		highscore10.SetActive (false);
		highscore11.SetActive (false);
		highscore12.SetActive (false);
		highscore13.SetActive (true);
	}
}