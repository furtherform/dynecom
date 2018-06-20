using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerFunctions : NetworkBehaviour {
    public Camera Cam;
    public AudioListener AudioListener;
    GameObject bridge;

    // Use this for initialization
    void Start () {
        if (!isLocalPlayer)
        {
            return;
        }
        Cam.enabled = true;
        AudioListener.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
