using UnityEngine;
using System.Collections;

public class LeftCurb : MonoBehaviour {

	bool left = false;
	public float leftSpeed = 100;

	// Use this for initialization
	void Start () {
		left = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Left")) {
			left = true;
		} else {
			left = false;
		}
	}

	void OnTriggerEnter(Collider c) {
		if(c.gameObject.tag == "Player" && left) {
			c.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * leftSpeed * c.gameObject.GetComponent<Controller>().energy);
		}
	}
}
