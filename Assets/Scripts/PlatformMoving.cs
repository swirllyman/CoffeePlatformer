using UnityEngine;
using System.Collections;

public class PlatformMoving : MonoBehaviour {

	public float start;
	public float end;
	public float speed = 50;
	public bool vertical = false;
	private bool stopped;
	private float timer;

	// Use this for initialization
	void Start () {
		stopped = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!stopped){
			timer += Time.deltaTime;
			if(!vertical){
				transform.position = new Vector3(Mathf.PingPong(timer * speed, end) + start, transform.position.y, transform.position.z);
			}
			else {
				transform.position = new Vector3(transform.position.x, Mathf.PingPong(timer * speed, end) + start, transform.position.z);
			}
		}
	}

	void setStop(bool stop){
		stopped = stop;
	}
}
