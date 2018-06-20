using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;

public class SessionManager : MonoBehaviour
{



    [Header("Session Parameters")]

    public bool MultiUserSession = true;
    public bool SimulateSelf = true;
    public bool SimulateOther = true;
    public Color NeutralEEGColor;
    public float SessionLength = 200f;
    public float StartTimerLength = 10f;
    public bool StartTimerDone = false;
    public bool FileWriting = false;

    /*
	public bool SimulateSelfFA = true;
	public bool SimulateSelfResp = true;
	public bool SimulateOtherFA = true;
	public bool SimulateOtherResp = true;
	*/


    [Header("AdaptationControls")]

    public bool RespSelf = true;
    public bool EegSelf = true;
    public bool EegOther = true;
    public bool RespOther = true;
    public string StaticIPStored;
    public bool TwoUserSession = true;
    [Header("OldControls")]
    public bool Waves = false;
    public bool BridgeMeter = true;
    public bool SingleUserSession = false;
    public GameObject SimPlayer;

    /*
	public bool BridgeMeterSelf = true;
	public bool BridgeSidesSelf = true;

	public bool AuraVisibleSelf = true;
	//public bool AuraColorSelf = true;
	public bool AuraScalingSelf = true;
	public bool PlayerLightsSelf = true;
	public bool StatueBreathingSelf = true;

	public bool BridgeMeterOth = true;
	public bool BridgeSidesOth = true;
	public bool AuraColorOth = true;
	public bool AuraVisibleOth = true;
	public bool AuraScalingOth = true;
	public bool PlayerLightsOth = true;
	*/


    [Header("Don't change")]

    bool bothPlayersIn = false;
    public GameObject[] activePlayers;
    bool otherInitialized = false;
    public GameObject activePlayer;
    public bool BeginEndFade;
    public bool countdownIntitialized = false;

    // Use this for initialization

    public GameObject[] PlayerObjectList;
    //PlayerObjectList = new List <GameObject();PlayerObjectList;
    bool clientHasLeft;

    void Awake()
    {
        //*//  
        //Loading parameters from the playerrefs.
        if (PlayerPrefs.HasKey("Param_SingleUserSession"))
        {
            SingleUserSession = PlayerPrefsX.GetBool("Param_SingleUserSession");
            //if (SingleUserSession) { Debug.Log( "single user session");
            //} else { Debug.Log ("multi user session");
        }

        if (PlayerPrefs.HasKey("Param_RespSelf"))
        {
            RespSelf = PlayerPrefsX.GetBool("Param_RespSelf");
            //if (SingleUserSession) { Debug.Log( "single user session");
            //} else { Debug.Log ("multi user session");
        }

        if (PlayerPrefs.HasKey("Param_RespOther"))
        {
            RespOther = PlayerPrefsX.GetBool("Param_RespOther");
            //if (SingleUserSession) { Debug.Log( "single user session");
            //} else { Debug.Log ("multi user session");
        }

        if (PlayerPrefs.HasKey("Param_EegSelf"))
        {
            EegSelf = PlayerPrefsX.GetBool("Param_EegSelf");
            //if (SingleUserSession) { Debug.Log( "single user session");
            //} else { Debug.Log ("multi user session");
        }

        if (PlayerPrefs.HasKey("Param_EegOther"))
        {
            EegOther = PlayerPrefsX.GetBool("Param_EegOther");
            //if (SingleUserSession) { Debug.Log( "single user session");
            //} else { Debug.Log ("multi user session");
        }

        if (PlayerPrefs.HasKey("StaticIPStored"))
        {
            StaticIPStored = PlayerPrefs.GetString("StaticIPStored");

        }
        else StaticIPStored = "127.0.0.1";

        if (PlayerPrefs.HasKey("SessionLengthStored"))
        {
            SessionLength = PlayerPrefs.GetFloat("SessionLengthStored");

        }



        //*/


    }


    void Start()
    {
        SessionLength = SessionLength + StartTimerLength + 3f;
        Debug.Log(SessionLength);
        StartCoroutine("StartTimer");

        StartCoroutine("SessionTimer");
        clientHasLeft = false;
    }



