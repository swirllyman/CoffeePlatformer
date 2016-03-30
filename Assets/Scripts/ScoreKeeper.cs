using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	bool showCurrentScore;

	float [] levelScores = new float[11];
	float [] levelCheckpoint = new float[11];
	int currentLevel;
	float currentLevelTime;

	GameObject levelSelect;

	void Awake () {
		showCurrentScore = false;
		DontDestroyOnLoad(gameObject);
	}

	void createCheckpoint(int num){
		levelCheckpoint[currentLevel] = num;
	}


	void setCurrentLevel(int level){
		currentLevel = level;
		showCurrentScore = true;
	}

	void setBestTime(float currentTime) {
		if(levelScores[currentLevel] < 1.0f) {
			levelScores[currentLevel] = currentTime;

		}
		else if(levelScores[currentLevel] > currentTime) {
			levelScores[currentLevel] = currentTime;
		}
		saveScores ();
	}

	public void sendBestTimes () {
		showCurrentScore = false;
		GameObject.FindGameObjectWithTag("LevelSelect").SendMessage("levelScore", levelScores);
	}

	void OnGUI() {
		if(showCurrentScore){
			GUI.Box (new Rect(120, 50, 120, 35), "Level Best: " + levelScores[currentLevel].ToString ("F2"));
		}
	}


	void saveScores() {
		for (int i = 0; i < levelScores.Length; i++) {
			PlayerPrefs.SetFloat(i.ToString (), levelScores[i]);
		}
	}

	void loadScores() {
		for (int i = 0; i < levelScores.Length; i++) {
			levelScores[i] = PlayerPrefs.GetFloat (i.ToString ());
		}
	}
}
