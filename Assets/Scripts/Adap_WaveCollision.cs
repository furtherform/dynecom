using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adap_WaveCollision : MonoBehaviour {
	public int PlayerNumber = 1;
	bool fadeWave = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
	//	Debug.Log (other.gameObject.name);
		if (other.gameObject.GetComponent<Adap_WaveCollision>().PlayerNumber != PlayerNumber)
		fadeWave = true;

	}


	// Update is called once per frame
	void FixedUpdate () {
		if (fadeWave)
		{
			StartCoroutine("FadeOut");
		}
		
	}

	IEnumerator FadeOut()
	{
		//Debug.Log("enter fadeout function");
		Destroy (gameObject);
		yield return null;
		/* 
        * renderer = wave.GetComponent<Renderer>();
       material = renderer.material;
       
     	 Color color = material.color;
       Debug.Log(color.a);
       float origAlpha = color.a;
        for (float f = origAlpha; f >= 0; f -= 0.01f)
        {
            color.a = f;
            material.SetColor("_Color", color);

        }
        */


	}


}
