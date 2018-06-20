using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontalAssymmetrySimulation : MonoBehaviour {

    ParticleSystem ps;
    GameObject bridge;
	// Use this for initialization
	void Start () {
        bridge = GameObject.Find("sceneholder2/StoneSlabRound13/Bridge");
        ps = GameObject.Find("sceneholder2/ParticlePillar").GetComponent<ParticleSystem>();
        if (ps.isPlaying)
        {
            ps.Stop();
        }
	}
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = bridge.GetComponent<Renderer>();
        Material material = renderer.materials[1];
        float faValue = Mathf.Abs(Mathf.Sin(Time.time * 0.2f));
        faValue = faValue + 0.5f;
        material.SetColor("_EmissionColor", new Color(faValue, faValue, faValue));

	}
}
