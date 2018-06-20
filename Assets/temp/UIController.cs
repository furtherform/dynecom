using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	string playerName;
	
	public void SetPlayerName(string value) {
		playerName = value;
		Debug.Log ("playerName variable now holds: "+playerName);
	}


}
