using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
public class PlayerFAScript : NetworkBehaviour
{
    // THIS IS USED FOR CONTROLLING AURA COLOR
    // HAS MANUALLY PLACED OBJECTS, 
    // PLAYERMANAGER HANDLES INPUT TO HERE.


    public Gradient FAColorSlide = new Gradient();
    [SyncVar]
	public Color PlayerColor = new Color(0.3f, 0.3f, 0.3f, 0.3f);
    public GameObject PlayerBridgeSides;
    public GameObject PlayerAura;
    public GameObject PlayerAura2;
    public GameObject[] PlayerLights;
    //public GameObject PlayerStatue; 
    [SyncVar]
    public float PlayerFA_Display = 0.0f;
    //public float PlayerFA_adjusted;
    [SyncVar]
    public float OtherFA = 0.0f;
    [SyncVar]
    public Color AuraColor;
    public bool UseSyncGlow = false;
    float auraH;
    float auraS;
    float auraV;
    float glowS;
    float glowVMod;
    bool flickerS;
    bool flickerV;
    private NetworkIdentity objNetId;
    [SyncVar]
    public int playerNumber;

    private GameObject BridgeLayers;

	public string sessionName;
	public float fasync;

    public GameObject OtherFAObject; //used for debugging.

    // Use this for initialization
    void Start()
    {
		if (PlayerPrefs.HasKey ("Param_SessionID")) {
			sessionName = PlayerPrefs.GetString ("Param_SessionID");		
			//Debug.Log ("Session loaded:" + sessionName);
		} else {sessionName =" ";}
		if ((sessionName == "Session1") || (sessionName == "Session2") || (sessionName == "Session3") || (sessionName == "Session7")) {
			UseSyncGlow = false;
		}


		PlayerColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        PlayerFA_Display = 0.0f;
        /*if (transform.name == "Player(Clone)")
        {
            if (!isLocalPlayer)
            {
               // return;
            }
        }*/
        GameObject SpawnPoint1 = GameObject.Find("Spawn Point 1");
        GameObject SpawnPoint2 = GameObject.Find("Spawn Point 2");
        float dist1 = Vector3.Distance(this.transform.position, SpawnPoint1.transform.position);
        float dist2 = Vector3.Distance(this.transform.position, SpawnPoint2.transform.position);
        if (dist1 < dist2)
        {
            playerNumber = 2;
            PlayerBridgeSides = GameObject.Find("Player2_BridgeSides");
            PlayerAura = GameObject.Find("AuraAnimated_p2");
            PlayerAura2 = GameObject.Find("Aura_player2Expander");
            PlayerLights[0] = GameObject.Find("Light_Player2");
            PlayerLights[1] = GameObject.Find("Light_Player2 (2)");
            PlayerLights[2] = GameObject.Find("Light_Player2 (1)");
            PlayerLights[3] = GameObject.Find("Light_Player2 (3)");
            BridgeLayers = GameObject.Find("Player2_BridgeLayers");
        }
        else
        {
            playerNumber = 1;
            PlayerBridgeSides = GameObject.Find("Player1_BridgeSides");
            PlayerAura = GameObject.Find("AuraAnimated_p1");
            PlayerAura2 = GameObject.Find("Aura_player1Expander");
            PlayerLights[0] = GameObject.Find("Light_Player1");
            PlayerLights[1] = GameObject.Find("Light_Player1 (2)");
            PlayerLights[2] = GameObject.Find("Light_Player1 (1)");
            PlayerLights[3] = GameObject.Find("Light_Player1 (3)");
            BridgeLayers = GameObject.Find("Player1_BridgeLayers");
        }
        
        Debug.Log("playernumne " + playerNumber);
        //UseSyncGlow = false;
        glowS = 1.0f;

        // dynamic modifier for glow HDR
        glowVMod = 0.5f;
        UseSyncGlow = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.name == "Player(Clone)")
        {
            if (!isLocalPlayer)
            {
                return;
            }
        }

