using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;




public class GameController : MonoBehaviour {
	public float MeditationStartTime = 0.0f; //usually put 30 for allowing some time before the session begins
	public float MeditationEndTime = 630.0f; // 630 = 10 minutes

	bool simulationReset = false;
	public bool ShowAdaptationMarker = true; // and show the marker in the scene
	GameObject IconAdaptationOn;
	GameObject IconAdaptationOff;

	public bool FileWriting = true;
	public float FileWriteFreq = 1f;

	public float Eeg1Adjustment = 0.0f;  // added to Eeg, use values  between -1 and 1, usually value of 0.2 is enough
	public float Eeg2Adjustment = 0.0f;  // to shift the incoming feed to be more responsive

	[Header("Internal variables. Do not adjust.")]
	public bool SimulationOrAdaptation = false; // as default we run as simulation
	public float Eeg1;					// the eeg values coming in either from sensors or from simulation formula
	public float Eeg2;
	public bool GameStarted = false; //also used by other scripts to check if they are ok to run.
	public float SessionTimer;	// public as other scripts access this
	float sessionTimer = 0.0f;
	float simTimeMultiplier = 0.015f; // used for the simulation sin curve speed.
	float writeTimer = 0.0f;
	bool headerWritten = false;

	DateTime saveTimeNow;
	string path1;				// used for path, should come from saved settings.
	string path2;				// used for adding the filename, should come saved settings.
	string SaveFileName;		// filename, should come from saved settings.
	string headerToWrite;
	string stateToWrite;
	string simulationToWrite;	// text to indicate simulation, defined in the end.

	public string MeditationTestType = " ";	//active scripts define this.
	public float AdaptationLevitationHeight = 0f; //also come from adapation scripts
	public float AdaptationBubbleStrength = 0f; 

	void Awake (){
		IconAdaptationOn = GameObject.Find ("IconAdaptationOn");
		IconAdaptationOff = GameObject.Find ("IconAdaptationOff");
	
	}

	// Use this for initialization
	void Start () {
		/*
		if (PlayerPrefs.HasKey ("AdaptationOnStored")) {
			AdaptationOn = PlayerPrefs.GetInt ("AdaptationOnStored");		
			Debug.Log (AdaptationOn + "Adaptation from save");
		}


		if (PlayerPrefs.HasKey ("SceneHeightStored")) {
			maxHeight = PlayerPrefs.GetFloat ("SceneHeightStored");		
			Debug.Log (maxHeight + "max Height from save");
		}

		if (PlayerPrefs.HasKey ("RiseStrengthtStored")) {
			UpCheckTreshold = PlayerPrefs.GetFloat ("RiseStrengthtStored");		
			Debug.Log (UpCheckTreshold + "UpCheckTreshold from save");
		}

		if (PlayerPrefs.HasKey ("FallStrengthtStored")) {
			DownCheckTreshold = PlayerPrefs.GetFloat ("FallStrengthtStored");	
			Debug.Log (DownCheckTreshold + "DownCheckTreshold from save");
		}

		if (PlayerPrefs.HasKey ("WhiteStrengthtStored")) {
			WhiteCheckTreshold = PlayerPrefs.GetFloat ("WhiteStrengthtStored");	
			Debug.Log (WhiteCheckTreshold + "WhiteCheckTreshold from save");
		}

		if (PlayerPrefs.HasKey ("BlackStrengthtStored")) {
			BlackCheckTreshold = PlayerPrefs.GetFloat ("BlackStrengthtStored");	
			Debug.Log (BlackCheckTreshold + "BlackCheckTreshold from save");
		}

		if (PlayerPrefs.HasKey ("WhiteAdjustmentStored")) {
			WhiteAdjustment = PlayerPrefs.GetFloat ("WhiteAdjustmentStored");	
			Debug.Log (WhiteAdjustment + "WhiteAdjustement from save");
		}

		if (PlayerPrefs.HasKey ("SaveFileNameStored")) {
			SaveFileName = PlayerPrefs.GetString ("SaveFileNameStored");		
			Debug.Log (SaveFileName + "SaveFileName from save");
		}
		*/


	}


