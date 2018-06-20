using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Networking;
using System;

public class PlayerManager : NetworkBehaviour
{
	
    public GameObject AuraExpander;
    public GameObject AuraController;
	public GameObject AuraBone; //accessed by filewriter for recording aura scale.
    public GameObject BridgeBars;
    public GameObject StatueAnimator;
	public GameObject AuraAnimator;


    [SyncVar]
    public bool IsNPC = false;
    [SyncVar]
    public float PlayerFA;
    GameObject SessionManager;
    GameObject DataHolder;
    GameObject SpawnPoint1;
    GameObject SpawnPoint2;
    public int PlayerNumber = 0;
    [SyncVar]
    public float breatheNow = 9f;
    [SyncVar]
    private float breathePast = 10f;
    private float respThreshold = 0f;
    private float respMax = -1f;
    private float respMin = 10000f;
    [SyncVar]
    bool inBreathContinues = false;
    [SyncVar]
    bool outBreathContinues = false;
    private GameObject otherPlayerManager;
    public float[] respArray = new float[5];
    public float[] faArray = new float[9];
    //private Queue<float> respQueue = new Queue< float > (10);

    public Queue<float> respMinQueue = new Queue<float>(new float[3]);
    public Queue<float> respMaxQueue = new Queue<float>(new float[3]);
    public Queue<float> respQueue = new Queue<float>(new float[5]);
    public Queue<float> faQueue = new Queue<float>(new float[9]);

    public bool RespChanged = true;
    float RespDataOld = 0f;
	public float fasync;

    bool firstwaveset = false;
    public bool breatheCooldown = false;
    bool breatheQueueCooldown = false;

    private NetworkIdentity objNetId;
	public string sessionName;
	//public Material UserStatue;
	//public Material NPCStatue;
	public GameObject[] PlayerStatues;
	public CanvasGroup CameraFadeCanvas;
	public Canvas CameraFaderTmp;

	public int numberOfUsers = 0;


	public Color SingleUserStatueColor = new Color (0.1f, 0.1f, 0.1f, 1f);
    // Use this for initialization
    void Start()
    {
		SessionManager = GameObject.Find("Session Manager");
		if (SessionManager.GetComponent<SessionManager>().SingleUserSession)
		{
			IsNPC = true;
		}

		// FINDING OBJECTS
		DataHolder = GameObject.Find("Data Holder");
		SpawnPoint1 = GameObject.Find("Spawn Point 1");
		SpawnPoint2 = GameObject.Find("Spawn Point 2");
	
		CameraFadeCanvas = gameObject.transform.Find ("Main Camera").gameObject.GetComponent<CanvasGroup>();
	



		PlayerStatues = new GameObject[4];
		PlayerStatues[0] = GameObject.Find("Statue_user1_MeshPart0");
		PlayerStatues[1] = GameObject.Find("Statue_user1_MeshPart1");
		PlayerStatues[2] = GameObject.Find("Statue_user2_MeshPart0");
		PlayerStatues[3] = GameObject.Find("Statue_user2_MeshPart1");


        

		// CHANGING THINGS ACCORDING THE SESSIONS.

		if (PlayerPrefs.HasKey ("Param_SessionID")) {
			sessionName = PlayerPrefs.GetString ("Param_SessionID");		
			//Debug.Log ("Session loaded:" + sessionName);
		} else {sessionName =" ";}

		if ((sessionName == "Session1") || (sessionName == "Session2") || (sessionName == "Session3") || (sessionName == "Session7")) {
			GetComponent<PlayerFAScript>().UseSyncGlow = false;

			try
			{ 
				for (int i = 0; i < PlayerStatues.Length; i++)
				{
					
					PlayerStatues[i].GetComponent<Renderer>().material.color = SingleUserStatueColor;  //>().color = PlayerColor;


				}
			} catch (NullReferenceException e) {
				Debug.Log("Statue Material color issue " + e);
			}

		}

	

        //find out which player this one is, if it has not been set yet.

        if (PlayerNumber == 0)
        {
            float dist1 = Vector3.Distance(this.transform.position, SpawnPoint1.transform.position);
            float dist2 = Vector3.Distance(this.transform.position, SpawnPoint2.transform.position);

            if (dist1 < dist2)
            {
                PlayerNumber = 2;
                Debug.Log("Player 2 found");
            }
            else
            {
                PlayerNumber = 1;
                Debug.Log("Player 1 found");
            }

            if (PlayerNumber == 1)
            {
                //AuraController = GameObject.Find("Player1_Manager");
                AuraController = gameObject;
               

                AuraExpander = GameObject.Find("AuraBone1");
                //BridgeBars = GameObject.Find("Player1_BridgeLayers");
                BridgeBars = gameObject;
                StatueAnimator = GameObject.Find("Statue_Player1");
				AuraAnimator = GameObject.Find("AuraNew_Player1");
				AuraBone = GameObject.Find("AuraBone1");
            }
            else
            {
                //AuraController = GameObject.Find("Player2_Manager");
                AuraController = gameObject;
                AuraExpander = GameObject.Find("AuraBone2");
                //AuraExpander = GameObject.Find("Aura_player2Expander");
                //BridgeBars = GameObject.Find("Player2_BridgeLayers");
                BridgeBars = gameObject;
                StatueAnimator = GameObject.Find("Statue_Player2");
				AuraAnimator = GameObject.Find("AuraNew_Player2");
				AuraBone = GameObject.Find("AuraBone2");
            }

        }

		StartCoroutine ("FadeToClear", 0.15f);
    }





