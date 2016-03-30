using UnityEngine;
using System.Collections;

public class RightCurb : MonoBehaviour {

	bool right = false;
	public float rightSpeed = 10000;

	// Use this for initialization
	void Start () {
		right = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Right")) {
			right = true;
		} else {
			right = false;
		}
	}

	void OnTriggerEnter(Collider c) {
		if(c.gameObject.tag == "Player" && right) {
			c.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * rightSpeed * c.gameObject.GetComponent<Controller>().energy);
		}
	}
}
