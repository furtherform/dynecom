using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class BreathLayerer : NetworkBehaviour
{
    //public GameObject Plane, Plane2, Plane3, Plane4;
    public GameObject[] planes;
    [SyncVar]
    public Color planeColor;
    public GameObject Player;
    public GameObject OtherPlane;
    public GameObject Plane, Plane2;
	public bool SyncHappened = false;
    [Range(0, 1)]
    public float PlaneTransparency = 0.2f;
    private float origAlpha;
    private bool isFadingIn;
    private bool isFadingOut;
    private float ownH, ownS, ownV;
    private float otherH, otherS, otherV;
    private float ownOrigV, otherOrigV;
    public BreathLayerer OtherScript;
    private NetworkIdentity objNetId;
    bool syncResetting = false;
    // Use this for initialization
    void Start()
    {
        //if (transform.name == "Player(Clone)")

        planes = new GameObject[5];

        /// network issues
        try
        { 
            int counter = 0;
            if (Player.GetComponent<PlayerManager>().PlayerNumber == 2)
            {
                foreach (Transform child in GameObject.Find("Player2_BridgeLayers").transform)
                {
                    planes[counter] = child.gameObject;
                    if (child.name.Equals("Plane5"))
                    {
                        Plane = child.gameObject;
                    }
                    if (child.name.Equals("Plane4"))
                    {
                        Plane2 = child.gameObject;
                    }
                    counter++;
                }
                foreach (Transform child in GameObject.Find("Player1_BridgeLayers").transform)
                {
                    if (child.name.Equals("Plane5"))
                    {
                        OtherPlane = child.gameObject;
                    }
                    counter++;
                }
            }
            else
            {
                foreach (Transform child in GameObject.Find("Player1_BridgeLayers").transform)
                {
                    planes[counter] = child.gameObject;
                    if (child.name.Equals("Plane5"))
                    {
                        Plane = child.gameObject;
                    }
                    if (child.name.Equals("Plane4"))
                    {
                        Plane2 = child.gameObject;
                    }
                    counter++;
                }
                foreach (Transform child in GameObject.Find("Player2_BridgeLayers").transform)
                {
                    if (child.name.Equals("Plane5"))
                    {
                        OtherPlane = child.gameObject;
                    }
                    counter++;
                }
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log("BreatheLayerer problem " + e);
        }

        System.Array.Reverse(planes);
        origAlpha = PlaneTransparency;
        // InvokeRepeating("InitBreatheBar", 2.0f, 5.0f);
    }

    public void InitBreatheBar()
    {
        StartCoroutine("Fades");
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
        planeColor = Player.GetComponent<PlayerFAScript>().PlayerColor;

        if ((SyncHappened) && (!syncResetting)) { StartCoroutine("SyncHappenedCheck");
        } 
    }


    IEnumerator Fades()
    {
        if (isFadingIn)
        {
            StopCoroutine("FadeIn");
        }
        else if (isFadingOut)
        {
            StopCoroutine("FadeOut");
        }
        yield return StartCoroutine("FadeIn");
        isFadingIn = false;

        if (OtherPlane.activeInHierarchy && OtherPlane.GetComponent<Renderer>().material.color.a > 0.1f)
        {
            StartCoroutine("SyncGlow");
            //OtherScript.StartSyncGlow();
        }

        yield return StartCoroutine("FadeOut");
        isFadingOut = false;
    }

    IEnumerator FadeIn()
    {
        isFadingIn = true;
        if (NetworkServer.active)
        {
            RpcInitColor();
        }
        else if (NetworkClient.active)
        {
            CmdInitColor();
        }
        // fixes client/server problem with material properties of the first plane
        yield return new WaitForSeconds(0.05f);
        if (planes[0].name == "Plane5") { 
            System.Array.Reverse(planes);
        }

        
        foreach (GameObject o in planes)
        {
            if (NetworkServer.active)
            {
                RpcSetState(o, true);
            }
            else if (NetworkClient.active)
            {
                CmdSetState(o, true);
            }

            Color color = o.GetComponent<Renderer>().material.color;
            for (float f = 0; f <= origAlpha; f += 0.05f)
            {
                color.a = f;
                if (NetworkServer.active)
                {
                    RpcSetColor(o, color);
                }
                else if (NetworkClient.active)
                {
                    CmdSetColor(o, color);
                }
                yield return null;
            }
        }
    }

    IEnumerator FadeOut()
    {
        isFadingOut = true;
        yield return new WaitForSeconds(1.5f);
        System.Array.Reverse(planes);

        foreach (GameObject o in planes)
        {
            Color color = o.GetComponent<Renderer>().material.color;
            for (float f = origAlpha; f >= 0; f -= 0.005f)
            {
                color.a = f;
                if (NetworkServer.active)
                {
                    RpcSetColor(o, color);
                }
                else if (NetworkClient.active)
                {
                    CmdSetColor(o, color);
                }
                yield return null;
            }
            if (NetworkServer.active)
            {
                RpcSetState(o, false);
            }
            else if (NetworkClient.active)
            {
                CmdSetState(o, false);
            }
        }
    }





    public void StartSyncGlow()
    {
        
        StartCoroutine("SyncGlow");
       
    }

	IEnumerator SyncHappenedCheck(){   // filewriter checks the variable changed here.
        Debug.Log("resetting breathing sync marker");
        syncResetting = true;
        yield return new WaitForSeconds(2.0f);
		SyncHappened = false;
        syncResetting = false;
        


    }


    IEnumerator SyncGlow()
    {
        SyncHappened = true;
       
        yield return StartCoroutine("SyncGlowIn");
        
 
        yield return StartCoroutine("SyncGlowOut");

    }

    IEnumerator SyncGlowIn()
    {
        Debug.Log("Breathing Sync happened!");
        Color colorOwn = Plane.GetComponent<Renderer>().material.color;
        Color color2 = Plane2.GetComponent<Renderer>().material.color;

        Color.RGBToHSV(colorOwn, out ownH, out ownS, out ownV);
        ownOrigV = ownV;
        for (float f = 0; f < 1.0f; f += 0.03f)
        {
            Color color = Color.HSVToRGB(ownH, ownS, ownV + f);
            color.a = origAlpha + f / 3;
            color2.a = origAlpha + f / 4;
            if (NetworkServer.active)
            {
                RpcSetSyncColor(color, color2);
                RpcSetSyncColorOther(color, color2);
            }
            else if (NetworkClient.active)
            {
                CmdSetSyncColor(color, color2);
                CmdSetSyncColorOther(color, color2);
            }
            //plane.GetComponent<Renderer>().material.SetColor("_Color", color);
            //plane2.GetComponent<Renderer>().material.SetColor("_Color", color2);
            yield return null;
        }
    }

    IEnumerator SyncGlowOut()
    {
        Color colorOwn = Plane.GetComponent<Renderer>().material.color;
        Color color2 = Plane2.GetComponent<Renderer>().material.color;
        colorOwn.a = 0.0f;
        Color.RGBToHSV(colorOwn, out ownH, out ownS, out ownV);
        for (float f = 1; f > 0; f -= 0.02f)
        {
            Color color = Color.HSVToRGB(ownH, ownS, ownOrigV + f);
            color.a = origAlpha + f / 3;
            color2.a = origAlpha + f / 4;

            if (NetworkServer.active)
            {
                RpcSetSyncColor(color, color2);
            }
            else if (NetworkClient.active)
            {
                CmdSetSyncColor(color, color2);
            }
            //plane.GetComponent<Renderer>().material.SetColor("_Color", color );
            //plane2.GetComponent<Renderer>().material.SetColor("_Color", color2);
            yield return null;
        }
    }


    [Command]
    void CmdInitColor()
    {
        RpcInitColor();
    }

    [ClientRpc]
    void RpcInitColor()
    {
        foreach(GameObject o in planes) { 
            planeColor.a = 0;
            o.GetComponent<Renderer>().material.SetColor("_Color", planeColor);
        }
    }



    [Command]
    void CmdSetColor(GameObject o, Color color)
    {
        RpcSetColor(o, color);
    }

    [ClientRpc]
    void RpcSetColor(GameObject o, Color color)
    {
        try
        {
            CmdAssignLocalAuthority(o);
            o.GetComponent<Renderer>().material.SetColor("_Color", color);
            CmdRemoveLocalAuthority(o);
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Problem in BreathLayerer RpcSetColor: " + e + ", exception source" + e.Source);
        }
        
    }

    [Command]
    void CmdSetSyncColor(Color color, Color color2)
    {
        CmdAssignLocalAuthority(Plane);
        CmdAssignLocalAuthority(Plane2);
        RpcSetSyncColor(color, color2);
        CmdRemoveLocalAuthority(Plane);
        CmdRemoveLocalAuthority(Plane2);
    }

    [ClientRpc]
    void RpcSetSyncColor(Color color, Color color2)
    {
        Plane.GetComponent<Renderer>().material.SetColor("_Color", color);
        Plane2.GetComponent<Renderer>().material.SetColor("_Color", color2);
    }

    [Command]
    void CmdSetSyncColorOther(Color color, Color color2)
    {
        CmdAssignLocalAuthority(Plane);
        CmdAssignLocalAuthority(Plane2);
        RpcSetSyncColorOther(color, color2);
        CmdRemoveLocalAuthority(Plane);
        CmdRemoveLocalAuthority(Plane2);
    }

    [ClientRpc]
    void RpcSetSyncColorOther(Color color, Color color2)
    {
        OtherPlane.GetComponent<Renderer>().material.SetColor("_Color", color);
        //Plane2.GetComponent<Renderer>().material.SetColor("_Color", color2);
    }

    [Command]
    void CmdSetState(GameObject o, bool state)
    {
        CmdAssignLocalAuthority(o);
        RpcSetState(o, state);
        CmdRemoveLocalAuthority(o);
    }

    [ClientRpc]
    void RpcSetState(GameObject o, bool state)
    {
        try
        {
            o.SetActive(state);
        } catch (NullReferenceException e)
        {
            Debug.Log("Problem in BreathLayerer RpcSetState: " + e + ", exception source: " + e.Source +", gameobject: ");
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