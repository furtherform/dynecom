using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {
    GameObject wave;
    Renderer renderer;
    Material material;
    Collider collider;
    bool fadeWave = false;
   
	/*
	void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter collision");
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay in collision");
    }

    void OnCollisionExit(Collision collision)
	{
		Debug.Log ("Exit collision");
	}
	void OnTriggerStay(Collider other)
	{
		//Debug.Log("Stay in trigger zone");
	}
	void OnTriggerExit(Collider other)
	{
	}*/


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(fadeWave);
        //wave = other.gameObject;
  		//wave = gameObject;
		//wave = GameObject.Find("sceneholder2/planewaveP2/Cube");
        fadeWave = true;
        
    }

   

   

    void Update()
    {
       
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
