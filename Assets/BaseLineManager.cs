using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class BaseLineManager : MonoBehaviour {

	public float BaseLineDuration = 120f;
	public bool StartTimerDone = false;
	bool BeginEndFade = false;
	float StartTimerLength = 10f;
	CanvasGroup CameraFadeCanvas;
	string sessionID;
    bool started;

	void Awake() { 
		//*//  
		//Loading parameters from the playerrefs.
		if (PlayerPrefs.HasKey ("Param_SessionID")) {
			sessionID = PlayerPrefs.GetString("Param_SessionID");	

			if (sessionID == "Session0") {
				BaseLineDuration = 360f;
				
			} else {
				BaseLineDuration = 120f;
			}
            started = false;
			//if (SingleUserSession) { Debug.Log( "single user session");
			//} else { Debug.Log ("multi user session");
		}
	}


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Param_HostOrNot"))
        {
            if (PlayerPrefsX.GetBool("Param_HostOrNot"))
            {
                GameObject.Find("Network Manager").GetComponent<NetworkManager>().StartHost();
                Debug.Log("Started host");
            }
            else
            {
                GameObject.Find("Network Manager").GetComponent<NetworkManager>().StartClient();
                Debug.Log("Started client");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectsWithTag("Player").Length > 1 && !started)
        {
            started = true;
            StartCoroutine("SessionTimer");
            StartCoroutine("StartTimer");
            CameraFadeCanvas = GameObject.Find("Main Camera").gameObject.GetComponent<CanvasGroup>();
            StartCoroutine("FadeToClear", 0.15f);
            Debug.Log("started baseline");
        }
        /*	if (BeginEndFade) {
				StartCoroutine ("FadeToBlack", 0.15f);
			}*/
        if (Input.GetKeyDown(KeyCode.F1)) {
            NetworkManager.singleton.StopHost();
            NetworkManager.singleton.StopServer();
            SceneManager.LoadScene(0); }
        if (Input.GetKeyDown(KeyCode.F2)) {
            NetworkManager.singleton.StopHost();
            NetworkManager.singleton.StopServer();
            SceneManager.LoadScene(1); }
        if (Input.GetKeyDown(KeyCode.F3)) {
            NetworkManager.singleton.StopHost();
            NetworkManager.singleton.StopServer();
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.F4)) {
            NetworkManager.singleton.StopHost();
            NetworkManager.singleton.StopServer();
            SceneManager.LoadScene(3); }

    }

    IEnumerator SessionTimer()
	{
		//Debug.Log ("Session Timer Launched");
		yield return new WaitForSeconds (BaseLineDuration - 3f);
		BeginEndFade = true;
		yield return new WaitForSeconds (3f);
		//Debug.Log ("return to main menu");
		//NetworkManager nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		//	NetworkManager.singleton.StopHost();
		//NetworkManager.Shutdown();


		if (sessionID == "Session0") {
            //Application.LoadLevel (0);
            NetworkManager.singleton.StopHost();
            NetworkManager.singleton.StopServer();
            SceneManager.LoadScene(0);
		} else {
            //Application.LoadLevel (1);
            string[] multiPlayerSessions = new string[] { "Session1", "Session2", "Session3", "Session4", "Session5", "Session6", "Session7", "Session8" };
            if (PlayerPrefs.HasKey("Param_SessionID"))
            {
                string session = PlayerPrefs.GetString("Param_SessionID");
                if (System.Array.IndexOf(multiPlayerSessions, session) > -1)
                {
                    if (PlayerPrefs.HasKey("Param_HostOrNot"))
                    {
                        if (PlayerPrefsX.GetBool("Param_HostOrNot"))
                        {
                            while (GameObject.FindGameObjectsWithTag("Player").Length > 1)
                            {
                                yield return new WaitForSeconds(0.1f);
                            }
                            NetworkManager.singleton.StopHost();
                            NetworkManager.singleton.StopServer();
                            //GameObject.Find("Network Manager").GetComponent<NetworkManager>().StopHost();
                            //GameObject.Find("Network Manager").GetComponent<NetworkManager>().StopServer();
                        } else
                        {
                            NetworkManager.Shutdown();
                            yield return new WaitForSeconds(0.2f);
                        }
                    }
                }
            }
            
            SceneManager.LoadScene(2);
        }
	}


	IEnumerator StartTimer()
	{
		//Debug.Log ("Session Timer Launched");
		yield return new WaitForSeconds(StartTimerLength);
		StartTimerDone = true;
	}

	public IEnumerator FadeToBlack(float speed)
	{   /*
		while (CameraFadeCanvas.alpha < 1f)
		{
			CameraFadeCanvas.alpha += speed * Time.deltaTime;

				
		}*/
        yield return null;
    }

	public IEnumerator FadeToClear(float speed)
	{
        /*
			while (CameraFadeCanvas.alpha > 0f)
		{
			CameraFadeCanvas.alpha -= speed * Time.deltaTime;
				

			yield return null;
		}*/
        yield return null;
        Debug.Log ("Fading to Clear");
	}


}
