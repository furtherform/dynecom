using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptationEnergySphere : MonoBehaviour {

	GameObject GameController;
	public int ActiveEegChannel = 1;
	int adaptationOn;

	//bubble-effect
	GameObject EnergyBubble;
	public float BubbleGlowStep	= 0.01f;
	public float BubbleFadeStep = 0.01f; 
	public float BubbleMax = 0.256f;
	public float GlowTreshold = 3.0f;
	public float FadeTreshold = 3.0f;
	float bubbleStrength = 0.0f;
	float bubbleGlowNode = 0.0f;
	float bubbleFadeNode = 0.0f;
	float BubbleMin = 0.0f;
	float moveStartTime = 0.0f;
	float eeg;
	float startTimer;
	Color bubbleColor;

	
	//sparkle particles
	GameObject SparkleSystem;
	public float SparkleTreshold = 0.8f;
	GameObject IconAdaptationOn;
	GameObject IconAdaptationOff;

	void Awake (){
		IconAdaptationOn = GameObject.Find("MeditationPlatform").transform.Find("IconAdaptationOn").gameObject;
		IconAdaptationOff = GameObject.Find("MeditationPlatform").transform.Find("IconAdaptationOff").gameObject;
		EnergyBubble = GameObject.Find ("EnergySphere");
		GameController = GameObject.Find ("GameController");
		SparkleSystem = GameObject.Find("MeditationPlatform").transform.Find("EnergySphereSparkles").gameObject;

	}

	// Use this for initialization
	void Start () {
		EnergyBubble = GameObject.Find ("EnergySphere");
		GameController = GameObject.Find ("GameController");

		moveStartTime = GameController.GetComponent <GameController> ().MeditationStartTime;

		if (eeg == 1) {
		eeg = GameController.GetComponent <GameController> ().Eeg1;
		} else 
		{ eeg = GameController.GetComponent <GameController> ().Eeg2; 
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// updata variables from the gamecontroller

		if (eeg == 1) {
			eeg = GameController.GetComponent <GameController> ().Eeg1;
		} else 
		{ eeg = GameController.GetComponent <GameController> ().Eeg2; 
		}
		startTimer = GameController.GetComponent <GameController> ().SessionTimer;


		// BUBBLE GLOW EFFECT  HERE
		//Checking for going up!
		if (GameController.GetComponent <GameController> ().GameStarted == false) {
			bubbleStrength = 0.0f;
		}
		
		if (GameController.GetComponent <GameController> ().GameStarted == true) {
			
			if (eeg > 0) {									// we add the positve results of the meditation.
				bubbleGlowNode += eeg;
			}
		
			if (bubbleGlowNode > GlowTreshold) {			// once it goes over the threshold
				bubbleStrength += BubbleGlowStep;			//add to glow effect by the step.
				bubbleGlowNode = 0.0f;						// and reset
				Debug.Log ("Glow");
			}
		
		
			if (eeg < 0.0f) {								// we add the negative results of the meditation.
				bubbleFadeNode -= eeg;
			}
		
		
			if (bubbleFadeNode > FadeTreshold) {		// once it goes over the the threshold
				bubbleStrength -= BubbleFadeStep;		// reduce from glow effect
				bubbleFadeNode = 0.0f;					// and reset
				Debug.Log ("Fade");
			}
		}
		
		if (bubbleStrength > BubbleMax) {				// limit checks.
			bubbleStrength = BubbleMax;
		}
		if (bubbleStrength < BubbleMin) {
			bubbleStrength = BubbleMin;
		}

		bubbleColor = new Color (256,256,256, bubbleStrength);
		EnergyBubble.GetComponent<Renderer>().material.SetColor("_TintColor", bubbleColor);
		
		//end fade
		/*if (countTimer > TestEndTime + 3) {
			WhiteOpacityMax = 3;
			WhiteOpacity = 3;
		}*/
		
		
		
		//Sparkle my friend!
		if ((bubbleStrength / BubbleMax > SparkleTreshold) && (!SparkleSystem.activeSelf)){
			SparkleSystem.SetActive (true);
			Debug.Log("Sparkle On");}
			
		if ((bubbleStrength / BubbleMax < SparkleTreshold) && (SparkleSystem.activeSelf)) {
			SparkleSystem.SetActive (false);
			Debug.Log("Sparkle Off");}

		
		
		
		
		//Tell Gamecontroller the 
		GameController.GetComponent <GameController> ().AdaptationBubbleStrength = bubbleStrength;

		
		
	
		
	}



}