        if ((GameObject.Find("Session Manager").GetComponent<SessionManager>().StartTimerDone) && (sessionName != "Session3") && (sessionName != "Session7"))
        { UseSyncGlow = true; }

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
;           if (player.GetComponent<PlayerFAScript>().playerNumber != playerNumber)
            {
                if (NetworkClient.active)
                {
                    CmdSetFA(PlayerFA_Display);
                }
                OtherFA = player.GetComponent<PlayerFAScript>().PlayerFA_Display;

                Debug.Log("Other player numnber:" + player.GetComponent<PlayerFAScript>().playerNumber + " My player number: " + playerNumber);
                Debug.Log("other FA: " + player.GetComponent<PlayerFAScript>().PlayerFA_Display + "My FA: "+ PlayerFA_Display);
                OtherFAObject = player;

            }
        }

		//color changes and synchronising the sides are only done if EegSelf is active.
		if (GameObject.Find ("Session Manager").GetComponent<SessionManager> ().EegSelf) {
			
			PlayerColor = FAColorSlide.Evaluate (PlayerFA_Display);
			if (NetworkServer.active) {
				RpcSetPlayerColor ();
			} else if (NetworkClient.active) {
				CmdSetPlayerColor ();
			}
			Color.RGBToHSV (PlayerColor, out auraH, out auraS, out auraV);
			auraS = 0.72f;
			auraV = 0.35f;
			AuraColor = Color.HSVToRGB (auraH, auraS, auraV);
			AuraColor.a = 0.05f + PlayerFA_Display * 0.7f;

			Color BridgeSideColor = PlayerColor;
			BridgeSideColor.a = 0.4f;

			if (NetworkServer.active) {
				RpcSetColors (AuraColor, BridgeSideColor);
			} else if (NetworkClient.active) {
				CmdSetColors (AuraColor, BridgeSideColor);
			}


			if (NetworkServer.active) {
				RpcPlayerLight (PlayerColor, PlayerFA_Display);

			} else if (NetworkClient.active) {
				CmdPlayerLight (PlayerColor, PlayerFA_Display);
			}

			if (UseSyncGlow) { 
				// calculates the sync, 0 -> sync and 1 -> !sync 
				fasync = Mathf.Abs (PlayerFA_Display - OtherFA);

				// Lower and flickering emission saturation according to FA-level when FA-levels in sync
				if (fasync < 0.1f)
                {
                    //Debug.Log("IN SYNC " + fasync);
                    if (glowS > 0.75f && !flickerS) {
						glowS -= 0.001f;
					} else {
						flickerS = true;
					}
					if (glowS < 0.9 && flickerS) {
						glowS += 0.001f;
					} else {
						flickerS = false;
					}
					// emission brightness correlates with FA-sync
					auraV = glowVMod - fasync;
					if (glowVMod < 2.0f && !flickerV) {
						glowVMod += 0.001f;
					} else {
						flickerV = true;
					}
					if (glowVMod > 1.0f && flickerV) {
						glowVMod -= 0.001f;
					} else {
						flickerV = false;
					}
				}
                // When falls out of sync, incrementally raise saturation to maximum
                else
                {
					auraV = 0.5f - fasync * 2f;
					if (auraV <= 0f) {
						auraV = 0f;
					}
					
					if (glowS < 1) {
						glowS += 0.05f;
					}
					if (glowVMod > 0.5f) {
						glowVMod -= 0.05f;
					}
				}


				Color emissionColor = Color.HSVToRGB (auraH, glowS, auraV);
				if (NetworkServer.active) {
					RpcEmission (emissionColor);
				} else if (NetworkClient.active) {
					CmdEmission (emissionColor);
				}
			}
		}
        // used with gradient shader
        //PlayerBridgeSides.GetComponent<Renderer>().material.SetFloat("_Threshold", 1.0f - PlayerFA_Display);
    }


    [Command]
    void CmdSetFA(float playerFA)
    {
        PlayerFA_Display = playerFA;
    }


    [Command]
    void CmdSetPlayerColor()
    {
        RpcSetPlayerColor();
    }

    [ClientRpc]
    void RpcSetPlayerColor()
    {
        PlayerColor = FAColorSlide.Evaluate(PlayerFA_Display);
       /* try { 
            BridgeLayers.GetComponent<BreathLayerer>().planeColor = PlayerColor;
        } catch (NullReferenceException e)
        {
            Debug.Log(e);
        }*/
    }



    [Command]
    void CmdPlayerLight(Color PlayerColor, float PlayerFA_Display)
    {
        for (int i = 0; i < PlayerLights.Length; i++)
        {
           // CmdAssignLocalAuthority(PlayerLights[i]);
        }
        RpcPlayerLight(PlayerColor, PlayerFA_Display);
        
        for (int i = 0; i < PlayerLights.Length; i++)
        {
           // CmdRemoveLocalAuthority(PlayerLights[i]);
        }
    }

    [ClientRpc]
    void RpcPlayerLight(Color PlayerColor, float PlayerFA_Display)
    {
        try
        { 
            for (int i = 0; i < PlayerLights.Length; i++)
            {
                PlayerLights[i].GetComponent<Light>().color = PlayerColor;
                PlayerLights[i].GetComponent<Light>().intensity = 0.05f + PlayerFA_Display * 1.1f;

            }
        } catch (NullReferenceException e)
        {
            Debug.Log("Playerlights probably not initialized " + e);
        }
    }


    [Command]
    void CmdEmission(Color emissionColor)
    {
        RpcEmission(emissionColor);
    }

    [ClientRpc]
    void RpcEmission(Color emissionColor)
    {
        try
        {
            PlayerBridgeSides.GetComponent<Renderer>().material.SetColor("_EmissionColor", emissionColor);
        }
        catch (UnassignedReferenceException e)
        {
            Debug.Log(e);
        }
    }

    [Command]
    void CmdSetColors(Color AuraColor, Color BridgeSideColor)
    {
        CmdAssignLocalAuthority(PlayerBridgeSides);
        CmdAssignLocalAuthority(PlayerAura);
        CmdAssignLocalAuthority(PlayerAura2);
        RpcSetColors(AuraColor, BridgeSideColor);
        CmdRemoveLocalAuthority(PlayerBridgeSides);
        CmdRemoveLocalAuthority(PlayerAura);
        CmdRemoveLocalAuthority(PlayerAura2);
    }

    [ClientRpc]
    void RpcSetColors(Color AuraColor, Color BridgeSideColor)
    {
        try { 
            PlayerAura.GetComponent<Renderer>().material.SetColor("_TintColor", AuraColor);
		//	Debug.Log("Changing Player Aura Color - why it doesn't show?");
            AuraColor.a = AuraColor.a * 0.4f;
            PlayerAura2.GetComponent<Renderer>().material.SetColor("_TintColor", AuraColor);

            PlayerBridgeSides.GetComponent<Renderer>().material.color = BridgeSideColor;
        } catch (UnassignedReferenceException e)
        {
            Debug.Log(e);
        }
    }


    [Command]
    void CmdAssignLocalAuthority(GameObject obj)
    {
        objNetId = obj.GetComponent<NetworkIdentity>();
        objNetId.AssignClientAuthority(connectionToClient);
    }

    [Command]
    void CmdRemoveLocalAuthority(GameObject obj)
    {
        objNetId = obj.GetComponent<NetworkIdentity>();
        objNetId.RemoveClientAuthority(connectionToClient);
    }
}