    // Update is called once per frame
    void FixedUpdate()
	{
        if (!SessionManager.GetComponent<SessionManager>().SingleUserSession)
        {
            if (!isLocalPlayer)
            {
                return;
            }
        }


		//here we find if we have two users present.
	//	if (Network.connections.Length >= 2) {
	//	numberOfUsers = 2;} else {numberOfUsers = 1;}



        // Handling respiration Data.

        if (RespDataOld - SensorData.RespOut != 0) {
			RespDataOld = SensorData.RespOut;
			RespChanged = true;

		}
		breathePast = breatheNow;

		if (GameObject.Find ("Session Manager").GetComponent<SessionManager> ().StartTimerDone) {
       
			//check if we need to run simulations? Not relevant as we won't be running simulations.

			if (((SessionManager.GetComponent<SessionManager> ().SimulateSelf == true) && (IsNPC == false)) || ((IsNPC == true) && (SessionManager.GetComponent<SessionManager> ().SimulateOther == true))) {

				if (PlayerNumber == 1) {
					PlayerFA = DataHolder.GetComponent<SimulationData> ().P1FrontAs;
					breatheNow = DataHolder.GetComponent<SimulationData> ().P1Breathing;

				}

				if (PlayerNumber == 2) {
					PlayerFA = DataHolder.GetComponent<SimulationData> ().P2FrontAs;
					breatheNow = DataHolder.GetComponent<SimulationData> ().P2Breathing;

				}

			} else

		



 {		//we are using adaptations coming from sensors. Repated for the both user cases.
				if (PlayerNumber == 1) {

					if (RespChanged) {
						if (respQueue.Count == 5) {
							respQueue.Dequeue ();
						}
						respQueue.Enqueue (SensorData.RespOut);
						respArray = respQueue.ToArray ();
						breatheNow = respArray.Average ();
						respArray = respQueue.ToArray ();
						//breatheNow = respQueue.Average();

						if (!breatheQueueCooldown) {
							breatheQueueCooldown = true;
							if (respMaxQueue.Count > 0) {
								respMaxQueue.Dequeue ();
							}
							if (respMinQueue.Count > 0) {
								respMinQueue.Dequeue ();
							}
							StartCoroutine ("RespQueCoolDown");
						}


						if (respQueue.Max () > respMax) {
							if (respMaxQueue.Count == 3) {
								respMaxQueue.Dequeue ();
							}
							respMaxQueue.Enqueue (respQueue.Max ());
							respMax = respMaxQueue.Average ();
						}
						if (respQueue.Min () < respMin) {
							if (respMinQueue.Count == 3) {
								respMinQueue.Dequeue ();
							}
							respMinQueue.Enqueue (respQueue.Min ());
							respMin = respMinQueue.Average ();
						}

						respThreshold = (respMax - respMin) * 0.02f;


						if (faQueue.Count == 9) {
							faQueue.Dequeue ();
						}
						faQueue.Enqueue (SensorData.FAOut);
						faArray = faQueue.ToArray ();
						PlayerFA = faArray.Average ();
						faArray = faQueue.ToArray ();

						//PlayerFA = SensorData.FAOut;
						//breatheNow = SensorData.RespOut;
						Debug.Log ("new resp calculated");
						RespChanged = false;

					}
				}

				if (PlayerNumber == 2) {
					if (RespChanged) {
						if (respQueue.Count == 5) {
							respQueue.Dequeue ();
						}
						respQueue.Enqueue (SensorData.RespOut);
						respArray = respQueue.ToArray ();
						breatheNow = respArray.Average ();
						respArray = respQueue.ToArray ();
						//breatheNow = respQueue.Average();

						if (!breatheQueueCooldown) {
							breatheQueueCooldown = true;
							if (respMaxQueue.Count > 0) {
								respMaxQueue.Dequeue ();
							}
							if (respMinQueue.Count > 0) {
								respMinQueue.Dequeue ();
							}
							StartCoroutine ("RespQueCoolDown");
						}

                    
						if (respQueue.Max () > respMax) {                        
							respMaxQueue.Enqueue (respQueue.Max ());
							respMax = respMaxQueue.Average ();
						}
						if (respQueue.Min () < respMin) {                        
							respMinQueue.Enqueue (respQueue.Min ());
							respMin = respMinQueue.Average ();
						}


						respThreshold = (respMax - respMin) * 0.02f;

						if (faQueue.Count == 9) {
							faQueue.Dequeue ();
						}
						faQueue.Enqueue (SensorData.FAOut);
						faArray = faQueue.ToArray ();
						PlayerFA = faArray.Average ();
						faArray = faQueue.ToArray ();

						//PlayerFA = SensorData.FAOut;
						//breatheNow = SensorData.RespOut;
						Debug.Log ("new resp calculated");
						RespChanged = false;

					}


				}

			}


			// define which asset sets we are using. (woudln't need to be in fixed update, but well...)
			if (PlayerNumber == 1) {
				otherPlayerManager = GameObject.Find ("Player2_Manager");
			}

			if (PlayerNumber == 2) {
				otherPlayerManager = GameObject.Find ("Player1_Manager");
			}


            //defining player FA colors.
            // put conditions here. 




            //FA COLOR definitions.
            if ((!IsNPC && SessionManager.GetComponent<SessionManager>().EegSelf) || (SessionManager.GetComponent<SessionManager>().EegOther))
            {
                if (SessionManager.GetComponent<SessionManager>().EegSelf)
                {
                    AuraController.GetComponent<PlayerFAScript>().PlayerFA_Display = PlayerFA;

                }
                else
                {
                    AuraController.GetComponent<PlayerFAScript>().PlayerFA_Display = 0.2f; 
                }
            }


            /*
            if (!IsNPC) {

				if (SessionManager.GetComponent<SessionManager> ().EegSelf) {
					AuraController.GetComponent<PlayerFAScript> ().PlayerFA_Display = PlayerFA;
			
				} else {
					AuraController.GetComponent<PlayerFAScript> ().PlayerFA_Display = 0.2f;
				}
			} else {
				if (SessionManager.GetComponent<SessionManager> ().EegOther) {
					AuraController.GetComponent<PlayerFAScript> ().PlayerFA_Display = PlayerFA;
				} else {
					AuraController.GetComponent<PlayerFAScript> ().PlayerFA_Display = 0.2f;
				}

			}*/

			float otherPlayerFA = otherPlayerManager.GetComponent<PlayerFAScript> ().PlayerFA_Display;
			AuraController.GetComponent<PlayerFAScript> ().OtherFA = otherPlayerFA;
			//AuraController.GetComponent<PlayerFAScript>().PlayerFA_Display = PlayerFA;





			// calculate the synchronicity of FA. // not used in this script.
			fasync = Mathf.Abs (PlayerFA - otherPlayerFA);  
			//print(PlayerFA + "  " + otherPlayerFA + "   " + fasync);




// RESPIRATION CONTROLS START HERE
        
// RESP.PHASE1 - FIRST BREATHE OUT
			if ((breatheNow < breathePast - respThreshold) && (outBreathContinues == false)) {
                //		Debug.Log ("Player " + PlayerNumber + " breathing out");
                //		Debug.Log (PlayerNumber + ": " + breathePast + " " + breatheNow);

                // STATUE BREATHEING OUT
                // jos olen pelaaja, katson onko selfresp käytössä, ja sit käynnistän patsaan 
                // jos en ole pelaaja, katson onko respother käytässä, ja näytän patsaan hengitysanimaation.
                if ((!IsNPC && SessionManager.GetComponent<SessionManager>().RespSelf) || (SessionManager.GetComponent<SessionManager>().RespOther))
                {
                    if (NetworkServer.active)
                    {
                        RpcAnimateStatue(false);
                    }
                    else if (NetworkClient.active)
                    {
                        CmdAnimateStatue(false);
                    }
                }

                /*
                if (!IsNPC) {
				
					if (SessionManager.GetComponent<SessionManager> ().RespSelf) {
						StatueAnimator.GetComponent<Animator> ().SetTrigger ("StartOut");
						//Debug.Log ("Player " + PlayerNumber + " breathing out");
					}
				} else {
					if (SessionManager.GetComponent<SessionManager> ().RespOther) {
						StatueAnimator.GetComponent<Animator> ().SetTrigger ("StartOut");
						//Debug.Log ("NPC " + PlayerNumber + " breathing out");
					}
				}	*/
            


				// WAVE EFFECT
				if (SessionManager.GetComponent<SessionManager> ().Waves) {
					GetComponent<Adap_WaveSend> ().SendWave (PlayerNumber);
				}



                // BRIDGE BREATHING EFFECT


                if ((!IsNPC && SessionManager.GetComponent<SessionManager>().RespSelf) || (SessionManager.GetComponent<SessionManager>().RespOther))
                {
                    if (firstwaveset && !breatheCooldown)
                    {
                        breatheCooldown = true;
                      //  Debug.Log("user breathing wave sent");
                        BridgeBars.GetComponent<BreathLayerer>().InitBreatheBar();
                        Debug.Log("Player " + PlayerNumber + " breathing bar sent");
                        //	Debug.Log (PlayerNumber + ": " + breathePast + " " + breatheNow);
                        StartCoroutine("CoolDown");

                    }
                    else
                    {
                        firstwaveset = true;
                    }
                        
                }

                /*
                if (!IsNPC) {

					if (SessionManager.GetComponent<SessionManager> ().RespSelf) {
						//if ((SessionManager.GetComponent<SessionManager> ().BridgeMeterSelf)) {

						if (firstwaveset && !breatheCooldown) {
							breatheCooldown = true;
							Debug.Log ("user breathing wave sent");
							BridgeBars.GetComponent<BreathLayerer> ().InitBreatheBar ();
							Debug.Log ("Player " + PlayerNumber + " breathing bar sent");
							//	Debug.Log (PlayerNumber + ": " + breathePast + " " + breatheNow);
							StartCoroutine ("CoolDown");

						} else
							firstwaveset = true;
					}
				} else {
					if (SessionManager.GetComponent<SessionManager> ().RespOther) {
						//if ((SessionManager.GetComponent<SessionManager> ().BridgeMeterSelf)) {

						if (firstwaveset && !breatheCooldown) {
							breatheCooldown = true;
							Debug.Log ("user breathing wave sent");
							BridgeBars.GetComponent<BreathLayerer> ().InitBreatheBar ();
							Debug.Log ("NPC " + PlayerNumber + " breathing bar sent");
							//	Debug.Log (PlayerNumber + ": " + breathePast + " " + breatheNow);
							StartCoroutine ("CoolDown");

						} else
							firstwaveset = true;
					}
				}*/


				outBreathContinues = true;

				inBreathContinues = false;


			}

// RESP.PHASE2 - BREATHING OUT CONTINUES

			if (outBreathContinues == true) {
                // RESPIRATION AURA SCALING EFFECT 

                if ((!IsNPC && SessionManager.GetComponent<SessionManager>().RespSelf) || (SessionManager.GetComponent<SessionManager>().RespOther))
                {
                    if (NetworkServer.active)
                    {
                        RpcScaleAuraExpand(false);
                    }
                    else if (NetworkClient.active)
                    {
                        CmdScaleAuraExpand(false);
                    }
                    Debug.Log("Aura scaled breathing out!");
                }
                /*
				if (!IsNPC) {

					if ((SessionManager.GetComponent<SessionManager> ().RespSelf)) {//if auraefekti on päällä
						AuraExpander.GetComponent<AuraScaler> ().expand = false;
					}

				} else {

					if ((SessionManager.GetComponent<SessionManager> ().RespOther)) {//if auraefekti on päällä
						AuraExpander.GetComponent<AuraScaler> ().expand = false;
					}

				}*/
            }


// RESP.PHASE 3 - FIRST BREATHE IN

			if ((breatheNow >= breathePast + respThreshold) && (inBreathContinues == false)) {

                //STATUE BREATHING EFFECT

                if ((!IsNPC && SessionManager.GetComponent<SessionManager>().RespSelf) || (SessionManager.GetComponent<SessionManager>().RespOther))
                {
                    if (NetworkServer.active)
                    {
                        RpcAnimateStatue(true);
                    }
                    else if (NetworkClient.active)
                    {
                        CmdAnimateStatue(true);
                    }
                }

                /*
                if (!IsNPC) {

					if (SessionManager.GetComponent<SessionManager> ().RespSelf) {
						StatueAnimator.GetComponent<Animator> ().SetTrigger ("StartIn");
						//Debug.Log ("breath out animtrigger sent");
					}
				} else {
					if (SessionManager.GetComponent<SessionManager> ().RespOther) {
						StatueAnimator.GetComponent<Animator> ().SetTrigger ("StartIn");
					}

				}*/

				outBreathContinues = false;
				inBreathContinues = true;

				//		if (SessionManager.GetComponent<SessionManager>().StatueBreathingSelf){
				//			StatueAnimator.GetComponent<Animator>().SetTrigger("StartIn");}

          
			}



// RESP.PHASE 4 - BREATHING IN CONTINUES
			if (inBreathContinues == true) {
				// RESPIRATION AURA SCALING EFFECT 
                if ((!IsNPC && SessionManager.GetComponent<SessionManager>().RespSelf) || (SessionManager.GetComponent<SessionManager>().RespOther))
                {
                    if (NetworkServer.active)
                    {
                        RpcScaleAuraExpand(true);
                    }
                    else if (NetworkClient.active)
                    {
                        CmdScaleAuraExpand(true);
                    }

                    Debug.Log("Aura scaled breathing in!");
                }

                /*
				if (!IsNPC) {

					if ((SessionManager.GetComponent<SessionManager> ().RespSelf)) {//if auraefekti on päällä
						AuraExpander.GetComponent<AuraScaler> ().expand = true;
                    }

				} else {

					if ((SessionManager.GetComponent<SessionManager> ().RespOther)) {//if auraefekti on päällä
                        AuraExpander.GetComponent<AuraScaler> ().expand = true;
					}

				}*/
			}
		}

		if (SessionManager.GetComponent<SessionManager> ().BeginEndFade) {
			StartCoroutine ("FadeToBlack", 0.15f);
		}

	}




