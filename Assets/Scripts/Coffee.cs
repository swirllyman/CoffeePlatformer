using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Time.deltaTime*200, Time.deltaTime*200, Time.deltaTime*200);
	}
}
