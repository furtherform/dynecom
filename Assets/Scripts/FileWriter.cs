using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System;
using UnityEngine.Networking;

public class FileWriter : NetworkBehaviour {

	public bool FileWriting = true;
	public float FileWriteFreq = 1f;
	public string SaveFileName;
	DateTime saveTimeNow;
	string headerToWrite;
	string path1;
	string path2;
	string stateToWrite;
	float writeTimer = 0.0f;
	bool headerWritten = false;
	string sessionName;



	float PlayerFAread = 0f;
	float PlayerRespRead = 0f;
	float PlayerColorvalue = 0f;
	float PlayerColorSynchronicity = 0f;  
	float PlayerAuraSize = 0f;
	float PlayerBreathingSent = 0f;
	float BreathingSynchroncity= 0f; 



	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            return;
        }
        if (PlayerPrefs.HasKey ("SaveFileNameStored")) {
			//SaveFileName = PlayerPrefs.GetString ("SaveFileNameStored");
            SaveFileName = PlayerPrefs.GetString("SaveFileNameStored") + "_data.txt";
            Debug.Log ("FileName parameter loaded: "+ SaveFileName );
		} else { SaveFileName = "Testfile.txt";
		}

		if (PlayerPrefs.HasKey ("Param_SessionID")) {
			sessionName = PlayerPrefs.GetString ("Param_SessionID");		
			Debug.Log ("Session loaded:" + sessionName);
		} else { sessionName = "TestSession";
		}
	
	}


