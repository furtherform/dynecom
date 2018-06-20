using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AuraScaler : NetworkBehaviour {
	public float ExpandSpeed = 0.03f;
	public float maxSize = 1.5f;
	public float minSize = 1.0f;
	float scalefactor = 1.1f;
	public bool expand = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//scalefactor = (0.40f + 0.15f * (Mathf.Sin (Time.time * 0.8f)*0.5f + 1f));
		// eli, tossa on sinikäyrä välillä 0-1, (ajanmukaan, tulee respiraatiosta).
		//0.4 on minimiskaala
		//0.65 on maksimiksaala.

		if ((expand == true) && (scalefactor <= maxSize)) {
			scalefactor += Time.deltaTime * ExpandSpeed;
			//this.transform.localScale = new Vector3 ( scalefactor, scalefactor, scalefactor) ;
            if (NetworkServer.active)
            {
                RpcScale();
            }
            else if (NetworkClient.active)
            {
                CmdScale();
            }
        }
		if ((expand == false) && (scalefactor >= minSize)){
		    scalefactor -= Time.deltaTime * ExpandSpeed;
			//this.transform.localScale = new Vector3 ( scalefactor, scalefactor, scalefactor) ;
            if (NetworkServer.active)
            {
                RpcScale();
            }
            else if (NetworkClient.active)
            {
                CmdScale();
            }
        } 
	}

    [Command]
    void CmdScale()
    {
        RpcScale();
    }

    [ClientRpc]
    void RpcScale()
    {
        transform.localScale = new Vector3(scalefactor, scalefactor, scalefactor);
    }
}
