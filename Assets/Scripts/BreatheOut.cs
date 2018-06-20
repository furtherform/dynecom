using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheOut : MonoBehaviour {
    GameObject avatar1;
    GameObject avatar2;
	public GameObject Player1WaveSpawn;
	public GameObject Player2WaveSpawn;
	Color auraColor;
    public float instantiateSpeed = 4.0f;



	void Start () {
		avatar1 = GameObject.Find("NewWave1");
		avatar2 = GameObject.Find("NewWave2");
		Player1WaveSpawn = GameObject.Find("Player1_WaveSpawn");
		Player2WaveSpawn = GameObject.Find("Player2_WaveSpawn");



		// old waves
		// avatar1 = GameObject.Find("planewaveP1");
        //avatar2 = GameObject.Find("planewaveP2");

        InvokeRepeating("InstantiateWaves", 2.0f, 6.0f);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {InstantiateWaves();}
    }

    void InstantiateWaves()
    {
		Debug.Log("send waves!");

		Player1WaveSpawn = GameObject.Find("Player1_WaveSpawn");
		GameObject newWave = Instantiate(avatar1, Player1WaveSpawn.transform.position, avatar1.transform.rotation);
//		MoveWave mWave = newWave.GetComponent<MoveWave>();
	//	DestroyWave dWave = newWave.GetComponent<DestroyWave>();
//		mWave.enabled = true;
	//	dWave.enabled = true;

		float auraH, auraS, auraV;
		auraColor = GameObject.Find ("Player1_Manager").GetComponent<PlayerFAScript> ().PlayerColor;
		Color.RGBToHSV(auraColor, out auraH, out auraS, out auraV);
		auraS = 0.95f;
		auraColor = Color.HSVToRGB(auraH,auraS,auraV);
		auraColor.a = GameObject.Find ("Player1_Manager").GetComponent<PlayerFAScript> ().AuraColor.a*2f;

		//auraColor.a = auraColor.a * 2f + 0.01f;


        // GameObject.Find("Player1_Manager").GetComponent<PlayerFAScript>().AuraColor.a / 5;// + 0.2f;
	//	newWave.GetComponent<Renderer> ().material.color = auraColor;
	//	newWave.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", auraColor); 
//		newWave.GetComponent<ParticleSystem>().startColor = auraColor;

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
	




		Player2WaveSpawn = GameObject.Find("Player2_WaveSpawn");
		 
		newWave = Instantiate(avatar2, Player2WaveSpawn.transform.position, avatar2.transform.rotation);
//		MoveWave2 mWave2 = newWave.GetComponent<MoveWave2>();
	//	dWave = newWave.GetComponent<DestroyWave>();
//		mWave2.enabled = true;
	//	dWave.enabled = true;

		auraColor = GameObject.Find ("Player2_Manager").GetComponent<PlayerFAScript> ().PlayerColor;
		Color.RGBToHSV(auraColor, out auraH, out auraS, out auraV);
		auraS = 0.95f;
		auraColor = Color.HSVToRGB(auraH,auraS,auraV);
		auraColor.a = GameObject.Find ("Player2_Manager").GetComponent<PlayerFAScript> ().AuraColor.a*2f;
	

	

		//unity 5. has bug in particlesystem disabling looping. These are manual overrides that make it work.
		ps = newWave.GetComponent<ParticleSystem>();
		ps.Clear ();
		ps.startColor = auraColor;
		ps.startLifetime = ps.startLifetime;
		ps.emissionRate = 0;
		ps.emissionRate = 200;
		ps.Simulate (10f);
		ps.Play ();
	
		auraColor.a = auraColor.a/2f;
		l = newWave.GetComponentInChildren(typeof(Light)) as Light;
		l.color = auraColor;



		//GameObject waveGeometry = newWave.transform.Find("wave1_side1").gameObject;
		//waveGeometry.GetComponent<Renderer> ().material.color = auraColor;
		//waveGeometry.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", auraColor); 

		//waveGeometry = newWave.transform.Find("wave1_side2").gameObject;
		//waveGeometry.GetComponent<Renderer> ().material.color = auraColor;
		//waveGeometry.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", auraColor);

	/* Old Waves
   /*   Player1WaveSpawn = GameObject.Find("Player1_WaveSpawn");
		GameObject newWave = Instantiate(avatar1, Player1WaveSpawn.transform.position, avatar1.transform.rotation);
        MoveWave mWave = newWave.GetComponent<MoveWave>();
        DestroyWave dWave = newWave.GetComponent<DestroyWave>();
        mWave.enabled = true;
        dWave.enabled = true;

		auraColor = GameObject.Find ("Player1_Manager").GetComponent<PlayerFAScript> ().PlayerColor;
		auraColor.a = GameObject.Find ("Player1_Manager").GetComponent<PlayerFAScript> ().AuraColor.a*2 + 0.2f;
		GameObject waveGeometry = newWave.transform.Find("wave1_side1").gameObject;
		waveGeometry.GetComponent<Renderer> ().material.color = auraColor;
		waveGeometry.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", auraColor); 

		waveGeometry = newWave.transform.Find("wave1_side2").gameObject;
		waveGeometry.GetComponent<Renderer> ().material.color = auraColor;
		waveGeometry.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", auraColor);



        Player2WaveSpawn = GameObject.Find("Player2_WaveSpawn");
        newWave = Instantiate(avatar2, Player2WaveSpawn.transform.position, avatar2.transform.rotation);
        MoveWave2 mWave2 = newWave.GetComponent<MoveWave2>();
        dWave = newWave.GetComponent<DestroyWave>();
        mWave2.enabled = true;
        dWave.enabled = true;
	
		auraColor = GameObject.Find ("Player2_Manager").GetComponent<PlayerFAScript> ().PlayerColor;
		auraColor.a = GameObject.Find ("Player2_Manager").GetComponent<PlayerFAScript> ().AuraColor.a*2 + 0.2f;
		waveGeometry = newWave.transform.Find("wave2_side1").gameObject;
		waveGeometry.GetComponent<Renderer> ().material.color = auraColor;
		waveGeometry.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", auraColor); 

		waveGeometry = newWave.transform.Find("wave2_side2").gameObject;
		waveGeometry.GetComponent<Renderer> ().material.color = auraColor;
		waveGeometry.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", auraColor); 
		*/

    }
}