void FixedUpdate () {
        //File Writing happens here.
        if (!isLocalPlayer)
        {
            return;
        }
        switch (sessionName) {
		case "Session1":  //no adaptation, solo.
			PlayerFAread = GetComponent<PlayerManager>().PlayerFA;
			PlayerColorvalue = 0f;
			PlayerColorSynchronicity = 0f;  

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
			PlayerAuraSize = 0f;
			PlayerBreathingSent = 0f;
			BreathingSynchroncity = 0f; 
			break;




		case "Session2": //breathing, solo
			PlayerFAread = GetComponent<PlayerManager>().PlayerFA;
			PlayerColorvalue = 0f;
			PlayerColorSynchronicity = 0f;  

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
			PlayerAuraSize = GetComponent<PlayerManager> ().AuraBone.transform.localScale.x;

			if (GetComponent<PlayerManager> ().breatheCooldown) {
				PlayerBreathingSent = 1f;
			} else {
				PlayerBreathingSent = 0f;
			} // is it ok to check if breathe Coold down is active? maybe. It lasts for 1s. Is there are chance to miss one? 
			BreathingSynchroncity = 0f; 
			break;



		case "Session3": //eeg, solo.
			PlayerFAread = GetComponent<PlayerManager> ().PlayerFA;
			PlayerColorvalue = GetComponent<PlayerFAScript> ().PlayerFA_Display;
			PlayerColorSynchronicity = 0f; 

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
			PlayerAuraSize = 0f;
			PlayerBreathingSent = 0f;
			BreathingSynchroncity = 0f; 
			break;

		case "Session4": //nothing adapts, dyad
			PlayerFAread = GetComponent<PlayerManager>().PlayerFA;
			PlayerColorvalue = 0f;
			PlayerColorSynchronicity = 0f; 

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
			PlayerAuraSize = 0f;
			PlayerBreathingSent = 0f;
			BreathingSynchroncity = 0f; 
			break;

		case "Session5": // breathing, dyad - breathing synchronisity possible
			PlayerFAread = GetComponent<PlayerManager>().PlayerFA;
			PlayerColorvalue = 0f;
			PlayerColorSynchronicity = 0f;  

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
			PlayerAuraSize = GetComponent<PlayerManager> ().AuraBone.transform.localScale.x;

			if (GetComponent<PlayerManager> ().breatheCooldown) {
				PlayerBreathingSent = 1f;
			} else {
				PlayerBreathingSent = 0f;
			}
		
	
			if (GetComponent<BreathLayerer> ().SyncHappened) {
				BreathingSynchroncity = 1f;
			} else {
				BreathingSynchroncity = 0f;
			}
		break;

		case "Session6": //eeg dyad - bridge sides synchronisity possible
		PlayerFAread = GetComponent<PlayerManager>().PlayerFA;
		 PlayerColorvalue = GetComponent<PlayerFAScript>().PlayerFA_Display;
		 PlayerColorSynchronicity =GetComponent<PlayerFAScript>().fasync;  // effect happens when this is <0.1;

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
		 PlayerAuraSize = 0f;
		 PlayerBreathingSent = 0f;
		 BreathingSynchroncity= 0f; 
		break;

		case "Session7": // breathing & eeg solo, no synchronisity possible 
			PlayerFAread = GetComponent<PlayerManager>().PlayerFA;
			PlayerColorvalue = GetComponent<PlayerFAScript>().PlayerFA_Display;
			PlayerColorSynchronicity =GetComponent<PlayerFAScript>().fasync;  // effect happens when this is <0.1;

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
			PlayerAuraSize = GetComponent<PlayerManager> ().AuraBone.transform.localScale.x;

			if (GetComponent<PlayerManager> ().breatheCooldown) {
				PlayerBreathingSent = 1f;
			} else {
				PlayerBreathingSent = 0f;
			}


			if (GetComponent<BreathLayerer> ().SyncHappened) {
				BreathingSynchroncity = 1f;
			} else {
				BreathingSynchroncity = 0f;
			}
			break;

		
		case "Session8": // breathing & eeg dyad - breathing and eeg synchronisity possible
			PlayerFAread = GetComponent<PlayerManager>().PlayerFA;
			PlayerColorvalue = GetComponent<PlayerFAScript>().PlayerFA_Display;
			PlayerColorSynchronicity =GetComponent<PlayerFAScript>().fasync;  // effect happens when this is <0.1;

			PlayerRespRead = GetComponent<PlayerManager> ().breatheNow;
			PlayerAuraSize = GetComponent<PlayerManager> ().AuraBone.transform.localScale.x;

			if (GetComponent<PlayerManager> ().breatheCooldown) {
				PlayerBreathingSent = 1f;
			} else {
				PlayerBreathingSent = 0f;
			}


			if (GetComponent<BreathLayerer> ().SyncHappened) {
				BreathingSynchroncity = 1f;
			} else {
				BreathingSynchroncity = 0f;
			}
			break;


		}








		path1 = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "/DYNECOM_Data";
		path2 = path1 + "/" + SaveFileName;


		//only write the file once the start timer has ended.
	//	if (GameObject.Find("Session Manager").GetComponent<SessionManager>().StartTimerDone) {

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

					headerToWrite = "Starting recording a new test: " + sessionName  +" "+ saveTimeNow + Environment.NewLine + 
						"Format: DateTime, EegRead, User FA Color, Color Sync, Resp MovingAverage, User AuraSize, Resp. Bar Sent, Resp. Bar Sync" + Environment.NewLine; //+ " " + simulationToWrite ;
					//			Debug.Log (headerToWrite);
					System.IO.File.AppendAllText (path2, headerToWrite);
					headerWritten = true;

				} else {  //HERE we write actual data

					var tmpPlayerFAread = PlayerFAread.ToString ();
					var tmpPlayerColorvalue = PlayerColorvalue.ToString ();;
					var tmpPlayerColorSynchronicity = PlayerColorSynchronicity.ToString (); 

					var tmpPlayerRespRead = PlayerRespRead.ToString ();
					var tmpPlayerAuraSize = PlayerAuraSize.ToString ();
					var tmpPlayerBreathingSent = PlayerBreathingSent.ToString ();
					var tmpBreathingSynchroncity= BreathingSynchroncity.ToString (); 


					saveTimeNow = System.DateTime.Now;
					saveTimeNow.ToString ("HHmmss");

					//var heightTemp = AdaptationLevitationHeight.ToString ();
					//var whiteTemp = AdaptationBubbleStrength.ToString ();

					stateToWrite = 
						saveTimeNow + ","+ 
						tmpPlayerFAread + ","+
						tmpPlayerColorvalue + ","+
						tmpPlayerColorSynchronicity + ","+
						tmpPlayerRespRead + ","+
						tmpPlayerAuraSize + ","+
						tmpPlayerBreathingSent + ","+
						tmpBreathingSynchroncity + 
						Environment.NewLine;
					
					System.IO.File.AppendAllText (path2, stateToWrite);
				}

				writeTimer -= writeTimer;	
			}
		} 


	//}
}
