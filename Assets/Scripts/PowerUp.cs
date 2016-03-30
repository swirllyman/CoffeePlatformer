using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public float startHeight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, Time.deltaTime*200, 0);
		transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*15, 10) + startHeight, transform.position.z);
	}
}
