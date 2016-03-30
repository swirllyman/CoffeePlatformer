using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public TutorialScript nextTip;
    public Canvas currentCanvas;
    public CameraControl levelStart;

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void ShowTip()
    {
        currentCanvas.gameObject.SetActive(true);
    }

    public void Clicked()
    {
        currentCanvas.gameObject.SetActive(false);

        if (levelStart == null)
            nextTip.ShowTip();
        else
            levelStart.StartTutorialLevel();
    }
}
