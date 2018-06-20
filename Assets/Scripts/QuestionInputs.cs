using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionInputs : MonoBehaviour {
    QuestionHandler QuestionHandler;

	// Use this for initialization
	void Start () {
        QuestionHandler = GameObject.Find("Question Handler").GetComponent<QuestionHandler>();
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            QuestionHandler.NextQuestion();
        }



        Debug.Log(OVRInput.Get(OVRInput.Button.One));



        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            Debug.Log("Primary Joystick Up");
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            Debug.Log("Primary Joystick Down");
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft))
        {
            Debug.Log("Primary Joystick Left");
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))
        {
            Debug.Log("Primary Joystick Right");
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            Debug.Log("Secondary Joystick Up");
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            Debug.Log("Secondary Joystick Down");
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            Debug.Log("Secondary Joystick Left");
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            Debug.Log("Secondary Joystick Right");
        }




    }
}
