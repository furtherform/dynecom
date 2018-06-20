using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System;

public class FileWriterQuestionnaire : MonoBehaviour {

	bool headerWritten = false;
	string path1;
	string path2;
	DateTime saveTimeNow;
	string headerToWrite;
	string SaveFileName;
	string sessionName;
	string stateToWrite;



	// Use this for initialization
void Start () {

	
			if (PlayerPrefs.HasKey ("SaveFileNameStored")) {
				SaveFileName = PlayerPrefs.GetString ("SaveFileNameStored") + "_questions.txt";		
				Debug.Log ("FileName parameter loaded: "+ SaveFileName );
			} else { SaveFileName = "Testfile.txt";
			}

			if (PlayerPrefs.HasKey ("Param_SessionID")) {
				sessionName = PlayerPrefs.GetString ("Param_SessionID");		
				Debug.Log ("Session loaded:" + sessionName);
			} else { sessionName = "TestSession";
			}

		path1 = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "//DYNECOM_Data";
		path2 = path1 + "/" + SaveFileName;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void WriteAnswer (int QuestionNumber, int Answer){
		if (!headerWritten) {

			//create folder if it doesn't exist
			if (Directory.Exists (path1)) {
			} else {
				DirectoryInfo di = Directory.CreateDirectory (path1);
			}


			// write the header
			saveTimeNow = System.DateTime.Now;				
			saveTimeNow.ToString ("yyyyMMddHHmmss");

			headerToWrite = "Recording Questionnaire Answers: " + sessionName + " " + saveTimeNow + Environment.NewLine; 
		
			//			Debug.Log (headerToWrite);
			System.IO.File.AppendAllText (path2, headerToWrite);
			headerWritten = true;
		}

        saveTimeNow = System.DateTime.Now;
        saveTimeNow.ToString("yyyyMMddHHmmss");

        string tmpQuestionNumber = QuestionNumber.ToString();
		string tmpAnswer = Answer.ToString();

        if (QuestionNumber < 31) {
            stateToWrite = saveTimeNow + "," + sessionName + "," + QuestionNumber + "," + tmpAnswer + Environment.NewLine;
            System.IO.File.AppendAllText(path2, stateToWrite);
        }
		
	}
}