	void FixedUpdate () {
		SessionTimer += Time.deltaTime;


		//Simulation logic goes here

		if (SimulationOrAdaptation == false) {
			// Relaworld Eeg feed is between values -1 and 1. Formula keeps the value within the range with added randomness.
			Eeg1 = ((Mathf.Sin (SessionTimer * Mathf.PI * simTimeMultiplier)) * 0.8f + UnityEngine.Random.Range (-0.2f, 0.2f)) + Eeg1Adjustment;
			Eeg2 = ((Mathf.Sin (SessionTimer * Mathf.PI * simTimeMultiplier)) * 0.8f + UnityEngine.Random.Range (-0.2f, 0.2f)) + Eeg2Adjustment;

		}


		//zeroing the values once if switching between simulation/real data during the test.
		//should the speed of movement in meditation be reseted as well?
		if ((SimulationOrAdaptation == true) & (simulationReset == false)){
			Eeg1 = 0f;
			Eeg2 = 0f;
			simulationReset = true;
		}
		if ((SimulationOrAdaptation == false) & (simulationReset == true)){
			Eeg1 = 0f;
			Eeg2 = 0f;				
			simulationReset = false;
			}
				



		// tell everyone that the meditation has started
		if (SessionTimer > MeditationStartTime){		
			GameStarted = true;	
		}

		// and when it ends.
		if (sessionTimer > MeditationEndTime)
		{
			GameStarted = false;	
		}



		// adaptation icon control
		if ((SimulationOrAdaptation == true) && (ShowAdaptationMarker == true)) {
			IconAdaptationOn.gameObject.SetActive(true);

		} else 	IconAdaptationOn.gameObject.SetActive(false);

		if ((SimulationOrAdaptation == false) && (ShowAdaptationMarker == true)) {
			IconAdaptationOff.gameObject.SetActive(true);

		} else 	IconAdaptationOff.gameObject.SetActive(false);


	


		//File Writing happens here.

		// first the variables
		if (SimulationOrAdaptation == false) {
			simulationToWrite = " Simulated data";
		} else {
			simulationToWrite = " ";
		}

		SaveFileName = "testname.txt";  // for now, we should get these from save file.
		path1 = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "/RelaWorldData";
		path2 = path1 + "/" + SaveFileName;



		if (FileWriting == true) {

			writeTimer += Time.deltaTime;  		//data is written on a frequencey, default, once per second.
			if (writeTimer > FileWriteFreq) {  
				
				if (headerWritten == false) {

					//create folder if it doesn't exist
					if (Directory.Exists (path1)) {
					} else {
						DirectoryInfo di = Directory.CreateDirectory (path1);
					}


					// write the header
					saveTimeNow = System.DateTime.Now;				
					saveTimeNow.ToString ("yyyyMMddHHmmss");

					headerToWrite = "Starting recording a new test: " + MeditationTestType + " " + saveTimeNow + simulationToWrite + Environment.NewLine;
		//			Debug.Log (headerToWrite);
					System.IO.File.AppendAllText (path2, headerToWrite);
					headerWritten = true;

				} else {  //HERE we write actual data

					saveTimeNow = System.DateTime.Now;
					saveTimeNow.ToString ("HHmmss");

					var heightTemp = AdaptationLevitationHeight.ToString ();
					var whiteTemp = AdaptationBubbleStrength.ToString ();

					stateToWrite = MeditationTestType + " " + saveTimeNow + " " + heightTemp + " " + whiteTemp + simulationToWrite + Environment.NewLine;
			//		Debug.Log (MeditationTestType + path2 + stateToWrite);
					System.IO.File.AppendAllText (path2, stateToWrite);
				}
			
				writeTimer -= writeTimer;	
			}
		} 



		/*
		 * 
		if (Input.GetKeyDown ("f1")) {
				Application.LoadLevel (0);
					
		}

		if (Input.GetKeyDown ("f2")) {
			Application.LoadLevel (1);
			
		}

		if (Input.GetKeyDown ("f3")) {
			Application.LoadLevel (2);
			
		}

		if (Input.GetKeyDown ("f4")) {
			Application.LoadLevel (3);
			
		}

		if (Input.GetKeyDown ("f5")) {
			Application.LoadLevel (4);
			
		}

		if (Input.GetKeyDown ("f6")) {
			Application.LoadLevel (6);
	
		}
		*/

	}
}
