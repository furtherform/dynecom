using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeditationBodyScan : MonoBehaviour {

	GameObject BodyScanHUD;
	GameObject GameController;
	public float Image_duration = 30.0f;
	public float Fade_time = 2.0f;
	public List <Image> imagesToReveal;
	public List <float> imageRevealTimes; 



	void ShowImage (Image imageShown, float revealTime) {
		if ((GameController.GetComponent <GameController> ().SessionTimer > revealTime) && 
			(GameController.GetComponent <GameController> ().SessionTimer < revealTime + Fade_time)) {
			imageShown.gameObject.SetActive(true);
			imageShown.CrossFadeAlpha(0.0f, 0.0f, false); 
			imageShown.CrossFadeAlpha(1.0f, Fade_time, false); 
		}
		if (GameController.GetComponent <GameController> ().SessionTimer > (revealTime + Fade_time + Image_duration)) {
			imageShown.CrossFadeAlpha(0.0f, Fade_time, false); 
		}		
	}

	void Awake() {
		GameController = GameObject.Find ("GameController");
		BodyScanHUD = GameObject.Find ("MeditationPlatform").transform.Find ("BodyScanHUD").gameObject;


	}


	void Start () {
		GameController.GetComponent <GameController> ().MeditationTestType = "Body Scan";
		BodyScanHUD.SetActive (true);
		for (int i = 0; i < imagesToReveal.Count; i++ ){
			imageRevealTimes.Insert (0, imagesToReveal.Count * Image_duration - Image_duration * (i+1) + GameController.GetComponent <GameController> ().MeditationStartTime);
		}
	}


	void FixedUpdate () { 
		if (GameController.GetComponent <GameController> ().GameStarted == true) {
			for (int i = 0; i < imagesToReveal.Count; i++) {
				ShowImage (imagesToReveal [i], imageRevealTimes [i] );

			}

		}

	}
}
