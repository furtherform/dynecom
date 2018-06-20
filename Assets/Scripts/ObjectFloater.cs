using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloater : MonoBehaviour {
    float maxSpeed = 1f;            // up and down speed
    Transform t;
    private Vector3 startPosition;


    // Use this for initialization
    void Start () {
        t = transform;
        
        //startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float aika = (Mathf.Sin(Time.time * maxSpeed) / 4);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //Debug.Log(transform.position.y);
    }
}
