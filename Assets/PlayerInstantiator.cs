using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerInstantiator : MonoBehaviour
{

    NetworkManager manager;
    string[] singlePlayerSessions;
    string[] multiPlayerSessions;
    // Use this for initialization
    void Start()
    {
        singlePlayerSessions = new string[] { "Session1", "Session2", "Session3", "Session7" };
        multiPlayerSessions = new string[] { "Session4", "Session5", "Session6", "Session8" };
        manager = transform.GetComponent<NetworkManager>();

        Debug.Log(PlayerPrefs.HasKey("Param_SessionID"));
        Debug.Log(PlayerPrefs.GetString("Param_SessionID"));

        if (PlayerPrefs.HasKey("Param_SessionID"))
        {
            string session = PlayerPrefs.GetString("Param_SessionID");
            if (System.Array.IndexOf(singlePlayerSessions, session) > -1)
            {
                manager.StartHost();
                Debug.Log("Started host");
            }
            else if (System.Array.IndexOf(multiPlayerSessions, session) > -1)
            {
                if (PlayerPrefs.HasKey("Param_HostOrNot"))
                {
                    if (PlayerPrefsX.GetBool("Param_HostOrNot"))
                    {
                        manager.StartHost();
                        Debug.Log("Started host");
                    }
                    else
                    {
                        manager.StartClient();
                        Debug.Log("Started client");
                    }
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {


    }
}
