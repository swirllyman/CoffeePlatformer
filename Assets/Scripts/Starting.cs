using UnityEngine;
using System.Collections;

public class Starting : MonoBehaviour {

	public GameObject sk;

	// Use this for initialization
	void Start () {
		Instantiate (sk);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Box(new Rect(Screen.width/2-400, Screen.height*.2f, 800, 300), "Coffee Platformer");
		if(GUI.Button(new Rect(Screen.width/2-100, Screen.height*.75f, 200, 50), "Start")){
			Application.LoadLevel("Level Select");
		}
		if(GUI.Button(new Rect(Screen.width/2-100, Screen.height*.85f, 200, 50), "Load")){
			GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("loadScores");
			Application.LoadLevel("Level Select");
		}
	}
}
