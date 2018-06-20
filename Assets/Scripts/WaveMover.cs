using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMover : MonoBehaviour {

	//move object vertiacally on a sin curve.

	public float waveLength = 10000.0f;
	public float TimeMultiplier = 0.5f;
	public float PiMultiplier = 1.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		

		transform.position += new Vector3(
			0.0f, 
			Mathf.Sin (PiMultiplier* Mathf.PI * Time.time * TimeMultiplier) * waveLength, 
			0.0f
		);
		//transform.position += new Vector3 (0.0f, 0.0f, Mathf.Cos (2 * Mathf.PI * Time.time / 12) * waveLength ); 
	}


}
