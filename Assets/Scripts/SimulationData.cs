using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationData : MonoBehaviour {

	public float breathingSpeed1 = 0.2f;
	public float breathingSpeed2 = 1.1f;
	public float breathingOffset = 1f;
	public float P1Breathing;
	public float P2Breathing;

	public float frontAsSpeed = 0.2f;
	public float frontAsOffset = 3f;
	public float P1FrontAs;
	public float P2FrontAs;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		P1Breathing = Mathf.Sin(Time.time * breathingSpeed1);
		P2Breathing = breathingOffset + Mathf.Sin (Time.time * breathingSpeed2);
		P1FrontAs = 0.5f+0.5f*Mathf.Sin((Time.time) * frontAsSpeed);
		P2FrontAs = 0.5f+0.5f*Mathf.Sin((Time.time + frontAsOffset) * frontAsSpeed);	

	}
}