	public IEnumerator FadeToBlack(float speed)
	{
		while (CameraFadeCanvas.alpha < 1f)
		{
			CameraFadeCanvas.alpha += speed * Time.deltaTime;

			yield return null;
		}
	}

	public IEnumerator FadeToClear(float speed)
	{
		while (CameraFadeCanvas.alpha > 0f)
		{
			CameraFadeCanvas.alpha -= speed * Time.deltaTime;

			yield return null;
		}
	}



    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1.0f); //file writing is once per second, this
        breatheCooldown = false;
    }

    IEnumerator RespQueCoolDown()
    {
        yield return new WaitForSeconds(4.0f);
        breatheQueueCooldown = false;
    }

    [Command]
    void CmdAnimateStatue(bool startIn)
    {
        RpcAnimateStatue(startIn);
    }

    [ClientRpc]
    void RpcAnimateStatue(bool startIn)
    {
       // Debug.Log("startin " + startIn);
        if (startIn)
        {
            AuraAnimator.GetComponent<Animator>().SetTrigger("StartOutAura");
            StatueAnimator.GetComponent<Animator>().SetTrigger("StartIn");
			
        }
        else
        {
            AuraAnimator.GetComponent<Animator>().SetTrigger("StartInAura");
            StatueAnimator.GetComponent<Animator>().SetTrigger("StartOut");
			
        }


    }



    [Command]
    void CmdScaleAuraExpand(bool expand)
    {
        RpcScaleAuraExpand(expand);
    }

    [ClientRpc]
    void RpcScaleAuraExpand(bool expand)
    {
        if (expand)
        {
            try
            {
                AuraExpander.GetComponent<AuraScaler>().expand = true;
            }
            catch (UnassignedReferenceException e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            try
            {
                AuraExpander.GetComponent<AuraScaler>().expand = false;
            }
            catch (UnassignedReferenceException e)
            {
                Debug.Log(e);
            }
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