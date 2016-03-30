using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	float [] bestTimes = new float[11];
	bool[] worlds = new bool[5];

	void Awake() {

	}

	void Start () {
		worlds[0] = true;
		ScoreKeeper sk = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        if (sk != null)
            sk.sendBestTimes();
        else
        {
            //Instantiate()
        }
		//GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("sendBestTimes");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void levelScore(float[] num) {
		bestTimes = num;
	}

	void OnGUI() {

		GUI.Box (new Rect(Screen.width/2 - 200, Screen.height * .05f, 400, 50), "Select your level");
			//Tutorial
			if(GUI.Button (new Rect(Screen.width/2 - 250, Screen.height * .2f, 200, 50), "Tutorial")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 0.0f);
				Application.LoadLevel ("Tutorial");
			}

        //Tutorial 2
        if (GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height * .2f, 200, 50), "Tutorial 2"))
        {
            GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 0.0f);
            Application.LoadLevel("Tutorial 2");
        }
        GUI.Box (new Rect(Screen.width/2 - 75,  Screen.height * .3f, 150, 40), "Best Tutorial Time:\n" + bestTimes[0].ToString("F2"));


        //		//World Chooser
        GUI.BeginGroup(new Rect(Screen.width * .06f, Screen.height * .39f, Screen.width - (Screen.width * .06f), Screen.height*.1f));
		GUI.Box(new Rect(0, 0, (Screen.width * .15f)*5 + 60, Screen.height*.05f), "");

		//World 1
		if(worlds[0]) {
			GUI.Box (new Rect(10, 5, Screen.width*.15f, Screen.height*.035f), "World 1");
		} else {
			if(GUI.Button (new Rect(10, 5, Screen.width*.15f, Screen.height*.035f), "World 1")) {
				worlds[0] = true;
				worlds[1] = false;
				worlds[2] = false;
				worlds[3] = false;
				worlds[4] = false;
			}
		}

		//World 2
		if(worlds[1]) {
			GUI.Box (new Rect(Screen.width*.15f + 20, 5, Screen.width*.15f, Screen.height*.035f), "World 2");
		} else {
			if(GUI.Button (new Rect(Screen.width*.15f + 20, 5, Screen.width*.15f, Screen.height*.035f), "World 2")) {
				worlds[0] = false;
				worlds[1] = true;
				worlds[2] = false;
				worlds[3] = false;
				worlds[4] = false;
			}
		}

		//World 3
		if(worlds[2]) {
			GUI.Box (new Rect(Screen.width*.3f + 30, 5, Screen.width*.15f, Screen.height*.035f), "World 3");
		} else {
			if(GUI.Button (new Rect(Screen.width*.3f + 30, 5, Screen.width*.15f, Screen.height*.035f), "World 3")) {
				worlds[0] = false;
				worlds[1] = false;
				worlds[2] = true;
				worlds[3] = false;
				worlds[4] = false;
			}
		}


		//World 4
		if(worlds[3]) {
			GUI.Box (new Rect(Screen.width*.45f + 40, 5, Screen.width*.15f, Screen.height*.035f), "World 4");
		} else {
			if(GUI.Button (new Rect(Screen.width*.45f + 40, 5, Screen.width*.15f, Screen.height*.035f), "World 4")) {
				worlds[0] = false;
				worlds[1] = false;
				worlds[2] = false;
				worlds[3] = true;
				worlds[4] = false;
			}
		}
		//World 5
		if(worlds[4]) {
			GUI.Box (new Rect(Screen.width*.6f + 50, 5, Screen.width*.15f, Screen.height*.035f), "World 5");
		} else{
			if(GUI.Button (new Rect(Screen.width*.6f + 50, 5, Screen.width*.15f, Screen.height*.035f), "World 5")) {
				worlds[0] = false;
				worlds[1] = false;
				worlds[2] = false;
				worlds[3] = false;
				worlds[4] = true;
			}
		}
		GUI.EndGroup();


		//World 1
		if(worlds[0]){
			GUI.BeginGroup(new Rect(Screen.width * .2f, Screen.height * .45f, Screen.width - (Screen.width * .2f), Screen.height*.5f));
			GUI.Box (new Rect(0, 0, (Screen.width * .1f)*5 + 60, Screen.height *.5f), "");

			for(int i = 0; i < 5; i++) {
				//Level 1
				if(GUI.Button (new Rect(10 + (Screen.width * (i * .1f)) + i*10, 10, Screen.width*.1f, Screen.height*.1f), "Level " + (i+1))) {
					GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", i+1);
					Application.LoadLevel ("Level " + (i+1).ToString());
				}
				GUI.Box (new Rect((Screen.width * (i * .1f)) + i*10 + 10, Screen.height*.1f+20, Screen.width*.1f, Screen.height*.075f), "Best Time:\n" + bestTimes[i+1].ToString("F2"));
			}
			for(int i = 0; i < 5; i++) {
				GUI.Box (new Rect(10 + (Screen.width * (i * .1f)) + i*10, Screen.height*.25f, Screen.width*.1f, Screen.height*.1f), "Level " + (i+6));
			//			if(GUI.Button (new Rect(10, Screen.height*.25f, Screen.width*.15f, Screen.height*.1f), "Level 6")) {
			//				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 6);
//							Application.LoadLevel ("Level " + (i+6).ToString());
			//			}
			//			GUI.Box (new Rect(10, Screen.height*.35f+10, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[6].ToString("F2"));
			}
			GUI.EndGroup();
		}

		if(worlds[1]){
			/*
			GUI.BeginGroup(new Rect(Screen.width * .06f, Screen.height * .45f, Screen.width - (Screen.width * .06f), Screen.height*.5f));
			GUI.Box (new Rect(0, 0, (Screen.width * .15f)*5 + 60, Screen.height *.5f), "");
			
			//Level 1
			if(GUI.Button (new Rect(10, 10, Screen.width*.15f, Screen.height*.1f), "Level 11")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 1);
				Application.LoadLevel ("Level 1");
			}
			GUI.Box (new Rect(10, Screen.height*.1f+20, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[1].ToString("F2"));
			
			//Level 2
			if(GUI.Button (new Rect(Screen.width*.15f + 20, 10, Screen.width*.15f, Screen.height*.1f), "Level 12")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 2);
				Application.LoadLevel ("Level 2");
			}
			GUI.Box (new Rect(Screen.width*.15f + 20, Screen.height*.1f+20, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[2].ToString("F2"));
			
			//Level 3
			if(GUI.Button (new Rect(Screen.width*.3f + 30, 10, Screen.width*.15f, Screen.height*.1f), "Level 13")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 3);
				Application.LoadLevel ("Level 3");
			}
			GUI.Box (new Rect(Screen.width*.3f + 30, Screen.height*.1f+20, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[3].ToString("F2"));
			
			//Level 4
			if(GUI.Button (new Rect(Screen.width*.45f + 40, 10, Screen.width*.15f, Screen.height*.1f), "Level 14")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 4);
				Application.LoadLevel ("Level 4");
			}
			GUI.Box (new Rect(Screen.width*.45f + 40, Screen.height*.1f+20, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[4].ToString("F2"));
			
			//Level 5
			if(GUI.Button (new Rect(Screen.width*.6f + 50, 10, Screen.width*.15f, Screen.height*.1f), "Level 15")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 5);
				Application.LoadLevel ("Level 5");
			}
			GUI.Box (new Rect(Screen.width*.6f + 50, Screen.height*.1f+20, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[5].ToString("F2"));
			
			//Level 6
			if(GUI.Button (new Rect(10, Screen.height*.25f, Screen.width*.15f, Screen.height*.1f), "Level 16")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 6);
				Application.LoadLevel ("Level 6");
			}
			GUI.Box (new Rect(10, Screen.height*.35f+10, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[6].ToString("F2"));
			
			//Level 7
			if(GUI.Button (new Rect(Screen.width*.15f + 20, Screen.height*.25f, Screen.width*.15f, Screen.height*.1f), "Level 17")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 2);
				Application.LoadLevel ("Level 7");
			}
			GUI.Box (new Rect(Screen.width*.15f + 20, Screen.height*.35f+10, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[7].ToString("F2"));
			
			//Level 8
			if(GUI.Button (new Rect(Screen.width*.3f + 30, Screen.height*.25f, Screen.width*.15f, Screen.height*.1f), "Level 18")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 3);
				Application.LoadLevel ("Level 8");
			}
			GUI.Box (new Rect(Screen.width*.3f + 30, Screen.height*.35f+10, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[8].ToString("F2"));
			
			//Level 9
			if(GUI.Button (new Rect(Screen.width*.45f + 40, Screen.height*.25f, Screen.width*.15f, Screen.height*.1f), "Level 19")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 4);
				Application.LoadLevel ("Level 9");
			}
			GUI.Box (new Rect(Screen.width*.45f + 40,Screen.height*.35f+10, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[9].ToString("F2"));
			
			//Level 10
			if(GUI.Button (new Rect(Screen.width*.6f + 50, Screen.height*.25f, Screen.width*.15f, Screen.height*.1f), "Level 20")) {
				GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setCurrentLevel", 5);
				Application.LoadLevel ("Level 10");
			}
			GUI.Box (new Rect(Screen.width*.6f + 50, Screen.height*.35f+10, Screen.width*.15f, Screen.height*.075f), "Best Time:\n" + bestTimes[10].ToString("F2"));
			
			GUI.EndGroup();
			*/
		} 

		if(GUI.Button(new Rect(Screen.width-100, Screen.height - 100, 75, 35), "Exit")){
			Application.Quit();
		}
	}
}
