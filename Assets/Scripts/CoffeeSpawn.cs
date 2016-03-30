using UnityEngine;
using System.Collections;

public class CoffeeSpawn : MonoBehaviour {

	private float disableTime = 2.0f;
	private float counter = 0.0f;

	private bool active;

	public GameObject coffee;

	// Use this for initialization
	void Start () {
		Instantiate(coffee, transform.position, Quaternion.identity);
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!active) {
			gameObject.GetComponent<ParticleSystem>().enableEmission = false;
			counter += Time.deltaTime;
		} else {
			gameObject.GetComponent<ParticleSystem>().enableEmission = true;
		}
		if(counter >= disableTime) {
			active = true;
			counter = 0.0f;
			spawn();
		}
	}


	void spawn() {
		Instantiate(coffee, transform.position, Quaternion.identity);
		//StartCoroutine (spawnFlash (newBean));
	}

	void OnTriggerEnter(Collider c) {
		if(c.gameObject.tag == "Player") {
			active = false;
		}
	}

//	IEnumerator spawnFlash(GameObject g) {
////		g.GetComponent<Renderer>().enabled = false;
////		yield return new WaitForSeconds(.15f);
////		g.GetComponent<Renderer>().enabled = true;
////		yield return new WaitForSeconds(.15f);
////		g.GetComponent<Renderer>().enabled = false;
////		yield return new WaitForSeconds(.15f);
////		g.GetComponent<Renderer>().enabled = true;
////		yield return new WaitForSeconds(.15f);
////		g.GetComponent<Renderer>().enabled = false;
////		yield return new WaitForSeconds(.15f);
////		g.GetComponent<Renderer>().enabled = true;
////		yield return new WaitForSeconds(.15f);
////		g.GetComponent<Renderer>().enabled = false;
////		yield return new WaitForSeconds(.15f);
////		g.GetComponent<Renderer>().enabled = true;
//	}
}
