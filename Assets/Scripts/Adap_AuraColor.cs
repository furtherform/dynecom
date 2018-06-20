using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adap_AuraColor : MonoBehaviour {

	public GameObject DataHolder;
	int playerNumber =0;
	public Gradient FAColorSlide = new Gradient();
	public Color PlayerColor;


	public GameObject PlayerBridgeSides;
	public GameObject PlayerAura;
	public GameObject PlayerAura2;
	public GameObject[] PlayerLights;
	public GameObject PlayerStatue;
	public float PlayerFA_Display = 0.0f;
	public float PlayerFA_adjusted;
	public Color AuraColor;
	float auraH;
	float auraS;
	float auraV;


	// Use this for initialization
	void Start () {
		DataHolder = GameObject.Find ("Data Holder");
		GradientColorKey[] gck = new GradientColorKey[2];
		GradientAlphaKey[] gak = new GradientAlphaKey[2];
		playerNumber = GetComponent<PlayerManager> ().PlayerNumber;
	}
	
	void FixedUpdate () {
		if (playerNumber == 0) playerNumber = GetComponent<PlayerManager> ().PlayerNumber;
		if (playerNumber == 1) {
			PlayerFA_Display = DataHolder.GetComponent<SimulationData> ().P1FrontAs;
		}

		if (playerNumber == 2) {
			PlayerFA_Display = DataHolder.GetComponent<SimulationData> ().P2FrontAs;

		}



		PlayerColor = FAColorSlide.Evaluate(PlayerFA_Display);

		Color.RGBToHSV(PlayerColor, out auraH, out auraS, out auraV);
		auraS = 0.72f;
		auraV = 0.35f;
		AuraColor = Color.HSVToRGB(auraH,auraS,auraV);
		AuraColor.a = 0.05f + PlayerFA_Display*0.7f;
		PlayerAura.GetComponent<Renderer> ().material.SetColor ("_TintColor", AuraColor); 
		AuraColor.a = AuraColor.a*0.4f;
		PlayerAura2.GetComponent<Renderer> ().material.SetColor ("_TintColor", AuraColor);



		for (int i = 0; i < PlayerLights.Length; i++) {

			Light l = PlayerLights[i].GetComponent<Light> ();
			l.color = PlayerColor;
			l.intensity = 0.2f + PlayerFA_Display*1.5f;
		}

		PlayerBridgeSides.GetComponent<Renderer> ().material.color = PlayerColor;
		PlayerBridgeSides.GetComponent<Renderer>().material.SetFloat("_Threshold", 1.0f - PlayerFA_Display);


	}
}
