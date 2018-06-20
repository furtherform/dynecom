using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptationLevitation : MonoBehaviour {
	GameObject GameController;
	GameObject MeditationPlatform;
	public int ActiveEegChannel = 2; 
	float eeg;

	public float MovementHeight = 30.0f;
	public float MaxSpeed = 1.0f;
	float SpeedModifier = 0.1f;		// just for tuning the speed, assuming we'll need it.
	public float UpTreshold = 3.0f;		// edit these to make the system more or less reactive
	public float DownTreshold = 3.0f;		
	public float UpSpeedIncrease = 3f;
	public float DownSpeedIncrease= 3f;		// might be more pleasant to have the down speed slower
	public float BeginBoostLength = 30.0f;
	public float BeginBoostStrength = 5.0f;  // mediation boost in the beginning.
	float goingUpNode;		
	float goingDownNode;
	float speedRaw;
	float minHeight;


	void Awake (){
		GameController = GameObject.Find ("GameController");
		MeditationPlatform = GameObject.Find("MeditationPlatform");


	}

	// Use this for initialization
	void Start () {
		minHeight = MeditationPlatform.gameObject.transform.position.y;

		if (eeg == 1) {	eeg = GameController.GetComponent <GameController> ().Eeg1;
		} else 	{ eeg = GameController.GetComponent <GameController> ().Eeg2; 
		}




	}

	// Update is called once per frame
	void FixedUpdate () {

		if (eeg == 1) {	eeg = GameController.GetComponent <GameController> ().Eeg1;
		} else 	{ eeg = GameController.GetComponent <GameController> ().Eeg2; 
		}


		// LEVITATION EFFECT



		// Calculating movement tresholds. Simplified, frome earlier, slow movement buffers removed. 
		if (GameController.GetComponent <GameController> ().GameStarted == true) {
			if (eeg > 0) {													// we add the positve results from eeg.
				goingUpNode += eeg;
			}

			if (goingUpNode > UpTreshold) {									// once they surpasses up-movement trigger value. 

				speedRaw += UpSpeedIncrease + BeginBoostStrength; 			// we increase the up speed movement
				goingUpNode = 0.0f;											// and reset
				Debug.Log ("Up");
			}


			if (eeg < 0) {													// Same for negative values
				goingDownNode -= eeg;
			}
			if (goingDownNode > DownTreshold) {								// once they surpasses down-movement trigger value. 
				speedRaw -= DownSpeedIncrease; //}							// we decrease the up speed movement
				goingDownNode = 0.0f;
				Debug.Log ("Down");
			}
		}

		// here are movement speed limiters. Previously we had slower downspeed. 
			if (speedRaw > MaxSpeed) {
				speedRaw = MaxSpeed;
			}

			if (speedRaw < -MaxSpeed) {
				speedRaw = -MaxSpeed;
			}
		

		// actual momement happens here 

		if (GameController.GetComponent <GameController> ().GameStarted == true) {

			if ((gameObject.transform.position.y < minHeight + MovementHeight) && (speedRaw >= 0)) {
				MeditationPlatform.gameObject.transform.Translate (Vector3.up * Mathf.Abs(speedRaw) * Time.deltaTime * SpeedModifier);
			}

			if ((gameObject.transform.position.y > minHeight) && (speedRaw < 0)) {
				MeditationPlatform.gameObject.transform.Translate (Vector3.down * Mathf.Abs(speedRaw) * Time.deltaTime * SpeedModifier);
			}
		}

		// tell the gamecontroller how much there has been movement
		GameController.GetComponent <GameController> ().AdaptationLevitationHeight =  MeditationPlatform.gameObject.transform.position.y - minHeight;




		// reset the beginning boost once it has ran it's course.
		if (GameController.GetComponent <GameController> ().SessionTimer > BeginBoostLength + GameController.GetComponent <GameController> ().MeditationStartTime) {
			BeginBoostStrength = 0.0f;	
		}


	}
}
