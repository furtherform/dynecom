using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adap_WaveMover : MonoBehaviour {
	GameObject wave;

	public float WaveSpeed = 0.3f;
	public float WaveDuration = 12f;
	float killCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(new Vector3(1,0,0) * Time.deltaTime * WaveSpeed);
		Destroy(gameObject, WaveDuration);
		
	}







}
