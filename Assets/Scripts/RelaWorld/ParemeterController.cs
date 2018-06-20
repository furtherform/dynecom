using UnityEngine;
using System.Collections;

public class ParemeterController : MonoBehaviour {


	string SceneHeightString;
	float SceneHeight;
	
	string RiseStrengthString;
	float RiseStrength;
	
	string FallStrengthString;
	float FallStrength;

	string WhiteStrengthString;
	float WhiteStrength;

	string BlackStrengthString;
	float BlackStrength;

	string WhiteAdjustmentString;
	float WhiteAdjustment;

	string StaticIPString;
	string SaveFileName;

	bool StartDelayToggleBool = true;

	int AdaptationOnInt;


	public void SetSceneHeight(string value) {
		SceneHeightString = value;
		Debug.Log ("stringeli: " + SceneHeightString + value);
		SceneHeight = float.Parse(SceneHeightString);

		if (PlayerPrefs.HasKey ("SceneHeightStored")) {
						PlayerPrefs.SetFloat ("SceneHeightStored", SceneHeight);
				} else {
						float arvo = 90.0f;
						PlayerPrefs.SetFloat ("SceneHeightStored", arvo);

						PlayerPrefs.SetFloat ("SceneHeightStored", SceneHeight);
						Debug.Log ("Scene Height from save " + SceneHeight);
				}
	}
	
	public void SetRiseStrength(string value2) {
		RiseStrengthString = value2;
		RiseStrength = float.Parse(RiseStrengthString);
			if (PlayerPrefs.HasKey ("RiseStrengthtStored")) {
						PlayerPrefs.SetFloat ("RiseStrengthtStored", RiseStrength);
				} else {
						float arvo = 3.5f;
						PlayerPrefs.SetFloat ("RiseStrengthtStored", arvo);
				
						PlayerPrefs.SetFloat ("RiseStrengthtStored", RiseStrength);
						Debug.Log ("Rise strength from save " + RiseStrength);
				}
		
	}

	public void SetFallStrength(string value3) {
		FallStrengthString = value3;
		FallStrength = float.Parse(FallStrengthString);
		if (PlayerPrefs.HasKey ("FallStrengthtStored")) {
			PlayerPrefs.SetFloat ("FallStrengthtStored", FallStrength);
		} else {
			float arvo = 0.2f;
			PlayerPrefs.SetFloat ("FallStrengthtStored", arvo);
			
			PlayerPrefs.SetFloat ("FallStrengthtStored", FallStrength);
			Debug.Log ("Fall strength from save " + FallStrength);
		}
	}

	public void SetWhiteStrength(string value4) {
		WhiteStrengthString = value4;
		WhiteStrength = float.Parse(WhiteStrengthString);

		if (PlayerPrefs.HasKey ("WhiteStrengthtStored")) {
			PlayerPrefs.SetFloat ("WhiteStrengthtStored", WhiteStrength);
		} else {
			float arvo = 9.0f;
			PlayerPrefs.SetFloat ("WhiteStrengthtStored", arvo);
			
			PlayerPrefs.SetFloat ("WhiteStrengthtStored", WhiteStrength);
			Debug.Log ("White strength from save " + WhiteStrength);
		}

	
	}

	public void SetBlackStrength(string value5) {
		BlackStrengthString = value5;
		BlackStrength = float.Parse(BlackStrengthString);
		if (PlayerPrefs.HasKey ("BlackStrengthtStored")) {
			PlayerPrefs.SetFloat ("BlackStrengthtStored", BlackStrength);
		} else {
			float arvo = 1.0f;
			PlayerPrefs.SetFloat ("BlackStrengthtStored", arvo);
			
			PlayerPrefs.SetFloat ("BlackStrengthtStored", BlackStrength);
			Debug.Log ("Rise strength from save " + BlackStrength);
		}
	
	}

	public void SetWhiteAdjustment(string value6) {
		WhiteAdjustmentString = value6;
		WhiteAdjustment = float.Parse(WhiteAdjustmentString);
		if (PlayerPrefs.HasKey ("WhiteAdjustmentStored")) {
			PlayerPrefs.SetFloat ("WhiteAdjustmentStored", WhiteAdjustment);
		} else {
			float arvo = 0.0f;
			PlayerPrefs.SetFloat ("WhiteAdjustmentStored", arvo);
			
			PlayerPrefs.SetFloat ("WhiteAdjustmentStored", WhiteAdjustment);
			Debug.Log ("White Adjustment value from  " + WhiteAdjustment);
		}

	}

	public void SetStaticIP(string value7) {
		StaticIPString = value7;
		
		if (PlayerPrefs.HasKey ("StaticIPStored")) {
			PlayerPrefs.SetString ("StaticIPStored", StaticIPString);
		} else {
			string arvo1 = "130.233.58.206";
			PlayerPrefs.SetString ("StaticIPStored", arvo1);			
			PlayerPrefs.SetString ("StaticIPStored", StaticIPString);
			Debug.Log ("Static IP " + StaticIPString);
		}
	}
	
	public void SetSaveFileName(string value8) {
			SaveFileName = value8;
			
			if (PlayerPrefs.HasKey ("SaveFileNameStored")) {
				PlayerPrefs.SetString ("SaveFileNameStored", SaveFileName);
			Debug.Log ("Data file saved as: " + SaveFileName);
			} else {
				string arvo1 = "RelaTestData001.txt";
				PlayerPrefs.SetString ("SaveFileNameStored", arvo1);			
				PlayerPrefs.SetString ("SaveFileNameStored", SaveFileName);
				Debug.Log ("Data file saved as: " + SaveFileName);
			}
		}


	public void SetAdaptationToggle(bool value9) {

		if (value9 == true) {
						AdaptationOnInt = 1;
				}
			
		if (value9 == false) {
						AdaptationOnInt = 0;
				}

		//RiseStrength = float.Parse(RiseStrengthString);
		if (PlayerPrefs.HasKey ("AdaptationOnStored")) {
			PlayerPrefs.SetInt ("AdaptationOnStored", AdaptationOnInt);
			Debug.Log ("Adaptation On saved as: " + AdaptationOnInt);
		} else {
			int arvo = 1;
			PlayerPrefs.SetFloat ("AdaptationOnStored", 1);
			
			PlayerPrefs.SetFloat ("AdaptationOnStored", AdaptationOnInt);
			Debug.Log ("Adaptation On saved as: " + AdaptationOnInt);
		}
		
	}




	/*
	 * public void StartDelayToggle() {
		if (StartDelayToggleBool = true) {StartDelayToggleBool = false; 
			PlayerPrefs.SetBool ("StartDelayToggleBool", StartDelayToggleBool );
		WhiteAdjustment = float.Parse(WhiteAdjustmentString);
		PlayerPrefs.SetFloat ("WhiteAdjustmentStored", WhiteAdjustment);
	}
	 */
	void Start () {
		
		Cursor.visible = true;
		
		
		
	}


}


