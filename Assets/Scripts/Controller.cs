using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	bool left;
	bool right;
	public bool jumping;
	public bool grounded;

	public int energyCD;
	public float energy;
	public bool energized;
	private bool energyGain;
	private float energyGainAmount;

	public float timer;
	public bool stopTime;


	private bool onGround;
	public float movement = 100;
	public float jumpAmount = 25000;
	public float fallingAmount = 1000;
	private Vector3 moving;

	private bool win;
	public bool pause;



	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(200, 20);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;




	private bool energyCollect;
	private float collectionWaitTimer = .75f;


	private bool [] climbing = new bool[3];



	public Material baseColor;
	public Material energizedColor;

	public GameObject checkpoint;
	public bool checkpointPlaced;

	public GameObject filter;

//	void Awake() {
//		climbing[0] = false;
//		climbing[1] = false;
//		climbing[2] = false;
//		grounded = true;
//		if(checkpoint.gameObject.activeInHierarchy) {
//			checkpointPlaced = true;
//		} else {
//			checkpointPlaced = false;
//		}
//	}

	// Use this for initialization
	void Start () {
		climbing[0] = false;
		climbing[1] = false;
		climbing[2] = false;
		grounded = true;
//		if(checkpoint.gameObject.activeInHierarchy) {
//			checkpointPlaced = true;
//		} else {
//			checkpointPlaced = false;
//		}
		energyCollect = false;
		win = false;
		pause = true;
		energy = 1.0f;
		jumping = false;
		left = false;
		right = false;
	}



	void FixedUpdate() {
		if(!stopTime) {
			if(!win && !pause) {
				timer += Time.deltaTime;
			}
		}

		if(energyCollect) {
			collectionWaitTimer -= Time.deltaTime;
		}

		if(collectionWaitTimer <= 0.0f) {
			energyCollect = false;
		}



		//actual movement
		if(energy > 2.5f) {
			if(climbing[0]) {   //left side
				Physics.gravity = new Vector3(9.81f + fallingAmount, 0, 0);
				if(left) {
					transform.Translate(new Vector3(0, -1, 0) * (energy * 1.5f));
				}
				if(right) {
					transform.Translate(new Vector3(0, 1, 0) * (energy * 1.5f));
				}
			} else if(climbing[1]) { //right side
				Physics.gravity = new Vector3(-9.81f - fallingAmount, 0, 0);
				if(left) {
					transform.Translate(new Vector3(0, 1, 0) * (energy * 1.5f));
				}
				if(right) {
					transform.Translate(new Vector3(0, -1, 0) * (energy * 1.5f));
				}
			} else if(climbing[2]) { //underneath
				Physics.gravity = new Vector3(0, 9.81f + fallingAmount, 0);
				if(left) {
					transform.Translate(new Vector3(1, 0, 0) * (energy * 1.5f));
				}
				if(right) {
					transform.Translate(new Vector3(-1, 0, 0) * (energy * 1.5f));
				}
			}else if(grounded){
				Physics.gravity = new Vector3(0, -9.81f, 0);
				if(left) {
					transform.Translate(new Vector3(-1, 0, 0) * (energy * 1.5f));
				}
				if(right) {
					transform.Translate(new Vector3(1, 0, 0) * (energy * 1.5f));
				}
			} else {
				Physics.gravity = new Vector3(0, -9.81f, 0);
				gameObject.GetComponent<Rigidbody>().AddForce(0, -fallingAmount, 0);
				if(left) {
					gameObject.GetComponent <Rigidbody>().AddForce(-movement * energy, 0, 0);
				}
				if(right) {
					gameObject.GetComponent <Rigidbody>().AddForce(movement * energy, 0, 0);
				}
			}
		} else {
			if(grounded){
				Physics.gravity = new Vector3(0, -9.81f, 0);
				if(left) {
					transform.Translate(new Vector3(-1, 0, 0) * (energy * 1.5f));
				}
				if(right) {
					transform.Translate(new Vector3(1, 0, 0) * (energy * 1.5f));
				}
			} else {
				Physics.gravity = new Vector3(0, -9.81f, 0);
				gameObject.GetComponent<Rigidbody>().AddForce(0, -fallingAmount, 0);
				if(left) {
					gameObject.GetComponent <Rigidbody>().AddForce(-movement * (energy * 3), 0, 0);
				}
				if(right) {
					gameObject.GetComponent <Rigidbody>().AddForce(movement * (energy * 3), 0, 0);
				}
			}
		}
	} 





	void createCheckpoint(){
		if(GameObject.FindGameObjectWithTag("ScoreKeeper") != null){
			GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("createCheckpoint", timer);
		}
		checkpointPlaced = true;
	}

	// Update is called once per frame
	void Update () {


		//Jumping
		if(Input.GetButtonDown ("Jump")) {
			if(energy > 2.5f) {
				if(climbing[0]){
					if(left){
						gameObject.GetComponent<Rigidbody>().AddForce(-jumpAmount * (((energy + 3) / 4)), (-jumpAmount * ((energy + 3) / 4) * .75f), 0);
					} else if(right) {
						gameObject.GetComponent<Rigidbody>().AddForce(-jumpAmount * (((energy + 3) / 4)), (jumpAmount * ((energy + 3) / 4) * .75f), 0);
					} else {
						gameObject.GetComponent<Rigidbody>().AddForce(-jumpAmount * ((energy + 2)/3), 0, 0);
					}
				} else if (climbing[1]){
					if(left){
						gameObject.GetComponent<Rigidbody>().AddForce(jumpAmount * (((energy + 3) / 4)), (jumpAmount * ((energy + 3) / 4) * .75f), 0);
					} else if(right) {
						gameObject.GetComponent<Rigidbody>().AddForce(jumpAmount * (((energy + 3) / 4)), (-jumpAmount * ((energy + 3) / 4) * .75f), 0);
					} else {
						gameObject.GetComponent<Rigidbody>().AddForce(jumpAmount * ((energy + 2)/3), 0, 0);
					}
				} else if (climbing[2]){
					if(left){
						gameObject.GetComponent<Rigidbody>().AddForce(jumpAmount * (((energy + 3) / 4)), (-jumpAmount * ((energy + 3) / 4) * .75f), 0);
					} else if(right) {
						gameObject.GetComponent<Rigidbody>().AddForce(-jumpAmount * (((energy + 3) / 4)), (-jumpAmount * ((energy + 3) / 4) * .75f), 0);
					} else {
						gameObject.GetComponent<Rigidbody>().AddForce(0, -jumpAmount * ((energy + 2)/3), 0);
					}
				}else if(grounded) {
					grounded = false;
					if(left){
						gameObject.GetComponent<Rigidbody>().AddForce(-jumpAmount * (((energy + 3) / 4) * .75f), (jumpAmount * ((energy + 3) / 4)), 0);
					} else if(right) {
						gameObject.GetComponent<Rigidbody>().AddForce(jumpAmount * (((energy + 3) / 4) * .75f), (jumpAmount * ((energy + 3) / 4)), 0);
					} else {
						gameObject.GetComponent<Rigidbody>().AddForce(0, jumpAmount * ((energy + 2)/3), 0);
					}
				}
			} else {
				if(grounded) {
					grounded = false;
					if(left){
						gameObject.GetComponent<Rigidbody>().AddForce(-jumpAmount * (((energy + 3) / 4) * .75f), (jumpAmount * ((energy + 3) / 4)), 0);
					} else if(right) {
						gameObject.GetComponent<Rigidbody>().AddForce(jumpAmount * (((energy + 3) / 4) * .75f), (jumpAmount * ((energy + 3) / 4)), 0);
					} else {
						gameObject.GetComponent<Rigidbody>().AddForce(0, jumpAmount * ((energy + 2)/3), 0);
					}
				}
			}
		}



		if(filter != null){
			if(stopTime) {
				filter.GetComponent<Renderer>().enabled = true;
			} else {
				filter.GetComponent<Renderer>().enabled = false;
			}
		}


//		/**
//		 * Checkpoint
//		 **/
//		if(!checkpointPlaced){
//			RaycastHit hit;
//			if(Physics.Raycast(transform.position, -Vector3.up, out hit, 1000.0f)){
//				if(hit.collider.tag == "Ground") {
//					if(Input.GetKeyDown("s")) {
//						Instantiate(checkpoint, new Vector3(transform.position.x, hit.transform.position.y + 10, hit.transform.position.z + 12), transform.rotation);
//						createCheckpoint();
//					}
//				}
//			}
//		}




		if(energy < 2.5f) {
			energized = false;
			gameObject.GetComponent<Renderer>().material = baseColor;
			climbing[0] = false;
			climbing[1] = false;
			climbing[2] = false;
			if(onGround) {
				grounded = true;
			}
		} else {
			energized = true;
			gameObject.GetComponent<Renderer>().material = energizedColor;
		}

		if(!climbing[0] &! climbing[1] &! climbing[2] &! grounded && onGround) {
			grounded = true;
		}

		//increase energy over time
		if(energyGain) {
			energy = Mathf.Lerp (energy, energyGainAmount, .25f);
		}


		barDisplay = (energy*2)/10;



		//Catch System to not go through walls
		RaycastHit rayHit;
		if(Physics.Raycast(transform.position, Vector3.right, out rayHit, 15.0f)) {
			if(rayHit.collider.tag == "Wall") {
				right = false;
			}
		}
		if(Physics.Raycast(transform.position, Vector3.left, out rayHit, 15.0f)) {
			if(rayHit.collider.tag == "Wall") {
				left = false;
			}
		}


		//movement states
		if(!win && !pause){
			if(Input.GetAxisRaw("Horizontal") > 0 || Input.GetButton("Right")){
				right = true;
			} else {
				right = false;
			}
			if(Input.GetAxisRaw("Horizontal") < 0 || Input.GetButton("Left")){
				left = true;
			} else {
				left = false;
			}
		}

		if(win) {
			Physics.gravity = new Vector3(0, -9.81f, 0);
			climbing[0] = false;
			climbing[1] = false;
			climbing[2] = false;
			grounded = true;
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}

		if(win || pause) {    
			left = false;
			right = false;
		}

//		if(!grounded && !climbing[0] && !climbing[1] && !climbing[2]) {
//			gameObject.GetComponent<Rigidbody>().AddForce(0, -fallingAmount, 0);
//		}


		//Energy Control
		if(!stopTime){
			if(energy > 1.0f){
				if(!energyCollect){
					energy -= Time.deltaTime/2;
				}
			}
		}

		if(energy > 5.0f) {
			energy = 5.0f;
		}
		if(energy < 1.0f) {
			energy = 1.0f;
		}
	}

	void stopPlatforms(bool stop) {
		GameObject[] platforms;
		platforms = GameObject.FindGameObjectsWithTag ("MovingPlatform");
		
		for(int i = 0; i < platforms.Length; i++){
			platforms[i].GetComponent<PlatformMoving>().SendMessage("setStop", stop);
		}
	}

	void beginGame() {
		pause = false;
		stopPlatforms (false);
	}

	void OnCollisionEnter(Collision c) {
		if(c.collider.tag == "Ground") {
			climbing[0] = false;
			climbing[1] = false;
			climbing[2] = false;
			grounded = true;
		}
	}

	void OnCollisionStay(Collision c) {
		if(c.collider.tag == "Ground") {
			onGround = true;
		}
		if(c.gameObject.tag == "ClimbingWallBottom") {
			climbing[0] = false;
			climbing[1] = false;
			climbing[2] = true;
			grounded = false;
			if(c.gameObject.transform.parent != null && energized) {
				gameObject.transform.parent = c.gameObject.transform;
			}
		}
	}

	void OnCollisionExit(Collision c) {
		if(c.collider.tag == "Ground") {
			grounded = false;
			onGround = false;
		}

		if(c.gameObject.tag == "ClimbingWallBottom") {
			climbing[2] = false;
			if(c.gameObject.transform.parent != null){
				gameObject.transform.parent = null;
			}
		}
	}

	void OnTriggerEnter(Collider c) {

		if(c.gameObject.tag == "Ground") {
			climbing[0] = false;
			climbing[1] = false;
			climbing[2] = false;
			grounded = true;
		}

		if(c.gameObject.tag == "CoffeeBean") {
			energyGainAmount = energy+1;
			energyGain = true;
			collectionWaitTimer = .75f;
			energyCollect = true;
			StartCoroutine (gainEnergy());
			Destroy(c.gameObject);
		}

		if(c.gameObject.tag == "CoffeeCup") {
			energyGainAmount = energy+2;
			energyGain = true;
			collectionWaitTimer = .75f;
			energyCollect = true;

			StartCoroutine (gainEnergy());
			Destroy(c.gameObject);
		}

		if(c.gameObject.tag == "ClimbingWallLeft") {
			climbing[0] = true;
			climbing[1] = false;
			climbing[2] = false;
			grounded = false;
		}

		if(c.gameObject.tag == "ClimbingWallRight") {
			climbing[0] = false;
			climbing[1] = true;
			climbing[2] = false;
			grounded = false;
		}

		if(c.gameObject.tag == "MovingPlatform") {
			gameObject.transform.parent = c.gameObject.transform;
		}

//		if(c.gameObject.tag == "ClimbingWallBottom") {
//			climbing[0] = false;
//			climbing[1] = false;
//			climbing[2] = true;
//			grounded = false;
//		}

		if(c.gameObject.tag == "Finish") {
			win = true;
		}

		if(c.gameObject.tag =="Death") {
			Application.LoadLevel (Application.loadedLevel);
		}


		if(c.gameObject.tag == "Stopwatch") {
			stopTime = true;
			stopPlatforms (true);
			StartCoroutine (timeStop());
			Destroy(c.gameObject);
		}

	}

	void OnTriggerExit(Collider c) {

		if(c.gameObject.tag == "MovingPlatform") {
			gameObject.transform.parent = null;
		}

		if(c.gameObject.tag == "Ground") {
			grounded = false;
		}

		if(c.gameObject.tag == "ClimbingWallLeft") {
			climbing[0] = false;
		}
		if(c.gameObject.tag == "ClimbingWallRight") {
			climbing[1] = false;
		}
	}

	void OnGUI () {



		//draw the background:
//		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
//		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
//		
//		//draw the filled-in part:
//		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
//		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
//		GUI.EndGroup();
//		GUI.EndGroup();

		GUI.BeginGroup(new Rect(Screen.width/2 - 50, Screen.height*.1f, 100, 25));
		GUI.Box(new Rect(0,0, 100, 25), emptyTex);

		GUI.BeginGroup(new Rect(0, 0, 100 * (barDisplay), 25));
		GUI.Box(new Rect(0,0, 100, 25), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();







		GUI.Box (new Rect(10, 10, 100, 35), "Energy: " + energy.ToString ("F1"));
		GUI.Box (new Rect(10, 50, 100, 35), "Time: " + timer.ToString ("F2"));

		if(win) {
			GUI.Box (new Rect(Screen.width/2 - 50, Screen.height * .25f, 100, 30), "You Win!");
			GameObject.FindGameObjectWithTag("ScoreKeeper").SendMessage("setBestTime", timer);
			if(GUI.Button (new Rect(Screen.width/2 - 75, Screen.height * .35f, 150, 30), "Level Select")) {
				Application.LoadLevel("Level Select");
			}
			if(GUI.Button (new Rect(Screen.width/2 - 75, Screen.height * .45f, 150, 30), "Restart")) {
				Application.LoadLevel(Application.loadedLevel);
			}
		} else if(!pause) {
			if(GUI.Button (new Rect(Screen.width-200, Screen.height * .15f, 100, 35), "Level Select")) {
				Application.LoadLevel("Level Select");
			}
			if(GUI.Button (new Rect(Screen.width-200, Screen.height * .25f, 100, 35), "Restart")) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator gainEnergy() {
		yield return new WaitForSeconds(.25f);
		energyGain = false;
	}

	IEnumerator timeStop() {
		yield return new WaitForSeconds(5.0f);
		stopTime = false;
		stopPlatforms(false);
	}
}
