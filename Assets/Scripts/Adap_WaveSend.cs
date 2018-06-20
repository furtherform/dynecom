using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adap_WaveSend : MonoBehaviour {

	public GameObject wave;
	public GameObject PlayerWaveSpawn;
	public GameObject PlayerAssetHolder;
	Color auraColor;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SendWave(int playerNumber){
		//Debug.Log ("Wave Away "+ playerNumber);

		if (playerNumber == 1) {
			
			wave = GameObject.Find ("NewWave1");
			PlayerWaveSpawn = GameObject.Find ("Player1_WaveSpawn");
			PlayerAssetHolder = GameObject.Find ("Player1_Manager");
		} else {
			
			wave = GameObject.Find ("NewWave2");
			PlayerWaveSpawn = GameObject.Find ("Player2_WaveSpawn");
			PlayerAssetHolder = GameObject.Find ("Player2_Manager");
		
		}
			
		var newWave= (GameObject)Instantiate (wave, PlayerWaveSpawn.transform.position, wave.transform.rotation);
		newWave.GetComponent<Adap_WaveCollision> ().PlayerNumber = playerNumber;
		Adap_WaveMover mWave = newWave.GetComponent<Adap_WaveMover>();
		mWave.enabled = true;

		float auraH, auraS, auraV;
		auraColor = PlayerAssetHolder.GetComponent<PlayerFAScript> ().PlayerColor;
		Color.RGBToHSV(auraColor, out auraH, out auraS, out auraV);
		auraS = 0.95f;
		auraColor = Color.HSVToRGB(auraH,auraS,auraV);
		auraColor.a = PlayerAssetHolder.GetComponent<PlayerFAScript> ().AuraColor.a*2f;

	
		ParticleSystem ps = newWave.GetComponent<ParticleSystem>();
		ps.Clear ();
		ps.startColor = auraColor;
		//		ps.Simulate (5f,false, true);
		ps.startLifetime = ps.startLifetime;
		ps.emissionRate = 0;
		ps.emissionRate = 200;
		ps.Simulate (10f);
		ps.Play ();

		auraColor.a = auraColor.a/2f;
		Light l = newWave.GetComponentInChildren(typeof(Light)) as Light;

		l.color = auraColor;


	}
}
