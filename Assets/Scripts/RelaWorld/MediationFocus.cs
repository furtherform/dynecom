using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediationFocus : MonoBehaviour {
	GameObject GameController;
	public float SuffleFrequency = 30.0f;
	public float BallDistance = 0.4f;
	public GameObject BallGlowing;
	public GameObject BallNormal;
	GameObject LocationObject;
	float mediatationStartTime;
	float sessionTimer;
	float suffleTimer = 0.0f;
	float randomRotation;

	int chosenLocation;
	GameObject glowBall;
	GameObject ballToMove;
	public List <GameObject> focusBallsList; 

	void Awake (){
		GameController = GameObject.Find ("GameController");
		LocationObject = GameObject.Find ("SphereSpawnPoint");



	}

	// Use this for initialization
	void Start () {
		GameController.GetComponent <GameController> ().MeditationTestType = "Focused Attention";
		float x = LocationObject.transform.position.x;
		float y = LocationObject.transform.position.y;
		float z = LocationObject.transform.position.z;


		//create normal balls
		for (int i=0; i<5; i++) {	
				x += BallDistance;
				GameObject ballToInstantiate = (GameObject)Instantiate (BallNormal); 			 
				ballToInstantiate.name = "SphereNormal " + i;
				ballToInstantiate.transform.parent = LocationObject.transform;
				ballToInstantiate.transform.position = new Vector3 (x, y, z);
				randomRotation = UnityEngine.Random.Range (0, 180);
				ballToInstantiate.transform.Rotate(0,randomRotation,0,Space.World);
				focusBallsList.Insert(0, ballToInstantiate);


			}

		// and glowing ball at the top of one of these.
		chosenLocation = UnityEngine.Random.Range (0, 4);
		ballToMove = focusBallsList [chosenLocation];
		glowBall= (GameObject)Instantiate (BallGlowing);
		glowBall.transform.parent = LocationObject.transform;
		glowBall.transform.position =  new Vector3 (ballToMove.transform.position.x, ballToMove.transform.position.y, ballToMove.transform.position.z);
		ballToMove.transform.position += new Vector3(0,-5000,0);

	}


void FixedUpdate () {
	// Ball suffling

		suffleTimer += Time.deltaTime;
		if ((suffleTimer > SuffleFrequency) && (GameController.GetComponent <GameController> ().GameStarted == true)) { 
			ballToMove.transform.position += new Vector3(0,5000,0);
			suffleTimer = 0.0f;	
			int chosenLocation = UnityEngine.Random.Range (0, 4);
			ballToMove = focusBallsList [chosenLocation];
			glowBall.transform.position =  new Vector3 (ballToMove.transform.position.x, ballToMove.transform.position.y, ballToMove.transform.position.z);
			ballToMove.transform.position += new Vector3(0,-5000,0);
		}

		
	}



}