    // Update is called once per frame
    void Update()
    {






        // we initialize the simulated player 2 opposite of the user.
        if ((SingleUserSession == true) && (otherInitialized != true))
        {

            if (activePlayers == null)
            {
                activePlayers = GameObject.FindGameObjectsWithTag("Player");
            }

            if (activePlayers.Length == 0)
            {
                activePlayers = GameObject.FindGameObjectsWithTag("Player");
            }
            else
            {

                activePlayer = activePlayers[0];
                int playerNumber = activePlayer.GetComponent<PlayerManager>().PlayerNumber;
                SimPlayer.SetActive(true);

                if (playerNumber == 2)
                {
                    SimPlayer.GetComponent<PlayerManager>().PlayerNumber = 1;
                    SimPlayer.GetComponent<PlayerManager>().AuraController = GameObject.Find("Player1_Manager");
                    SimPlayer.GetComponent<PlayerManager>().AuraExpander = GameObject.Find("Aura_player1Expander");
                    SimPlayer.GetComponent<PlayerManager>().BridgeBars = GameObject.Find("Player1_BridgeLayers");
                    SimPlayer.GetComponent<PlayerManager>().StatueAnimator = GameObject.Find("Statue_Player1");
                    SimPlayer.GetComponent<PlayerManager>().AuraAnimator = GameObject.Find("AuraNew_Player1");

                    SimPlayer.GetComponent<PlayerManager>().IsNPC = true;

                }
                else
                {
                    SimPlayer.GetComponent<PlayerManager>().PlayerNumber = 2;
                    SimPlayer.GetComponent<PlayerManager>().AuraController = GameObject.Find("Player2_Manager");
                    SimPlayer.GetComponent<PlayerManager>().AuraExpander = GameObject.Find("Aura_player2Expander");
                    SimPlayer.GetComponent<PlayerManager>().BridgeBars = GameObject.Find("Player2_BridgeLayers");
                    SimPlayer.GetComponent<PlayerManager>().StatueAnimator = GameObject.Find("Statue_Player2");
                    SimPlayer.GetComponent<PlayerManager>().AuraAnimator = GameObject.Find("AuraNew_Player2");

                    SimPlayer.GetComponent<PlayerManager>().IsNPC = true;
                }
                otherInitialized = true;

            }

        }



        if (Input.GetKeyDown(KeyCode.F1)) { SceneManager.LoadScene(0); }
        if (Input.GetKeyDown(KeyCode.F2)) { SceneManager.LoadScene(1); }
        if (Input.GetKeyDown(KeyCode.F3)) { SceneManager.LoadScene(2); }
        if (Input.GetKeyDown(KeyCode.F4)) { SceneManager.LoadScene(3); }

    }

    IEnumerator SessionTimer()
    {
        //Debug.Log ("Session Timer Launched");
        yield return new WaitForSeconds(SessionLength - 3f);
        BeginEndFade = true;
        yield return new WaitForSeconds(3f);
        //Debug.Log ("return to main menu");
        //NetworkManager nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        //	NetworkManager.singleton.StopHost();
        //NetworkManager.Shutdown();
        string[] multiPlayerSessions = new string[] { "Session4", "Session5", "Session6", "Session8" };
        if (PlayerPrefs.HasKey("Param_SessionID"))
        {
            string session = PlayerPrefs.GetString("Param_SessionID");
            if (System.Array.IndexOf(multiPlayerSessions, session) > -1)
            {
                if (PlayerPrefs.HasKey("Param_HostOrNot"))
                {
                    if (PlayerPrefsX.GetBool("Param_HostOrNot"))
                    {
                        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
                        {
                            yield return new WaitForSeconds(1.5f);
                            NetworkManager.singleton.StopHost();
                            NetworkManager.singleton.StopServer();
                        }

                    } else
                    {
                        //NetworkManager.Shutdown();
                    }
                }
            }
        }

        SceneManager.LoadScene(3);
    }

    IEnumerator StartTimer()
    {
        //Debug.Log ("Session Timer Launched");
        yield return new WaitForSeconds(StartTimerLength);
        StartTimerDone = true;
    }

    private void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        if (Network.isServer)
        {
            Debug.Log("Local server connection disconnected");
        }

        else if (info == NetworkDisconnection.LostConnection)
        {
            Debug.Log("Lost connection to the server");
        }
        else
        {
            Debug.Log("Successfully diconnected from the server");
        }
        SceneManager.LoadScene(3);
    }
}
